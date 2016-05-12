using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL.Entities;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
	public class ForumDAL
    {
		static string ConnectionString()
		{
			var connectionStringItem = ConfigurationManager.ConnectionStrings["ForumConnection"];
			var connectionString = connectionStringItem.ConnectionString;
			return connectionString;
		}

		/// <summary>
		/// Регистрация пользователя
		/// </summary>
		/// <param name="user"></param>
		public bool Registration(Users user)
		{
			if (CheckLogin(user.Login) == true)
				throw new ArgumentException("Такой логин уже существует. Попробуйте другой.");

			using (var connection = new SqlConnection(ConnectionString()))
			{
				var command = new SqlCommand();
                if (user.Avatar != null)
				{
					command = new SqlCommand(
					"INSERT INTO dbo.Users (Name, Login, Password," +
					"RegistrationDate, Avatar) VALUES (@Name, @Login," +
					" @Password, @RegistrationDate, @Avatar)", connection);

					command.Parameters.AddWithValue("@Name", user.Name);
					command.Parameters.AddWithValue("@Login", user.Login);
					command.Parameters.AddWithValue("@Password", user.Password);
					command.Parameters.AddWithValue("@RegistrationDate",
													user.RegistrationDate);
					command.Parameters.AddWithValue("@Avatar", user.Avatar);
				}
				else
				{
					command = new SqlCommand(
					"INSERT INTO dbo.Users (Name, Login, Password," +
					"RegistrationDate) VALUES (@Name, @Login," +
					" @Password, @RegistrationDate)", connection);

					command.Parameters.AddWithValue("@Name", user.Name);
					command.Parameters.AddWithValue("@Login", user.Login);
					command.Parameters.AddWithValue("@Password", user.Password);
					command.Parameters.AddWithValue("@RegistrationDate",
													user.RegistrationDate);
				}
				connection.Open();
				return command.ExecuteNonQuery() == 1;
			}
		}

		/// <summary>
		/// Вход в систему
		/// </summary>
		/// <param name="Login"></param>
		/// <param name="Password"></param>
		public bool Login(string Login, string Password)
		{
			if (CheckLogin(Login) == false)
				throw new ArgumentException("Такого логина не существует, перепроверьте данные.");

			using (var connection = new SqlConnection(ConnectionString()))
			{
				var command = new SqlCommand(
					"SELECT Login, Password FROM dbo.Users" +
					" WHERE Login = '"+Login+"'", connection);

				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				var userDB = new Users();
				while (reader.Read())
				{
					userDB.Login = Convert.ToString(reader.GetValue(0));
					userDB.Password = Convert.ToString(reader.GetValue(1));
				}
				if (userDB.Password == Password)
					return true;
				else return false;

			}
		}

		/// <summary>
		/// Получение прав пользователя
		/// </summary>
		/// <param name="Login"></param>
		public int UserRole(string Login)
		{
			if (CheckLogin(Login) == false)
				throw new ArgumentException("Такого логина не существует, перепроверьте данные.");

			using (var connection = new SqlConnection(ConnectionString()))
			{
				var command = new SqlCommand(
					"SELECT Login, TypeID FROM dbo.Users" +
					" WHERE Login = '"+Login+"'", connection);

				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				int typeId = 2;
				while (reader.Read())
				{
					typeId = Convert.ToInt32(reader.GetValue(1));
				}
				return typeId;

			}
		}

		/// <summary>
		/// Получение списка пользователей
		/// </summary>
		/// <param name=""></param>
		public IEnumerable<Users> GetUsers()
		{
			var users = new List<Users>();
			using (var connection = new SqlConnection(ConnectionString()))
			{
				var command = new SqlCommand(
					"SELECT u.UserID, u.Login, u.Name, u.RegistrationDate," +
					" u.TypeID, ut.UserType, u.Avatar FROM dbo.Users as u INNER JOIN " +
					"dbo.UserTypes as ut ON u.TypeID = ut.TypeID", connection);

				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					var user = new Users();

					user.UserID = Convert.ToInt32(reader.GetValue(0));
					user.Login = Convert.ToString(reader.GetValue(1));
					user.Name = Convert.ToString(reader.GetValue(2));
					user.RegistrationDate = Convert.ToDateTime(reader.GetValue(3));
					user.TypeID = Convert.ToInt32(reader.GetValue(4));
					user.UserType = Convert.ToString(reader.GetValue(5));
					user.Avatar = Convert.ToString(reader.GetValue(6));
					users.Add(user);
				}
				return users;
			}
		}

		/// <summary>
		/// Получение информации определённого пользователя
		/// </summary>
		/// <param name="UserID"></param>
		public Users GetUserById(int UserID)
		{
			if (CheckUserID(UserID) == false)
				throw new ArgumentException("Неверный идентификатор пользователя, перепроверьте данные.");

			using (var connection = new SqlConnection(ConnectionString()))
			{
				var command = new SqlCommand(
					"SELECT u.UserID, u.Login, u.Password, u.Name, u.RegistrationDate, " +
					"u.TypeID, ut.UserType, u.Avatar FROM dbo.Users as u INNER JOIN" +
					" dbo.UserTypes as ut ON u.TypeID = ut.TypeID WHERE UserID = @UserID", connection);

				command.Parameters.AddWithValue("@UserID", UserID);

				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				var user = new Users();
				while (reader.Read())
				{
					user.UserID = Convert.ToInt32(reader.GetValue(0));
					user.Login = Convert.ToString(reader.GetValue(1));
					user.Password = Convert.ToString(reader.GetValue(2));
					user.Name = Convert.ToString(reader.GetValue(3));
					user.RegistrationDate = Convert.ToDateTime(reader.GetValue(4));
					user.TypeID = Convert.ToInt32(reader.GetValue(5));
					user.UserType = Convert.ToString(reader.GetValue(6));
					user.Avatar = Convert.ToString(reader.GetValue(7));
				}
				return user;
			}
		}

		/// <summary>
		/// Получение информации о пользователе в онлайне
		/// </summary>
		/// <param name="Login"></param>
		public Users GetCurentUser(string Login)
		{
			if (CheckLogin(Login) == false)
				throw new ArgumentException("Такого пользователя не существует.");

			using (var connection = new SqlConnection(ConnectionString()))
			{
				var command = new SqlCommand(
					"SELECT UserID, Avatar, Name FROM dbo.Users " +
					"WHERE Login = '"+Login+"'", connection);

				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				Users user = new Users();
				while (reader.Read())
				{
					user.UserID = Convert.ToInt32(reader.GetValue(0));
					user.Avatar = Convert.ToString(reader.GetValue(1));
					user.Name = Convert.ToString(reader.GetValue(2));
				}
				return user;
			}
		}

		/// <summary>
		/// Последнее сообщение в теме
		/// </summary>
		/// <param name="TopicID"></param>
		public Users LastMessage(int TopicID)
		{
			if (CheckTopicID(TopicID) == false)
				throw new ArgumentException("Темы не существует.");
			
			using (var connection = new SqlConnection(ConnectionString()))
			{
				var command = new SqlCommand(
					"SELECT TOP(1) u.Name, m.SendDate FROM dbo.Messages as m" +
					" INNER JOIN dbo.Users as u ON m.UserID = u.UserID" +
					" WHERE m.TopicID = @TopicID and m.StatusID = 1 ORDER BY SendDate DESC", connection);

				command.Parameters.AddWithValue("@TopicID", TopicID);

				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				var user = new Users();
				while (reader.Read())
				{
					user.Name = Convert.ToString(reader.GetValue(0));
					user.RegistrationDate = Convert.ToDateTime(reader.GetValue(1));
				}
				return user;
			}
		}

		/// <summary>
		/// Последнее сообщение темы, для администратора
		/// </summary>
		/// <param name="TopicID"></param>
		public Users LastMessageForAdmin(int TopicID)
		{
			if (CheckTopicID(TopicID) == false)
				throw new ArgumentException("темы не существует.");

			using (var connection = new SqlConnection(ConnectionString()))
			{
				var command = new SqlCommand(
					"SELECT TOP(1) u.Name, m.SendDate FROM dbo.Messages as m" +
					" INNER JOIN dbo.Users as u ON m.UserID = u.UserID" +
					" WHERE m.TopicID = @TopicID ORDER BY SendDate DESC", connection);

				command.Parameters.AddWithValue("@TopicID", TopicID);

				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				var user = new Users();
				while (reader.Read())
				{
					user.Name = Convert.ToString(reader.GetValue(0));
					user.RegistrationDate = Convert.ToDateTime(reader.GetValue(1));
				}
				return user;
			}
		}

		/// <summary>
		/// Получение разделов фрума
		/// </summary>
		/// <param name=""></param>
		public IEnumerable<Sections> GetSections()
		{
			var sections = new List<Sections>();
			using (var connection = new SqlConnection(ConnectionString()))
			{
				var command = new SqlCommand(
					"SELECT SectionID, SectionName FROM dbo.Sections", connection);

				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					var section = new Sections();

					section.SectionID = Convert.ToInt32(reader.GetValue(0));
					section.SectionName = Convert.ToString(reader.GetValue(1));
					sections.Add(section);
				}
				return sections;
			}
		}

		/// <summary>
		/// Получение тем из раздела
		/// </summary>
		/// <param name="SectionID"></param>
		public IEnumerable<Topics> GetTopics(int SectionID)
		{
			if (CheckSectionID(SectionID) == false)
				throw new ArgumentException("Такого раздела не существует.");

			var topics = new List<Topics>();
			using (var connection = new SqlConnection(ConnectionString()))
			{
				var command = new SqlCommand(
					"SELECT t.SectionID, t.TopicID, t.TopicName, "+
					"t.CreateDate, u.Name, (SELECT COUNT(MessageID)" +
					" FROM dbo.Messages WHERE TopicID = t.TopicID and " +
					"StatusID = 1 ) as MessageCount FROM dbo.Topics as t " +
					"INNER JOIN dbo.Users as u ON u.UserID = t.UserID" +
                    " WHERE t.SectionID = @SectionID", connection);

				command.Parameters.AddWithValue("@SectionID", SectionID);

				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					var topic = new Topics();
					topic.SectionID = Convert.ToInt32(reader.GetValue(0));
					topic.TopicID = Convert.ToInt32(reader.GetValue(1));
                    topic.TopicName = Convert.ToString(reader.GetValue(2));
					topic.CreateDate = Convert.ToDateTime(reader.GetValue(3));
					topic.Name = Convert.ToString(reader.GetValue(4));
					topic.MessageCount = Convert.ToInt32(reader.GetValue(5));
					topics.Add(topic);
				}
				return topics;
			}
		}

		/// <summary>
		/// Получение тем в разделе, для администратора
		/// </summary>
		/// <param name="SectionID"></param>
		public IEnumerable<Topics> GetTopicsForAdmin(int SectionID)
		{
			if (CheckSectionID(SectionID) == false)
				throw new ArgumentException("Такого раздела не существует.");

			var topics = new List<Topics>();
			using (var connection = new SqlConnection(ConnectionString()))
			{
				var command = new SqlCommand(
					"SELECT t.SectionID, t.TopicID, t.TopicName, " +
					"t.CreateDate, u.Name, (SELECT COUNT(MessageID)" +
					" FROM dbo.Messages WHERE TopicID = t.TopicID) " +
					"as MessageCount FROM dbo.Topics as t " +
					"INNER JOIN dbo.Users as u ON u.UserID = t.UserID" +
					" WHERE t.SectionID = @SectionID", connection);

				command.Parameters.AddWithValue("@SectionID", SectionID);

				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					var topic = new Topics();
					topic.SectionID = Convert.ToInt32(reader.GetValue(0));
					topic.TopicID = Convert.ToInt32(reader.GetValue(1));
					topic.TopicName = Convert.ToString(reader.GetValue(2));
					topic.CreateDate = Convert.ToDateTime(reader.GetValue(3));
					topic.Name = Convert.ToString(reader.GetValue(4));
					topic.MessageCount = Convert.ToInt32(reader.GetValue(5));
					topics.Add(topic);
				}
				return topics;
			}
		}

		/// <summary>
		///	Получение темы по идентификатору
		/// </summary>
		/// <param name="TopicID"></param>
		public Topics GetTopicByID(int TopicID)
		{
			if (CheckTopicID(TopicID) == false)
				throw new ArgumentException("Такой темы не существует.");
			
			using (var connection = new SqlConnection(ConnectionString()))
			{
				var command = new SqlCommand(
					"SELECT t.SectionID, t.TopicID, t.TopicName, t.TopicText, " +
					"t.CreateDate, u.Name, u.Avatar FROM dbo.Topics as t " +
					"INNER JOIN dbo.Users as u ON u.UserID = t.UserID" +
					" WHERE t.TopicID = @TopicID", connection);

				command.Parameters.AddWithValue("@TopicID", TopicID);

				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				var topic = new Topics();
				while (reader.Read())
				{	
					topic.SectionID = Convert.ToInt32(reader.GetValue(0));
					topic.TopicID = Convert.ToInt32(reader.GetValue(1));
					topic.TopicName = Convert.ToString(reader.GetValue(2));
					topic.TopicText = Convert.ToString(reader.GetValue(3));
					topic.CreateDate = Convert.ToDateTime(reader.GetValue(4));
					topic.Name = Convert.ToString(reader.GetValue(5));
					topic.Avatar = Convert.ToString(reader.GetValue(6)); 
				}
				return topic;
			}
		}

		/// <summary>
		/// Получение сообщений в теме
		/// </summary>
		/// <param name="TopicID"></param>
		public IEnumerable<Messages> GetMessages(int TopicID)
		{
			if (CheckTopicID(TopicID) == false)
				throw new ArgumentException("Такой темы не существует.");

			var messages = new List<Messages>();
			using (var connection = new SqlConnection(ConnectionString()))
			{
				var command = new SqlCommand(
					"SELECT m.MessageID, m.TopicID, m.SendDate, m.Text, " +
					"m.StatusID, u.Name, u.Avatar FROM dbo.Messages as m " +
					" INNER JOIN dbo.Users as u ON m.UserID = u.UserID " +
					"WHERE m.TopicID = @TopicID ORDER BY m.SendDate", connection);
				command.Parameters.AddWithValue("@TopicID", TopicID);

				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					var message = new Messages();

					message.MessageID = Convert.ToInt32(reader.GetValue(0));
					message.TopicID = Convert.ToInt32(reader.GetValue(1));
					message.SendDate = Convert.ToDateTime(reader.GetValue(2));
					message.Text = Convert.ToString(reader.GetValue(3));
					message.StatusID = Convert.ToInt32(reader.GetValue(4));
					message.Name = Convert.ToString(reader.GetValue(5));
					message.Avatar = Convert.ToString(reader.GetValue(6));
					messages.Add(message);
				}
				return messages;
			}
		}

		/// <summary>
		/// Создать новую тему
		/// </summary>
		/// <param name="topic"></param>
		public bool CreateTopic(Topics topic)
		{
			using (var connection = new SqlConnection(ConnectionString()))
			{
				var command = new SqlCommand(
				"INSERT INTO dbo.Topics (SectionID, TopicName, TopicText," +
				"UserID, CreateDate) VALUES (@SectionID, @TopicName, " +
				"@TopicText, @UserID, @Date)", connection);

				command.Parameters.AddWithValue("@SectionID", topic.SectionID);
				command.Parameters.AddWithValue("@TopicName", topic.TopicName);
				command.Parameters.AddWithValue("@TopicText", topic.TopicText);
				command.Parameters.AddWithValue("@UserID", topic.UserID);
				command.Parameters.AddWithValue("@Date", topic.CreateDate);
				connection.Open();
				return command.ExecuteNonQuery() == 1;
			}
		}

		/// <summary>
		/// Создать новое сообщение
		/// </summary>
		/// <param name="message"></param>
		public bool CreateMessage(Messages message)
		{
			using(var connection = new SqlConnection(ConnectionString()))
            {
				var command = new SqlCommand(
				"INSERT INTO dbo.Messages (TopicID, Text, SendDate,UserID) " +
				"VALUES (@TopicID, @Text, @SendDate, @UserID)", connection);															
				
				command.Parameters.AddWithValue("@TopicID", message.TopicID);
				command.Parameters.AddWithValue("@Text", message.Text);
				command.Parameters.AddWithValue("@SendDate", message.SendDate);
				command.Parameters.AddWithValue("@UserID", message.UserID);
				connection.Open();
				return command.ExecuteNonQuery() == 1;
			}
		}

		/// <summary>
		/// Создать новый раздел
		/// </summary>
		/// <param name="sectionName"></param>
		public bool CreateSection(string sectionName)
		{
			using (var connection = new SqlConnection(ConnectionString()))
			{
				var command = new SqlCommand(
				"INSERT INTO dbo.Sections (SectionName) " +
				"VALUES (@SectionName)", connection);

				command.Parameters.AddWithValue("@SectionName", sectionName);
				connection.Open();
				return command.ExecuteNonQuery() == 1;
			}
		}

		/// <summary>
		/// Изменить информацию о пользователе
		/// </summary>
		/// <param name="user"></param>
		public bool ChangeUserType(Users user)
		{
			if (CheckUserID(user.UserID) == false)
				throw new ArgumentException("Неверный идентификатор пользователя, перепроверьте данные.");

			using (var connection = new SqlConnection(ConnectionString()))
			{
				var command = new SqlCommand(
					"UPDATE dbo.Users SET Login = @Login, Password = @Password, " +
					"Name = @Name, RegistrationDate = @RegistrationDate, " +
					"TypeID = @TypeID, @Avatar = Avatar WHERE UserID = @UserID", connection);

				command.Parameters.AddWithValue("@Login", user.Login);
				command.Parameters.AddWithValue("@Password", user.Password);
				command.Parameters.AddWithValue("@Name", user.Name);
				command.Parameters.AddWithValue("@RegistrationDate", user.RegistrationDate);
				command.Parameters.AddWithValue("@UserID", user.UserID);
				command.Parameters.AddWithValue("@TypeID", user.TypeID);
				command.Parameters.AddWithValue("@Avatar", user.Avatar);
				connection.Open();
				return command.ExecuteNonQuery() == 1;
			}

		}

		/// <summary>
		/// Изменить статус сообщения: видимый/невидимый
		/// </summary>
		/// <param name="MessageID"></param>
		/// <param name="StatusID"></param>
		public bool ChangeMessageStatus(int MessageID, int StatusID)
		{
			if (CheckMessageID(MessageID) == false)
				throw new ArgumentException("Такого сообщения не существует.");

			using (var connection = new SqlConnection(ConnectionString()))
			{
				var command = new SqlCommand(
					"UPDATE dbo.Messages SET StatusID = @StatusID WHERE " +
					"MessageID = @MessageID", connection);

				command.Parameters.AddWithValue("@MessageID", MessageID);
				command.Parameters.AddWithValue("@StatusID", StatusID);
				connection.Open();
				return command.ExecuteNonQuery() == 1;
			}
		}

		/// <summary>
		/// Проверка идентификатора секции
		/// </summary>
		/// <param name="SectionID"></param>
		public bool CheckSectionID(int SectionID)
		{
			using (var connection = new SqlConnection(ConnectionString()))
			{
				SqlCommand command = new SqlCommand("select SectionID from dbo.Sections where SectionID = @id");
				command.Connection = connection;
				command.Parameters.AddWithValue("@id", SectionID);
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
					return reader.Read();
			}
		}

		/// <summary>
		/// Проверка идентификатора темы
		/// </summary>
		/// <param name="TopicID"></param>
		public bool CheckTopicID(int TopicID)
		{
			using (var connection = new SqlConnection(ConnectionString()))
			{
				SqlCommand command = new SqlCommand("select TopicID from dbo.Topics where TopicID = @id");
				command.Connection = connection;
				command.Parameters.AddWithValue("@id", TopicID);
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
					return reader.Read();
			}
		}

		/// <summary>
		/// Проверка идентификатора пользователя
		/// </summary>
		/// <param name="UserID"></param>
		public bool CheckUserID(int UserID)
		{
			using (var connection = new SqlConnection(ConnectionString()))
			{
				SqlCommand command = new SqlCommand("select UserID from dbo.Users where UserID = @id");
				command.Connection = connection;
				command.Parameters.AddWithValue("@id", UserID);
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
					return reader.Read();
			}
		}

		/// <summary>
		/// Проверка логина пользователя
		/// </summary>
		/// <param name="login"></param>
		public bool CheckLogin(string login)
		{
			using (var connection = new SqlConnection(ConnectionString()))
			{
				SqlCommand command = new SqlCommand("select Login from dbo.Users where Login = '"+login+"'");
				command.Connection = connection;
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
					return reader.Read();
			}
		}

		/// <summary>
		/// Проверка идентификатора сообщения
		/// </summary>
		/// <param name="login"></param>
		public bool CheckMessageID(int MessageID)
		{
			using (var connection = new SqlConnection(ConnectionString()))
			{
				SqlCommand command = new SqlCommand("select MessageID from dbo.Messages where MessageID = @id");
				command.Connection = connection;
				command.Parameters.AddWithValue("@id", MessageID);
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
					return reader.Read();
			}
		}

		/// <summary>
		/// Удаление сообщения
		/// </summary>
		/// <param name="login"></param>
		public bool DropMessage(int MessageID)
		{
			using (var connection = new SqlConnection(ConnectionString()))
			{
				SqlCommand command = new SqlCommand("DELETE FROM dbo.Messages WHERE MessageID = @id");
				command.Connection = connection;
				command.Parameters.AddWithValue("@id", MessageID);
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
					return reader.Read();
			}
		}

		/// <summary>
		/// удаление темы
		/// </summary>
		/// <param name="login"></param>
		public bool DropTopic(int TopicID)
		{
			using (var connection = new SqlConnection(ConnectionString()))
			{
				var allMessages = GetMessages(TopicID);
				foreach (var m in allMessages)
				{
					DropMessage(m.MessageID);
				}
				SqlCommand command = new SqlCommand("DELETE FROM dbo.Topics WHERE TopicID = @id");
				command.Connection = connection;
				command.Parameters.AddWithValue("@id", TopicID);
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
					return reader.Read();
			}
		}

		/// <summary>
		/// Удаление раздела
		/// </summary>
		/// <param name="login"></param>
		public bool DropSection(int SectionID)
		{
			using (var connection = new SqlConnection(ConnectionString()))
			{
				var allTopics = GetTopics(SectionID);
				foreach(var t in allTopics)
				{
					DropTopic(t.TopicID);
				}
				SqlCommand command = new SqlCommand("DELETE FROM dbo.Sections WHERE SectionID = @id");
				command.Connection = connection;
				command.Parameters.AddWithValue("@id", SectionID);
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
					return reader.Read();
			}
		}

		/// <summary>
		/// Изменение аватара пользователя
		/// </summary>
		/// <param name="UserID"></param>
		/// <param name="Avatar"></param>
		public bool ChangeAvatar(int UserID, string Avatar)
		{
			using (var connection = new SqlConnection(ConnectionString()))
			{
				var command = new SqlCommand(
					"UPDATE dbo.Users SET Avatar = '"+Avatar+"' WHERE " +
					"UserID = @id", connection);
				command.Connection = connection;
				command.Parameters.AddWithValue("@id", UserID);
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
					return reader.Read();
			}
		}
	}
}

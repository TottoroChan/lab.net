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
		/*static string ConnectionString()
		{
			var connectionStringItem = ConfigurationManager.ConnectionStrings["ForumConnection"];
			var connectionString = connectionStringItem.ConnectionString;
			return connectionString;
		}*/

		string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=ForumDB;Integrated Security=True;";

		/// <summary>
		///
		/// </summary>
		/// <param name=""></param>
		public bool Registration(Users user)
		{
			if (CheckLogin(user.Login) == false)
				throw new ArgumentException("Incorrect value", "Login");

			using (var connection = new SqlConnection(connectionString))
			{
				var command = new SqlCommand(
				"INSERT INTO dbo.Users (Name, Login, Password," +
				"RegistrationDate) VALUES (@Name, @Login," +
				" @Password, @RegistrationDate)", connection);

				command.Parameters.AddWithValue("@Name", user.Name);
				command.Parameters.AddWithValue("@Login", user.Login);
				command.Parameters.AddWithValue("@Password", user.Password);
				command.Parameters.AddWithValue("@RegistrationDate",
												user.RegistrationDate);
				connection.Open();
				return command.ExecuteNonQuery() == 1;
			}
		}

		public bool Login(Users user)
		{
			if (CheckLogin(user.Login) == false)
				throw new ArgumentException("Incorrect value", "Login");

			using (var connection = new SqlConnection(connectionString))
			{
				var command = new SqlCommand(
					"SELECT Login, Password FROM dbo.Users" +
					" WHERE Login = @Login", connection);

				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				var userDB = new Users();
				while (reader.Read())
				{
					userDB.Login = Convert.ToString(reader.GetValue(0));
					userDB.Password = Convert.ToString(reader.GetValue(1));
				}
				if (userDB.Password == user.Password)
					return true;
				else return false;

			}
		}

		public int UserInfo(string Login)
		{
			if (CheckLogin(Login) == false)
				throw new ArgumentException("Incorrect value", "Login");

			using (var connection = new SqlConnection(connectionString))
			{
				var command = new SqlCommand(
					"SELECT Login, TypeID FROM dbo.Users" +
					" WHERE Login = @Login", connection);

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

		public IEnumerable<Users> GetUsers()
		{
			var users = new List<Users>();
			using (var connection = new SqlConnection(connectionString))
			{
				var command = new SqlCommand(
					"SELECT Login, Name, RegistrationDate, TypeID FROM dbo.Users", connection);

				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					var user = new Users();

					user.Login = Convert.ToString(reader.GetValue(0));
					user.Name = Convert.ToString(reader.GetValue(1));
					user.RegistrationDate = Convert.ToDateTime(reader.GetValue(2));
					user.TypeID = Convert.ToInt32(reader.GetValue(3));
					users.Add(user);
				}
				return users;
			}
		}

		public Users LastMessage(int TopicID)
		{
			if (CheckTopicID(TopicID) == false)
				throw new ArgumentException("Incorrect value", "TopicID");
			
			using (var connection = new SqlConnection(connectionString))
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
		public IEnumerable<Sections> GetSections()
		{
			var sections = new List<Sections>();
			using (var connection = new SqlConnection(connectionString))
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

		public IEnumerable<Topics> GetTopics(int SectionID)
		{
			if (CheckSectionID(SectionID) == false)
				throw new ArgumentException("Incorrect value", "SectionID");

			var topics = new List<Topics>();
			using (var connection = new SqlConnection(connectionString))
			{
				var command = new SqlCommand(
					"SELECT t.SectionID, t.TopicID, t.TopicName, "+
					"t.CreateDate, u.Name, (SELECT COUNT(MessageID)" +
					" FROM dbo.Messages WHERE TopicID = t.TopicID)" +
					" as MessageCount FROM dbo.Topics as t " +
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

		public IEnumerable<Messages> GetMessages(int TopicID)
		{
			if (CheckTopicID(TopicID) == false)
				throw new ArgumentException("Incorrect value", "TopicID");

			var messages = new List<Messages>();
			using (var connection = new SqlConnection(connectionString))
			{
				var command = new SqlCommand(
					"SELECT m.MessageID, m.TopicID, m.SendDate, m.Text, " +
					"m.StatusID, u.Name, u.RegistrationDate FROM dbo.Messages"+
					" as m INNER JOIN dbo.Users as u ON m.UserID = u.UserID" +
					"WHERE m.TopicID = @TopicID", connection);
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
					message.RegistrationDate = 
										Convert.ToDateTime(reader.GetValue(6));
					messages.Add(message);
				}
				return messages;
			}
		}

		public bool CreateTopic(Topics topic)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				var command = new SqlCommand(
				"INSERT INTO dbo.Topics (SectionID, TopicName, TopicText," +
				"UserID, CreateDate) VALUES (@SectionID, @TopicName, " +
				"@TopicText, @UserID, @Date)", connection);

				command.Parameters.AddWithValue("@SectionID", topic.SectionID);
				command.Parameters.AddWithValue("@Login", topic.TopicName);
				command.Parameters.AddWithValue("@Password", topic.TopicText);
				command.Parameters.AddWithValue("@UserID", topic.UserID);
				command.Parameters.AddWithValue("@Date", topic.CreateDate);
				connection.Open();
				return command.ExecuteNonQuery() == 1;
			}
		}

		public bool CreateMessage(Messages message)
		{
			using(var connection = new SqlConnection(connectionString))
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


		public bool ChangeUserType(Users user)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				var command = new SqlCommand(
					"UPDATE dbo.Users SET TypeID = @TypeID WHERE" +
					"UserID = @UserID", connection);

				command.Parameters.AddWithValue("@UserID", user.UserID);
				command.Parameters.AddWithValue("@TypeID", user.TypeID);
				connection.Open();
				return command.ExecuteNonQuery() == 1;
			}

		}



		public bool ChangeMessageType(Messages message)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				var command = new SqlCommand(
					"UPDATE dbo.Messages SET StatusID = @StatusID WHERE " +
					"MessageID = @MessageID", connection);

				command.Parameters.AddWithValue("@MessageID", message.MessageID);
				command.Parameters.AddWithValue("@StatusID", message.StatusID);
				connection.Open();
				return command.ExecuteNonQuery() == 1;
			}
		}

		public bool CheckSectionID(int SectionID)
		{
			using (var connection = new SqlConnection(connectionString))
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
		/// CheckEmployeeID
		/// </summary>
		/// <param name="id"></param>
		public bool CheckTopicID(int TopicID)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand("select TopicID from dbo.Topics where TopicID = @id");
				command.Connection = connection;
				command.Parameters.AddWithValue("@id", TopicID);
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
					return reader.Read();
			}
		}

		public bool CheckLogin(string login)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand("select Login from dbo.Users where Login like @Login");
				command.Connection = connection;
				command.Parameters.AddWithValue("@Login", "'"+login+"'");
				connection.Open();
				using (SqlDataReader reader = command.ExecuteReader())
					return reader.Read();
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ForumDAL.Entities;
using System.Data.SqlClient;
using System.Data;

namespace ForumDAL
{
    public class ForumDAL
    {
		string connectionString = ConfigurationManager.ConnectionStrings
			["TestConnectionString"].ConnectionString;
		/// <summary>
		///
		/// </summary>
		/// <param name=""></param>
		public bool Registration(Users user)
		{

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

		public IEnumerable<Sections> GetSections()
		{
			var sections = new List<Sections>();
			using (var connection = new SqlConnection(connectionString))
			{
				var command = new SqlCommand(
					"SELECT SectionID, SetionName FROM dbo.Sections", connection);

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
			var topics = new List<Topics>();
			using (var connection = new SqlConnection(connectionString))
			{
				var command = new SqlCommand(
					"SELECT t.TopicID, t.SectionID, t.TopicName, t.TopicText,"+
					"t.CreateDate, t.UserID, (SELECT COUNT(MessageID)" +
					" FROM dbo.Messages WHERE TopicID = t.TopicID)" +
					" as MessageCount FROM dbo.Topics as t " +
					"WHERE t.SectionID = @SectionID", connection);

				command.Parameters.AddWithValue("@SectionID", SectionID);

				connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					var topic = new Topics();

					topic.TopicID = Convert.ToInt32(reader.GetValue(0));
					topic.SectionID = Convert.ToInt32(reader.GetValue(1));
					topic.TopicName = Convert.ToString(reader.GetValue(2));
					topic.TopicText = Convert.ToString(reader.GetValue(3));
					topic.CreateDate = Convert.ToDateTime(reader.GetValue(4));
					topic.UserID = Convert.ToInt32(reader.GetValue(5));
					topic.MessageCount = Convert.ToInt32(reader.GetValue(6));
					topics.Add(topic);
				}
				return topics;
			}
		}

		public IEnumerable<Messages> GetMessages(int TopicID)
		{
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
					"MessageID = @StatusID", connection);

				command.Parameters.AddWithValue("@MessageID", message.MessageID);
				command.Parameters.AddWithValue("@StatusID", message.StatusID);
				connection.Open();
				return command.ExecuteNonQuery() == 1;
			}
		}

		/*	public bool Login(Users user)
			{
				if (CheckOrderID(OrderID) == false)
					throw new ArgumentException("Incorrect value", "OrderID");
				var order = new List<OrderDetails>();

				using (var connection = new SqlConnection(ConnectionString))
				{

				}
			}

			public bool CreateSection(Sections Section)
			{
				if (CheckOrderID(OrderID) == false)
					throw new ArgumentException("Incorrect value", "OrderID");

				using (var connection = new SqlConnection(ConnectionString))
				{

				}
			}
*/
	}
}

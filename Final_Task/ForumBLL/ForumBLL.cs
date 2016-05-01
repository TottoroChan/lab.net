using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Validation;
using DAL;
using DAL.Entities;

namespace BLL
{
    public class ForumBLL
    {

		ForumDAL Data = new ForumDAL();

		/// <summary>
		///
		/// </summary>
		/// <param name=""></param>
		public bool Registration(UsersDTO user)
		{
			try
			{
				Users UserDAL = new Users();
				UserDAL.Name = user.Name;
				UserDAL.Login = user.Login;
				UserDAL.Password = user.Password;
				UserDAL.RegistrationDate = DateTime.Now;

				if (Data.Registration(UserDAL) != true)
					return true;
				else return false;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		public bool Login(UsersDTO user)
		{
			try
			{
				Users UserDAL = new Users();
				UserDAL.Login = user.Login;
				UserDAL.Password = user.Password;

				if (Data.Login(UserDAL) != true)
					return true;
				else return false;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		public int UserInfo(string Login)
		{
			try
			{
				return Data.UserInfo(Login);
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}
		public IEnumerable<UsersDTO> GetUsers()
		{
			try
			{
				List<UsersDTO> Users = new List<UsersDTO>();
				var UsersDAL = Data.GetUsers();

				foreach (var u in UsersDAL)
				{
					UsersDTO user = new UsersDTO();
					user.Login = u.Login;
					user.Name = u.Name;
					user.RegistrationDate = u.RegistrationDate;
					user.TypeID = u.TypeID;
					Users.Add(user);
				}
				return Users;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		public UsersDTO LastMessage(int TopicID)
		{ 		
			try
			{
				UsersDTO Users = new UsersDTO();
				var UserDAL = Data.LastMessage(TopicID);

				Users.Name = UserDAL.Name;
				Users.RegistrationDate = UserDAL.RegistrationDate;
				return Users;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		public IEnumerable<SectionsDTO> GetSections()
		{
			try
			{
				List<SectionsDTO> Sections = new List<SectionsDTO>();
				var SectionDAL = Data.GetSections();

				foreach (var s in SectionDAL)
				{
					SectionsDTO section = new SectionsDTO();
					section.SectionID = s.SectionID;
					section.SectionName = s.SectionName;
					Sections.Add(section);
				}
				return Sections;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		public IEnumerable<TopicsDTO> GetTopics(int SectionID)
		{
			try
			{
				List<TopicsDTO> Topics = new List<TopicsDTO>();
				var TopicDAL = Data.GetTopics(SectionID);

				foreach (var t in TopicDAL)
				{
					TopicsDTO topic = new TopicsDTO();
					topic.TopicID = t.TopicID;
					topic.SectionID = t.SectionID;
					topic.TopicName = t.TopicName;
					topic.TopicText = t.TopicText;
					topic.Name = t.Name;
					topic.CreateDate = t.CreateDate;
					topic.MessageCount = t.MessageCount;
					Topics.Add(topic);
				}
				return Topics;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		public IEnumerable<MessagesDTO> GetMessages(int TopicID)
		{
			try
			{
				List<MessagesDTO> Messages = new List<MessagesDTO>();
				var MessageDAL = Data.GetMessages(TopicID);

				foreach (var m in MessageDAL)
				{
					MessagesDTO message = new MessagesDTO();
					message.MessageID = m.MessageID;
					message.TopicID = m.TopicID;
					message.SendDate = m.SendDate;
					message.Text = m.Text;
					message.StatusID = m.StatusID;
					message.Name = m.Name;
                    message.RegistrationDate = m.RegistrationDate;

					Messages.Add(message);
				}
				return Messages;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		public bool CreateTopic(TopicsDTO topic)
		{
			try
			{
				Topics TopicDAL = new Topics();

				TopicDAL.SectionID = topic.SectionID;
				TopicDAL.TopicName = topic.TopicName;
				TopicDAL.TopicText = topic.TopicText;
				TopicDAL.UserID = topic.UserID;
				TopicDAL.CreateDate = DateTime.Now;

				if (Data.CreateTopic(TopicDAL) != true)
					return true;
				else return false;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		public bool CreateMessage(MessagesDTO message)
		{
			try
			{
				Messages MessageDAL = new Messages();
				MessageDAL.TopicID = message.TopicID;
				MessageDAL.Text = message.Text;
				MessageDAL.SendDate = DateTime.Now;
				MessageDAL.UserID = message.UserID;

				if (Data.CreateMessage(MessageDAL) != true)
					return true;
				else return false;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}


		public bool ChangeUserType(UsersDTO user)
		{
			try
			{
				Users UserDAL = new Users();
				UserDAL.UserID = user.UserID;
				UserDAL.TypeID = user.TypeID;

				if (Data.Registration(UserDAL) != true)
					return true;
				else return false;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}



		public bool ChangeMessageType(MessagesDTO message)
		{
			try
			{
				Messages MessageDAL = new Messages();
				MessageDAL.MessageID = message.MessageID;
				MessageDAL.StatusID = message.StatusID;

				if (Data.ChangeMessageType(MessageDAL) != true)
					return true;
				else return false;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		/*	public bool Login(UsersDTO user)
			{
				
			}

			public bool CreateSection(SectionsDTO Section)
			{
				
			}
*/
	}
}

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
		/// Регистрация
		/// </summary>
		/// <param name="user"></param>
		public bool Registration(UsersDTO user)
		{
			try
			{
				Users UserDAL = new Users();
				UserDAL.Name = user.Name;
				UserDAL.Login = user.Login;
				UserDAL.Password = user.Password;
				UserDAL.RegistrationDate = DateTime.Now;
				UserDAL.Avatar = user.Avatar;

				if (Data.Registration(UserDAL) == true)
					return true;
				else return false;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		/// <summary>
		/// Вход в систему
		/// </summary>
		/// <param name="Login"></param>
		/// <param name="Password"></param>
		public bool Login(string Login, string Password)
		{
			try
			{
				if (Data.Login(Login, Password) == true)
					return true;
				else return false;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		/// <summary>
		/// Права пользователя
		/// </summary>
		/// <param name="Login"></param>
		public int UserRole(string Login)
		{
			try
			{
				return Data.UserRole(Login);
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		/// <summary>
		/// Список пользователей
		/// </summary>
		/// <param name=""></param>
		public IEnumerable<UsersDTO> GetUsers()
		{
			try
			{
				List<UsersDTO> Users = new List<UsersDTO>();
				var UsersDAL = Data.GetUsers();

				foreach (var u in UsersDAL)
				{
					UsersDTO user = new UsersDTO();
					user.UserID = u.UserID;
					user.Login = u.Login;
					user.Name = u.Name;
					user.RegistrationDate = u.RegistrationDate;
					user.TypeID = u.TypeID;
					user.UserType = u.UserType;
					user.Avatar = u.Avatar;
					Users.Add(user);
				}
				return Users;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		/// <summary>
		/// Информация об определённом пользователе
		/// </summary>
		/// <param name="UserID"></param>
		public UsersDTO GetUserById(int UserID)
		{
			try
			{
				UsersDTO user = new UsersDTO();
				var UsersDAL = Data.GetUserById(UserID);

				user.UserID = UsersDAL.UserID;
				user.Login = UsersDAL.Login;
				user.Password = UsersDAL.Password;
				user.Name = UsersDAL.Name;
				user.RegistrationDate = UsersDAL.RegistrationDate;
				user.TypeID = UsersDAL.TypeID;
				user.UserType = UsersDAL.UserType;
				user.Avatar = UsersDAL.Avatar;

				return user;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		/// <summary>
		/// Информация о пользователе в онлайне
		/// </summary>
		/// <param name="Login"></param>
		public UsersDTO GetCurentUser(string Login)
		{
			try
			{
				UsersDTO user = new UsersDTO();
				var UsersDAL = Data.GetCurentUser(Login);

				user.UserID = UsersDAL.UserID;
				user.Name = UsersDAL.Name;
				user.Avatar = UsersDAL.Avatar;

				return user; 
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		/// <summary>
		/// Последнее сообщение в теме
		/// </summary>
		/// <param name="TopicID"></param>
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

		/// <summary>
		/// Последнее сообщение в теме, для администратора
		/// </summary>
		/// <param name="TopicID"></param>
		public UsersDTO LastMessageForAdmin(int TopicID)
		{
			try
			{
				UsersDTO Users = new UsersDTO();
				var UserDAL = Data.LastMessageForAdmin(TopicID);

				Users.Name = UserDAL.Name;
				Users.RegistrationDate = UserDAL.RegistrationDate;
				return Users;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		/// <summary>
		/// Разделы на форуме
		/// </summary>
		/// <param name=""></param>
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

		/// <summary>
		/// Темы в разделе
		/// </summary>
		/// <param name="SectionID"></param>
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
					topic.Name = t.Name;
					topic.CreateDate = t.CreateDate;
					topic.MessageCount = t.MessageCount;
					topic.Avatar = t.Avatar;
					Topics.Add(topic);
				}
				return Topics;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		/// <summary>
		/// Темы в разделе, для администратора
		/// </summary>
		/// <param name="SectionID"></param>
		public IEnumerable<TopicsDTO> GetTopicsForAdmin(int SectionID)
		{
			try
			{
				List<TopicsDTO> Topics = new List<TopicsDTO>();
				var TopicDAL = Data.GetTopicsForAdmin(SectionID);

				foreach (var t in TopicDAL)
				{
					TopicsDTO topic = new TopicsDTO();
					topic.TopicID = t.TopicID;
					topic.SectionID = t.SectionID;
					topic.TopicName = t.TopicName;
					topic.Name = t.Name;
					topic.CreateDate = t.CreateDate;
					topic.MessageCount = t.MessageCount;
					topic.Avatar = t.Avatar;
					Topics.Add(topic);
				}
				return Topics;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		/// <summary>
		/// Тема по идентификатору
		/// </summary>
		/// <param name="TopicID"></param>
		public TopicsDTO GetTopicByID(int TopicID)
		{
			try
			{
				TopicsDTO topic = new TopicsDTO();
				var TopicDAL = Data.GetTopicByID(TopicID);

				topic.SectionID = TopicDAL.SectionID;
				topic.TopicID = TopicDAL.TopicID;
				topic.TopicName = TopicDAL.TopicName;
				topic.TopicText = TopicDAL.TopicText;
				topic.Name = TopicDAL.Name;
				topic.CreateDate = TopicDAL.CreateDate;
				topic.Avatar = TopicDAL.Avatar;

				return topic;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		/// <summary>
		/// Сообщения в теме
		/// </summary>
		/// <param name=""></param>
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
					message.Avatar = m.Avatar;

					Messages.Add(message);
				}
				return Messages;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		/// <summary>
		/// Создать тему
		/// </summary>
		/// <param name="topic"></param>
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

				if (Data.CreateTopic(TopicDAL) == true)
					return true;
				else return false;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		/// <summary>
		/// Создать сообщение
		/// </summary>
		/// <param name="message"></param>
		public bool CreateMessage(MessagesDTO message)
		{
			try
			{
				Messages MessageDAL = new Messages();
				MessageDAL.TopicID = message.TopicID;
				MessageDAL.Text = message.Text;
				MessageDAL.SendDate = DateTime.Now;
				MessageDAL.UserID = message.UserID;

				if (Data.CreateMessage(MessageDAL) == true)
					return true;
				else return false;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		/// <summary>
		/// Создать раздел, для администратора
		/// </summary>
		/// <param name="sectionName"></param>
		public bool CreateSection(string sectionName)
		{
			try
			{
				if (Data.CreateSection(sectionName) == true)
					return true;
				else return false;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		/// <summary>
		/// Изменить данные пользователя, для администратора
		/// </summary>
		/// <param name="user"></param>
		public bool ChangeUserType(UsersDTO user)
		{
			try
			{
				Users userDAL = new Users();
				userDAL.UserID = user.UserID;
				userDAL.Login = user.Login;
				userDAL.Password = user.Password;
				userDAL.Name = user.Name;
				userDAL.RegistrationDate = user.RegistrationDate;
				userDAL.TypeID = user.TypeID;
				userDAL.Avatar = user.Avatar;
				if (Data.ChangeUserType(userDAL) == true)
					return true;
				else return false;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		/// <summary>
		/// Изменить видимость сообщения
		/// </summary>
		/// <param name="MessageID"></param>
		/// <param name="StatusID"></param>
		public bool ChangeMessageStatus(int MessageID, int StatusID)
		{
			try
			{
				if (Data.ChangeMessageStatus(MessageID, StatusID) == true)
					return true;
				else return false;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		public bool DropMessage(int MessageID)
		{
			try
			{
				if (Data.DropMessage(MessageID) == false)
					return true;
				else return false;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		public bool DropTopic(int TopicID)
		{
			try
			{
				if (Data.DropTopic(TopicID) == false)
					return true;
				else return false;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		public bool DropSection(int SectionID)
		{
			try
			{
				if (Data.DropSection(SectionID) == false)
					return true;
				else return false;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}

		public bool ChangeAvatar(int UserID, string Avatar)
		{
			try
			{
				if (Data.ChangeAvatar(UserID, Avatar) == false)
					return true;
				else return false;
			}
			catch (ArgumentException ex)
			{
				throw new ValidationException(ex.Message, ex.ParamName);
			}
		}
	}
}

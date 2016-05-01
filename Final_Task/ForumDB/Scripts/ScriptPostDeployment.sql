DELETE FROM [dbo].[MsgStatus];
DELETE FROM [dbo].[UserTypes];
DELETE FROM [dbo].[Users];
DELETE FROM [dbo].[Sections];
DELETE FROM [dbo].[Topics];
DELETE FROM [dbo].[Messages];

:r .\MsgStatus.sql
:r .\UserTypes.sql
:r .\Users.sql
:r .\Sections.sql
:r .\Topics.sql
:r .\Messages.sql

/*SELECT * FROM [Sections];
SELECT * FROM [dbo].[Users];
SELECT * FROM [dbo].[UserTypes];
SELECT * FROM [dbo].[Topics];
SELECT * FROM [dbo].[Messages];
SELECT * FROM [dbo].[MsgStatus];

DELETE FROM [dbo].[Users] WHERE UserID = 6;

INSERT INTO dbo.Users (Name, Login, Password, RegistrationDate) VALUES ('Test', N'TTTTTTT', N'DFsdfsf', CURRENT_TIMESTAMP);

SELECT SectionID, SetionName FROM dbo.Sections
SELECT t.TopicID, t.SectionID, t.TopicName, t.TopicText, t.CreateDate, u.Name,
(SELECT COUNT(MessageID) FROM dbo.Messages WHERE TopicID = t.TopicID) as mc FROM dbo.Topics as t 
INNER JOIN dbo.Users as u ON u.UserID = t.USERID
WHERE t.SectionID = 1
GROUP BY t.TopicID

SELECT m.MessageID, m.TopicID, m.SendDate, m.Text, m.StatusID, u.Name, u.RegistrationDate
FROM dbo.Messages as m INNER JOIN dbo.Users as u ON m.UserID = u.UserID WHERE m.TopicID = @TopicID

UPDATE dbo.Users SET TypeID = 0 WHERE UserID = 3
DECLARE @A nvarchar(20) = 'Admin'
select Login from dbo.Users where Login like @A

SELECT TOP(1) u.Name, m.SendDate FROM dbo.Messages as m INNER JOIN dbo.Users as u ON m.UserID = u.UserID WHERE m.TopicID = 1 ORDER BY SendDate ASC

SELECT t.SectionID, t.TopicName, t.CreateDate, u.Name, (SELECT COUNT(MessageID)
 FROM dbo.Messages WHERE TopicID = t.TopicID) as MessageCount FROM dbo.Topics as t
  INNER JOIN dbo.Users as u ON u.UserID = t.UserID WHERE t.SectionID = @SectionID



*/


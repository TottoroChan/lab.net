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
SELECT * FROM [dbo].[MsgStatus];*/
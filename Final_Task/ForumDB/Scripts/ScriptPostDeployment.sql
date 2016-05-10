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
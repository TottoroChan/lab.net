CREATE TABLE [dbo].[Users]
(
	[UserID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] NCHAR(16) NOT NULL, 
    [RegistrationDate] DATE NOT NULL , 
    [Login] NVARCHAR(20) NOT NULL, 
    [Password] NVARCHAR(20) NOT NULL, 
    [TypeID] INT NOT NULL DEFAULT 2, 
    [Avatar] NVARCHAR(MAX) NOT NULL DEFAULT 'http://mydermatolog.ru/sites/default/files/pictures/userdef.jpg', 
    CONSTRAINT [FK_Users_UserTypes] FOREIGN KEY (TypeID) REFERENCES UserTypes(TypeID) 
)

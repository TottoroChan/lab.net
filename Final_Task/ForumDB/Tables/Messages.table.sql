CREATE TABLE [dbo].[Messages]
(
	[MessageID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [TopicID] INT NOT NULL, 
    [UserID] INT NOT NULL, 
    [SendDate] DATETIME NOT NULL, 
    [Text] NVARCHAR(MAX) NOT NULL, 
    [StatusID] INT NOT NULL DEFAULT 0, 
)

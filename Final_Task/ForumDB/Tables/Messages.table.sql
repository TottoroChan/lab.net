CREATE TABLE [dbo].[Messages]
(
	[MessageID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [TopicID] INT NOT NULL, 
    [UserID] INT NOT NULL, 
    [SendDate] DATETIME NOT NULL, 
    [Text] NVARCHAR(MAX) NOT NULL, 
    [StatusID] INT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Messages_Topics] FOREIGN KEY (TopicID) REFERENCES Topics(TopicID), 
    CONSTRAINT [FK_Messages_Users] FOREIGN KEY (UserID) REFERENCES Users(UserID), 
    CONSTRAINT [FK_Messages_MsgStatus] FOREIGN KEY (StatusID) REFERENCES MsgStatus(StatusID)
)

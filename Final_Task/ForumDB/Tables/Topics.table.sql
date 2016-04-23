CREATE TABLE [dbo].[Topics]
(
	[TopicID] INT IDENTITY(1,1) NOT NULL , 
    [SectionID] INT NOT NULL, 
    [TopicName] NVARCHAR(50) NULL, 
    [TopicText] NVARCHAR(MAX) NOT NULL, 
    [UserID] INT NOT NULL, 
    [CreateDate] DATETIME NOT NULL, 
    PRIMARY KEY ([TopicID]), 
    CONSTRAINT [FK_Topics_Sections] FOREIGN KEY (SectionID) REFERENCES Sections(SectionID), 
    CONSTRAINT [FK_Topics_Users] FOREIGN KEY (UserID) REFERENCES Users(UserID)
)

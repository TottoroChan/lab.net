CREATE TABLE [dbo].[Topics]
(
	[TopicID] INT IDENTITY(1,1) NOT NULL , 
    [SectionID] INT NOT NULL, 
    [TopicName] NVARCHAR(50) NULL, 
    [TopicText] NVARCHAR(MAX) NOT NULL, 
    [UserID] INT NOT NULL, 
    [CreateDate] DATETIME NOT NULL, 
    PRIMARY KEY ([TopicID])
)

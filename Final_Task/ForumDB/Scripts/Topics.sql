SET IDENTITY_INSERT [dbo].[Topics] ON
INSERT INTO [dbo].[Topics] ([TopicID], [SectionID], [TopicName], [TopicText], [CreateDate], [UserID]) VALUES (1, 1, N'First topic', N'The first topic in the section', CURRENT_TIMESTAMP, 1);
INSERT INTO [dbo].[Topics] ([TopicID], [SectionID], [TopicName], [TopicText], [CreateDate], [UserID]) VALUES (2, 1, N'Second topic', N'The second topic in the section', CURRENT_TIMESTAMP, 3);
INSERT INTO [dbo].[Topics] ([TopicID], [SectionID], [TopicName], [TopicText], [CreateDate], [UserID]) VALUES (3, 1, N'Third topic', N'The third topic in the section', CURRENT_TIMESTAMP, 5);
SET IDENTITY_INSERT [dbo].[Topics] OFF
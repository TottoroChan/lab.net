SET IDENTITY_INSERT [dbo].[Messages] ON
INSERT INTO [dbo].[Messages] ([MessageID], [TopicID], [UserID], [SendDate], [Text], [StatusID]) VALUES (1, 1, 2, CURRENT_TIMESTAMP, N'The first answer to the topic', 1);
INSERT INTO [dbo].[Messages] ([MessageID], [TopicID], [UserID], [SendDate], [Text], [StatusID]) VALUES (2, 1, 3, CURRENT_TIMESTAMP, N'The second answer to the topic', 1);
INSERT INTO [dbo].[Messages] ([MessageID], [TopicID], [UserID], [SendDate], [Text], [StatusID]) VALUES (3, 1, 4, CURRENT_TIMESTAMP, N'The third answer to the topic', 1);
INSERT INTO [dbo].[Messages] ([MessageID], [TopicID], [UserID], [SendDate], [Text], [StatusID]) VALUES (4, 1, 2, CURRENT_TIMESTAMP, N'The fourth answer to the topic', 1);
INSERT INTO [dbo].[Messages] ([MessageID], [TopicID], [UserID], [SendDate], [Text], [StatusID]) VALUES (5, 1, 5, CURRENT_TIMESTAMP, N'The fifth answer to the topic', 1);
INSERT INTO [dbo].[Messages] ([MessageID], [TopicID], [UserID], [SendDate], [Text], [StatusID]) VALUES (6, 1, 1, CURRENT_TIMESTAMP, N'The sixth answer to the topic', 0);
INSERT INTO [dbo].[Messages] ([MessageID], [TopicID], [UserID], [SendDate], [Text], [StatusID]) VALUES (7, 1, 2, CURRENT_TIMESTAMP, N'The seventh answer to the topic', 0);
SET IDENTITY_INSERT [dbo].[Messages] OFF
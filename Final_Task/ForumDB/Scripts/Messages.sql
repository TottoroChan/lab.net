SET IDENTITY_INSERT [dbo].[Messages] ON
INSERT INTO [dbo].[Messages] ([MessageID], [TopicID], [UserID], [SendDate], [Text], [StatusID]) VALUES (1, 1, 2, CURRENT_TIMESTAMP, N'Первое сообщение', 1);
INSERT INTO [dbo].[Messages] ([MessageID], [TopicID], [UserID], [SendDate], [Text], [StatusID]) VALUES (2, 1, 3, CURRENT_TIMESTAMP, N'Второе сообщение', 1);
INSERT INTO [dbo].[Messages] ([MessageID], [TopicID], [UserID], [SendDate], [Text], [StatusID]) VALUES (3, 1, 4, CURRENT_TIMESTAMP, N'Третье сообщение', 0);
INSERT INTO [dbo].[Messages] ([MessageID], [TopicID], [UserID], [SendDate], [Text], [StatusID]) VALUES (4, 1, 2, CURRENT_TIMESTAMP, N'Четвёртое сообщение, а третье невидимое', 1);
INSERT INTO [dbo].[Messages] ([MessageID], [TopicID], [UserID], [SendDate], [Text], [StatusID]) VALUES (5, 2, 5, CURRENT_TIMESTAMP, N'Видимое первое', 1);
INSERT INTO [dbo].[Messages] ([MessageID], [TopicID], [UserID], [SendDate], [Text], [StatusID]) VALUES (6, 2, 1, CURRENT_TIMESTAMP, N'Невидимое второе', 0);
INSERT INTO [dbo].[Messages] ([MessageID], [TopicID], [UserID], [SendDate], [Text], [StatusID]) VALUES (7, 3, 2, CURRENT_TIMESTAMP, N'Невидимое первое сообщение', 0);
SET IDENTITY_INSERT [dbo].[Messages] OFF
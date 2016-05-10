SET IDENTITY_INSERT [dbo].[Topics] ON
INSERT INTO [dbo].[Topics] ([TopicID], [SectionID], [TopicName], [TopicText], [CreateDate], [UserID]) VALUES (1, 1, N'Первая тема', N'Первая тестовая тема форума', CURRENT_TIMESTAMP, 1);
INSERT INTO [dbo].[Topics] ([TopicID], [SectionID], [TopicName], [TopicText], [CreateDate], [UserID]) VALUES (2, 1, N'вторая ТЕМА', N'Тестовое сообщение второй темы', CURRENT_TIMESTAMP, 3);
INSERT INTO [dbo].[Topics] ([TopicID], [SectionID], [TopicName], [TopicText], [CreateDate], [UserID]) VALUES (3, 1, N'Три', N'Третий тест', CURRENT_TIMESTAMP, 5);
SET IDENTITY_INSERT [dbo].[Topics] OFF
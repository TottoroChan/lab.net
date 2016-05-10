SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([UserID], [Name], [Login], [Password], [RegistrationDate], [TypeID], [Avatar]) VALUES (1, N'Администратор', N'Admin', N'admin1', CURRENT_TIMESTAMP, 1, N'http://www.gmnet.ru/forums/customavatars/avatar22582_2.gif');
INSERT INTO [dbo].[Users] ([UserID], [Name], [Login], [Password], [RegistrationDate], [TypeID], [Avatar]) VALUES (2, N'Первый', N'First', N'first1', CURRENT_TIMESTAMP, 2, N'http://union.4bb.ru/img/avatars/0000/38/bf/326-1434804046.gif');
INSERT INTO [dbo].[Users] ([UserID], [Name], [Login], [Password], [RegistrationDate], [TypeID], [Avatar]) VALUES (3, N'Второй', N'Second', N'second22', CURRENT_TIMESTAMP, 0, N'http://forum.tera-online.cc/customavatars/avatar1068_4.gif');
INSERT INTO [dbo].[Users] ([UserID], [Name], [Login], [Password], [RegistrationDate], [TypeID]) VALUES (4, N'Третий', N'Third', N'third333', CURRENT_TIMESTAMP, 2);
INSERT INTO [dbo].[Users] ([UserID], [Name], [Login], [Password], [RegistrationDate], [TypeID]) VALUES (5, N'Четвёртый', N'Fourth', N'fourth4444', CURRENT_TIMESTAMP, 2);
SET IDENTITY_INSERT [dbo].[Users] OFF

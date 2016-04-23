SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([UserID], [Name], [Login], [Password], [RegistrationDate], [TypeID]) VALUES (1, N'Administrator', N'Admin', N'admin1', CURRENT_TIMESTAMP, 1);
INSERT INTO [dbo].[Users] ([UserID], [Name], [Login], [Password], [RegistrationDate], [TypeID]) VALUES (2, N'FirstUser', N'First', N'first1', CURRENT_TIMESTAMP, 2);
INSERT INTO [dbo].[Users] ([UserID], [Name], [Login], [Password], [RegistrationDate], [TypeID]) VALUES (3, N'SecondUser', N'Second', N'second22', CURRENT_TIMESTAMP, 0);
INSERT INTO [dbo].[Users] ([UserID], [Name], [Login], [Password], [RegistrationDate], [TypeID]) VALUES (4, N'ThirdUser', N'Third', N'third333', CURRENT_TIMESTAMP, 2);
INSERT INTO [dbo].[Users] ([UserID], [Name], [Login], [Password], [RegistrationDate], [TypeID]) VALUES (5, N'FourthUser', N'Fourth', N'fourth4444', CURRENT_TIMESTAMP, 2);
SET IDENTITY_INSERT [dbo].[Users] OFF

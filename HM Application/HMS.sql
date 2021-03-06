create database HMS
go
Use HMS
go

/****** Object:  Table [dbo].[ROLES]    Script Date: 20-11-2018 08:25:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROLES](
	[Role_Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[RoleDescription] [nvarchar](250) NULL,
 CONSTRAINT [PK_tbl_Roles] PRIMARY KEY CLUSTERED 
(
	[Role_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Room]    Script Date: 20-11-2018 08:25:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNumber] [varchar](15) NOT NULL,
	[RoomType] [int] NOT NULL,
	[TV] [bit] NOT NULL,
	[HotWater] [bit] NOT NULL,
	[Towel] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_tbl_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_RoomBooking]    Script Date: 20-11-2018 08:25:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_RoomBooking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomId] [int] NOT NULL,
	[FromDate] [date] NOT NULL,
	[ToDate] [date] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_tbl_RoomBooking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_RoomType]    Script Date: 20-11-2018 08:25:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_RoomType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_RoomType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Staff]    Script Date: 20-11-2018 08:25:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Staff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](15) NULL,
	[Address] [varchar](100) NULL,
	[Salary] [int] NULL,
	[Category] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_Staff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_StaffCategory]    Script Date: 20-11-2018 08:25:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_StaffCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_StaffCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 20-11-2018 08:25:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 20-11-2018 08:25:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERS](
	[User_Id] [int] IDENTITY(1,1) NOT NULL,
	[EMail] [nvarchar](100) NULL,
	[Password] [varchar](500) NULL,
 CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ROLES] ON 

INSERT [dbo].[ROLES] ([Role_Id], [RoleName], [RoleDescription]) VALUES (1, N'Admin', NULL)
INSERT [dbo].[ROLES] ([Role_Id], [RoleName], [RoleDescription]) VALUES (2, N'User', NULL)
SET IDENTITY_INSERT [dbo].[ROLES] OFF
SET IDENTITY_INSERT [dbo].[tbl_Room] ON 

INSERT [dbo].[tbl_Room] ([Id], [RoomNumber], [RoomType], [TV], [HotWater], [Towel], [IsDeleted], [IsAvailable], [Price]) VALUES (1, N'sdf', 1, 1, 0, 1, 1, 1, NULL)
INSERT [dbo].[tbl_Room] ([Id], [RoomNumber], [RoomType], [TV], [HotWater], [Towel], [IsDeleted], [IsAvailable], [Price]) VALUES (2, N'A 418', 1, 1, 1, 0, 0, 1, 200)
INSERT [dbo].[tbl_Room] ([Id], [RoomNumber], [RoomType], [TV], [HotWater], [Towel], [IsDeleted], [IsAvailable], [Price]) VALUES (3, N'B 15', 2, 1, 1, 1, 0, 1, 500)
SET IDENTITY_INSERT [dbo].[tbl_Room] OFF
SET IDENTITY_INSERT [dbo].[tbl_RoomBooking] ON 

INSERT [dbo].[tbl_RoomBooking] ([Id], [RoomId], [FromDate], [ToDate], [UserId]) VALUES (5, 1, CAST(N'2018-11-24' AS Date), CAST(N'2018-11-30' AS Date), 1)
SET IDENTITY_INSERT [dbo].[tbl_RoomBooking] OFF
SET IDENTITY_INSERT [dbo].[tbl_RoomType] ON 

INSERT [dbo].[tbl_RoomType] ([Id], [Name]) VALUES (1, N'AC')
INSERT [dbo].[tbl_RoomType] ([Id], [Name]) VALUES (2, N'Without AC')
SET IDENTITY_INSERT [dbo].[tbl_RoomType] OFF
SET IDENTITY_INSERT [dbo].[tbl_Staff] ON 

INSERT [dbo].[tbl_Staff] ([Id], [Name], [PhoneNumber], [Address], [Salary], [Category], [IsDeleted]) VALUES (1, N'test1', N'sdf1', N'sdf1', 12321, 11, 1)
INSERT [dbo].[tbl_Staff] ([Id], [Name], [PhoneNumber], [Address], [Salary], [Category], [IsDeleted]) VALUES (2, N'test', N'jh', N'sdf', 1, 1, 1)
INSERT [dbo].[tbl_Staff] ([Id], [Name], [PhoneNumber], [Address], [Salary], [Category], [IsDeleted]) VALUES (3, N'sdf', N'sd', N'df', 2, 1, 1)
INSERT [dbo].[tbl_Staff] ([Id], [Name], [PhoneNumber], [Address], [Salary], [Category], [IsDeleted]) VALUES (4, N'g', N'f', N'f', 5, 2, 1)
INSERT [dbo].[tbl_Staff] ([Id], [Name], [PhoneNumber], [Address], [Salary], [Category], [IsDeleted]) VALUES (5, N'Ram lal thakur', N'65465465465165', N'5456654165166516', 12442, 4, 1)
INSERT [dbo].[tbl_Staff] ([Id], [Name], [PhoneNumber], [Address], [Salary], [Category], [IsDeleted]) VALUES (6, N'test', N'65465465465165', N'sdf', 100, 1, 0)
SET IDENTITY_INSERT [dbo].[tbl_Staff] OFF
SET IDENTITY_INSERT [dbo].[tbl_StaffCategory] ON 

INSERT [dbo].[tbl_StaffCategory] ([Id], [Name]) VALUES (1, N'Chef')
INSERT [dbo].[tbl_StaffCategory] ([Id], [Name]) VALUES (2, N'House Keeping')
INSERT [dbo].[tbl_StaffCategory] ([Id], [Name]) VALUES (3, N'Bell Boy')
INSERT [dbo].[tbl_StaffCategory] ([Id], [Name]) VALUES (4, N'Gate Keeper')
SET IDENTITY_INSERT [dbo].[tbl_StaffCategory] OFF
SET IDENTITY_INSERT [dbo].[UserRoles] ON 

INSERT [dbo].[UserRoles] ([Id], [UserId], [RoleId]) VALUES (2, 1, 1)
INSERT [dbo].[UserRoles] ([Id], [UserId], [RoleId]) VALUES (3, 2, 2)
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
SET IDENTITY_INSERT [dbo].[USERS] ON 

INSERT [dbo].[USERS] ([User_Id], [EMail], [Password]) VALUES (1, N'admin@xyz.com', N'Test@123')
INSERT [dbo].[USERS] ([User_Id], [EMail], [Password]) VALUES (2, N'user@xyz.com', N'Test@123')
SET IDENTITY_INSERT [dbo].[USERS] OFF
ALTER TABLE [dbo].[tbl_Room] ADD  CONSTRAINT [DF_tbl_Room_TV]  DEFAULT ((0)) FOR [TV]
GO
ALTER TABLE [dbo].[tbl_Room] ADD  CONSTRAINT [DF_tbl_Room_HotWater]  DEFAULT ((0)) FOR [HotWater]
GO
ALTER TABLE [dbo].[tbl_Room] ADD  CONSTRAINT [DF_tbl_Room_Towel]  DEFAULT ((0)) FOR [Towel]
GO
ALTER TABLE [dbo].[tbl_Room] ADD  CONSTRAINT [DF_tbl_Room_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tbl_Room] ADD  CONSTRAINT [DF_tbl_Room_IsAvailable]  DEFAULT ((0)) FOR [IsAvailable]
GO
ALTER TABLE [dbo].[tbl_Staff] ADD  CONSTRAINT [DF_tbl_Staff_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tbl_RoomBooking]  WITH CHECK ADD FOREIGN KEY([RoomId])
REFERENCES [dbo].[tbl_Room] ([Id])
GO
ALTER TABLE [dbo].[tbl_RoomBooking]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[USERS] ([User_Id])
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_ROLES] FOREIGN KEY([RoleId])
REFERENCES [dbo].[ROLES] ([Role_Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_ROLES]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_USERS] FOREIGN KEY([UserId])
REFERENCES [dbo].[USERS] ([User_Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_USERS]
GO

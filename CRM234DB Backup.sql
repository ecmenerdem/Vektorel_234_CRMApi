create database [CRM234DB]
go
USE [CRM234DB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2.11.2024 18:04:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2.11.2024 18:04:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[Comments] [nvarchar](max) NULL,
	[AddedTime] [datetime2](7) NOT NULL,
	[AddedUser] [int] NOT NULL,
	[AddedIP] [nvarchar](max) NULL,
	[UpdatedTime] [datetime2](7) NOT NULL,
	[UpdatedUser] [int] NOT NULL,
	[UpdatedIP] [nvarchar](max) NULL,
	[guid] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 2.11.2024 18:04:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[Comments] [nvarchar](max) NULL,
	[AddedTime] [datetime2](7) NOT NULL,
	[AddedUser] [int] NOT NULL,
	[AddedIP] [nvarchar](max) NULL,
	[UpdatedTime] [datetime2](7) NOT NULL,
	[UpdatedUser] [int] NOT NULL,
	[UpdatedIP] [nvarchar](max) NULL,
	[guid] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2.11.2024 18:04:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CategoryID] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[Comments] [nvarchar](max) NULL,
	[AddedTime] [datetime2](7) NOT NULL,
	[AddedUser] [int] NOT NULL,
	[AddedIP] [nvarchar](max) NULL,
	[UpdatedTime] [datetime2](7) NOT NULL,
	[UpdatedUser] [int] NOT NULL,
	[UpdatedIP] [nvarchar](max) NULL,
	[guid] [uniqueidentifier] NULL,
	[ProductImage] [nvarchar](max) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2.11.2024 18:04:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[GroupID] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[Comments] [nvarchar](max) NULL,
	[AddedTime] [datetime2](7) NOT NULL,
	[AddedUser] [int] NOT NULL,
	[AddedIP] [nvarchar](max) NULL,
	[UpdatedTime] [datetime2](7) NOT NULL,
	[UpdatedUser] [int] NOT NULL,
	[UpdatedIP] [nvarchar](max) NULL,
	[guid] [uniqueidentifier] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240901123655_m1', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240901124844_m2', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240908141752_m3', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240915111919_m4', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240915113824_m5', N'8.0.8')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241102112728_M6', N'8.0.8')
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([id], [Name], [IsActive], [IsDeleted], [Comments], [AddedTime], [AddedUser], [AddedIP], [UpdatedTime], [UpdatedUser], [UpdatedIP], [guid]) VALUES (2, N'Elektronik', 1, 0, NULL, CAST(N'2024-10-27T00:00:00.0000000' AS DateTime2), 1, N'::1', CAST(N'2024-10-27T00:00:00.0000000' AS DateTime2), 1, N'::1', N'e2a04832-ec28-4d9f-af21-6332670d997a')
GO
INSERT [dbo].[Category] ([id], [Name], [IsActive], [IsDeleted], [Comments], [AddedTime], [AddedUser], [AddedIP], [UpdatedTime], [UpdatedUser], [UpdatedIP], [guid]) VALUES (3, N'Giyim', 1, 0, NULL, CAST(N'2024-10-27T00:00:00.0000000' AS DateTime2), 1, N'::1', CAST(N'2024-10-27T00:00:00.0000000' AS DateTime2), 1, N'::1', N'54996069-e6dd-4870-9a5b-3d59111899f2')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Group] ON 
GO
INSERT [dbo].[Group] ([id], [Name], [IsActive], [IsDeleted], [Comments], [AddedTime], [AddedUser], [AddedIP], [UpdatedTime], [UpdatedUser], [UpdatedIP], [guid]) VALUES (1, N'Admin', 1, 0, N'', CAST(N'2024-09-29T14:19:50.6161905' AS DateTime2), 1, N'::1', CAST(N'2024-09-29T14:19:50.6218624' AS DateTime2), 1, N'::1', N'8e40207c-9452-49a1-adf4-8e8a2900f2a9')
GO
INSERT [dbo].[Group] ([id], [Name], [IsActive], [IsDeleted], [Comments], [AddedTime], [AddedUser], [AddedIP], [UpdatedTime], [UpdatedUser], [UpdatedIP], [guid]) VALUES (2, N'Muhasebe', 1, 0, N'', CAST(N'2024-09-29T14:19:57.0975608' AS DateTime2), 1, N'::1', CAST(N'2024-09-29T14:19:57.0975789' AS DateTime2), 1, N'::1', N'df83a32a-5e86-4fb8-b632-17ca924f9bd2')
GO
INSERT [dbo].[Group] ([id], [Name], [IsActive], [IsDeleted], [Comments], [AddedTime], [AddedUser], [AddedIP], [UpdatedTime], [UpdatedUser], [UpdatedIP], [guid]) VALUES (3, N'Grafik Tasarım', 1, 0, N'', CAST(N'2024-10-20T16:56:01.3408128' AS DateTime2), 1, N'::1', CAST(N'2024-10-20T16:56:01.3416471' AS DateTime2), 1, N'::1', N'0ce29d18-7d2b-4c57-ba6b-cd27b77dd4bd')
GO
SET IDENTITY_INSERT [dbo].[Group] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([id], [Name], [Description], [CategoryID], [IsActive], [IsDeleted], [Comments], [AddedTime], [AddedUser], [AddedIP], [UpdatedTime], [UpdatedUser], [UpdatedIP], [guid], [ProductImage]) VALUES (1, N'IPhone 17', N'gjkjhkjhkjhk', 2, 1, 0, NULL, CAST(N'2024-11-02T16:35:32.3954932' AS DateTime2), 1, N'::1', CAST(N'2024-11-02T16:35:32.3968337' AS DateTime2), 1, N'::1', N'554cfc7f-de41-466a-a56c-ea8ed681f13b', N'images_489bf7bb-aa06-474e-a8d4-d464ead0aa2a.jpeg')
GO
INSERT [dbo].[Product] ([id], [Name], [Description], [CategoryID], [IsActive], [IsDeleted], [Comments], [AddedTime], [AddedUser], [AddedIP], [UpdatedTime], [UpdatedUser], [UpdatedIP], [guid], [ProductImage]) VALUES (2, N'Dyson V15', N'Submarine™ ıslak temizleme başlığı, sert zeminlerde ıslak temizlik yapar.', 2, 1, 0, NULL, CAST(N'2024-11-02T16:40:10.4529351' AS DateTime2), 1, N'::1', CAST(N'2024-11-02T16:40:10.4529604' AS DateTime2), 1, N'::1', N'eda8fb9a-ae53-4d2a-815d-846f5d2caaeb', N'448798-01_ef4b27b7-3d0f-4854-8ff8-9d5ec7e7da9b.jpeg')
GO
INSERT [dbo].[Product] ([id], [Name], [Description], [CategoryID], [IsActive], [IsDeleted], [Comments], [AddedTime], [AddedUser], [AddedIP], [UpdatedTime], [UpdatedUser], [UpdatedIP], [guid], [ProductImage]) VALUES (3, N'IPhone 17', N'<p>fsdfsdfsdf<iframe frameborder="0" src="//www.youtube.com/embed/4iWGXjPQzzc" width="640" height="360" class="note-video-clip"></iframe></p>', 2, 1, 0, NULL, CAST(N'2024-11-02T17:00:32.7845993' AS DateTime2), 1, N'::1', CAST(N'2024-11-02T17:00:32.7902199' AS DateTime2), 1, N'::1', N'6eadf6f3-27dc-4add-9b15-b4ad1c734952', N'448798-01_ad03ca04-4377-41f2-b10f-c6e9e835a843.jpeg')
GO
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([id], [FirstName], [LastName], [Username], [Password], [Email], [GroupID], [IsActive], [IsDeleted], [Comments], [AddedTime], [AddedUser], [AddedIP], [UpdatedTime], [UpdatedUser], [UpdatedIP], [guid]) VALUES (1, N'Ecmen', N'Erdem', N'ecmen', N'12345', N'asdasd@asd.com', 1, 1, 0, NULL, CAST(N'2024-09-29T14:22:47.8651681' AS DateTime2), 1, N'::1', CAST(N'2024-10-27T16:45:06.7119333' AS DateTime2), 1, N'::1', N'fc054270-3611-4130-b791-609c8f068642')
GO
INSERT [dbo].[User] ([id], [FirstName], [LastName], [Username], [Password], [Email], [GroupID], [IsActive], [IsDeleted], [Comments], [AddedTime], [AddedUser], [AddedIP], [UpdatedTime], [UpdatedUser], [UpdatedIP], [guid]) VALUES (4, N'Kamil', N'Hüseyinli', N'kamil', N'12345', N'kamil@kamil.com', 3, 1, 0, NULL, CAST(N'2024-09-29T14:22:47.8651681' AS DateTime2), 1, N'::1', CAST(N'2024-10-26T17:28:31.8129747' AS DateTime2), 1, N'::1', N'5e066431-44fa-4e6f-abf5-699a989f20a1')
GO
INSERT [dbo].[User] ([id], [FirstName], [LastName], [Username], [Password], [Email], [GroupID], [IsActive], [IsDeleted], [Comments], [AddedTime], [AddedUser], [AddedIP], [UpdatedTime], [UpdatedUser], [UpdatedIP], [guid]) VALUES (7, N'Hasret', N'Ünal', N'hasret', N'123456', N'hasret@hasret.com', 2, 1, 0, NULL, CAST(N'2024-09-29T00:00:00.0000000' AS DateTime2), 1, N'::1', CAST(N'2024-10-26T15:52:57.1377477' AS DateTime2), 1, N'::1', N'3e8d1200-1f68-4aa6-99d0-4f242c300c3d')
GO
INSERT [dbo].[User] ([id], [FirstName], [LastName], [Username], [Password], [Email], [GroupID], [IsActive], [IsDeleted], [Comments], [AddedTime], [AddedUser], [AddedIP], [UpdatedTime], [UpdatedUser], [UpdatedIP], [guid]) VALUES (8, N'Ayşe', N'Fatma', N'aysefatma', N'12345', N'aysefatma@ayse.com', 2, 1, 0, NULL, CAST(N'2024-10-26T17:36:11.6925812' AS DateTime2), 1, N'::1', CAST(N'2024-10-26T17:36:11.6927107' AS DateTime2), 1, N'::1', N'ee61ae45-7932-47fb-828a-1ac1391fae0b')
GO
INSERT [dbo].[User] ([id], [FirstName], [LastName], [Username], [Password], [Email], [GroupID], [IsActive], [IsDeleted], [Comments], [AddedTime], [AddedUser], [AddedIP], [UpdatedTime], [UpdatedUser], [UpdatedIP], [guid]) VALUES (9, N'Mehmet Akif', N'Şahin', N'mehmetakif', N'12345', N'mehmet@akiiiiif.com', 1, 1, 0, NULL, CAST(N'2024-10-26T17:37:37.0243157' AS DateTime2), 1, N'::1', CAST(N'2024-10-27T14:20:31.9781234' AS DateTime2), 1, N'::1', N'571f34f6-0208-42ee-8773-6e6e93ce684b')
GO
INSERT [dbo].[User] ([id], [FirstName], [LastName], [Username], [Password], [Email], [GroupID], [IsActive], [IsDeleted], [Comments], [AddedTime], [AddedUser], [AddedIP], [UpdatedTime], [UpdatedUser], [UpdatedIP], [guid]) VALUES (18, N'fatma', N'çolak', N'fatmaaaa', N'12345', N'fatma@colak.com', 2, 1, 0, NULL, CAST(N'2024-10-27T16:04:19.2536089' AS DateTime2), 1, N'::1', CAST(N'2024-10-27T16:04:19.2536200' AS DateTime2), 1, N'::1', N'b193df84-7a15-4a31-ba2d-4d579d7a0437')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category_CategoryID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category_CategoryID]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Group_GroupID] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Group_GroupID]
GO
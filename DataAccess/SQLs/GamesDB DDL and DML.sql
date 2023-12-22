use master
go
if exists (select name from sys.databases where name = 'GamesDB')
begin
	alter database GamesDB set single_user with rollback immediate
	drop database GamesDB
end
go
create database GamesDB
go
USE [GamesDB]
GO
/****** Object:  Table [dbo].[Games]    Script Date: 2.12.2023 19:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [nvarchar](max),
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[PublishDate] [datetime] NULL,
	[Price] [decimal](9, 2) NOT NULL,
	[DownloadCount] [bigint] NULL,
	[PlayerCountType] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[PublisherId] [int] NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publishers]    Script Date: 2.12.2023 19:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publishers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [nvarchar](max),
	[Name] [nvarchar](75) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2.12.2023 19:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [nvarchar](max) NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGames]    Script Date: 2.12.2023 19:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGames](
	[UserId] [int] NOT NULL,
	[GameId] [int] NOT NULL,
 CONSTRAINT [PK_UserGames] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[GameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2.12.2023 19:20:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Guid] [nvarchar](max) NULL,
	[UserName] [nvarchar](15) NOT NULL,
	[Password] [nvarchar](10) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[BirthDate] [datetime2](7) NOT NULL,
	[Sex] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Games] ON 
GO
INSERT [dbo].[Games] ([Id], [Name], [Description], [PublishDate], [Price], [DownloadCount], [PlayerCountType], [IsDeleted], [PublisherId]) VALUES (2, N'GTA V', NULL, CAST(N'2012-05-12T00:00:00.000' AS DateTime), CAST(30.00 AS Decimal(9, 2)), 250000000, 3, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[Games] OFF
GO
SET IDENTITY_INSERT [dbo].[Publishers] ON 
GO
INSERT [dbo].[Publishers] ([Id], [Name]) VALUES (1, N'Rockstar Games')
GO
SET IDENTITY_INSERT [dbo].[Publishers] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([Id], [Guid], [Name]) VALUES (1, NULL, N'Admin')
GO
INSERT [dbo].[Roles] ([Id], [Guid], [Name]) VALUES (2, NULL, N'User')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
INSERT [dbo].[UserGames] ([UserId], [GameId]) VALUES (1, 2)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Guid], [UserName], [Password], [IsActive], [BirthDate], [Sex], [RoleId]) VALUES (1, NULL, N'cagil', N'cagil', 1, CAST(N'1980-05-27T00:00:00.0000000' AS DateTime2), 2, 1)
GO
INSERT [dbo].[Users] ([Id], [Guid], [UserName], [Password], [IsActive], [BirthDate], [Sex], [RoleId]) VALUES (2, NULL, N'luna', N'luna', 1, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), 1, 2)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_Publishers] FOREIGN KEY([PublisherId])
REFERENCES [dbo].[Publishers] ([Id])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_Games_Publishers]
GO
ALTER TABLE [dbo].[UserGames]  WITH CHECK ADD  CONSTRAINT [FK_UserGames_Games] FOREIGN KEY([GameId])
REFERENCES [dbo].[Games] ([Id])
GO
ALTER TABLE [dbo].[UserGames] CHECK CONSTRAINT [FK_UserGames_Games]
GO
ALTER TABLE [dbo].[UserGames]  WITH CHECK ADD  CONSTRAINT [FK_UserGames_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserGames] CHECK CONSTRAINT [FK_UserGames_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_RoleId]
GO
USE [master]
GO
/****** Object:  Database [theFungi]    Script Date: 6/14/2022 12:36:20 AM ******/
CREATE DATABASE [theFungi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'theFungi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\theFungi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'theFungi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\theFungi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [theFungi] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [theFungi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [theFungi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [theFungi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [theFungi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [theFungi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [theFungi] SET ARITHABORT OFF 
GO
ALTER DATABASE [theFungi] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [theFungi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [theFungi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [theFungi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [theFungi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [theFungi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [theFungi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [theFungi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [theFungi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [theFungi] SET  ENABLE_BROKER 
GO
ALTER DATABASE [theFungi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [theFungi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [theFungi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [theFungi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [theFungi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [theFungi] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [theFungi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [theFungi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [theFungi] SET  MULTI_USER 
GO
ALTER DATABASE [theFungi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [theFungi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [theFungi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [theFungi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [theFungi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [theFungi] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [theFungi] SET QUERY_STORE = OFF
GO
USE [theFungi]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/14/2022 12:36:20 AM ******/
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
/****** Object:  Table [dbo].[AuditLogs]    Script Date: 6/14/2022 12:36:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Command] [nvarchar](max) NULL,
	[Identity] [nvarchar](max) NULL,
	[PerformedAt] [datetime2](7) NOT NULL,
	[Data] [nvarchar](max) NULL,
 CONSTRAINT [PK_AuditLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 6/14/2022 12:36:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[LastModifiedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CollectionItemInfos]    Script Date: 6/14/2022 12:36:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CollectionItemInfos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[CollectionItemId] [int] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[LastModifiedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_CollectionItemInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CollectionItems]    Script Date: 6/14/2022 12:36:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CollectionItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[Model] [nvarchar](max) NULL,
	[CollectionId] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[LastModifiedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_CollectionItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Collections]    Script Date: 6/14/2022 12:36:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Collections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[BackgroundImage] [nvarchar](max) NULL,
	[Title] [nvarchar](450) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[LastModifiedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Collections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Follows]    Script Date: 6/14/2022 12:36:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Follows](
	[CollectionId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Follows] PRIMARY KEY CLUSTERED 
(
	[CollectionId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 6/14/2022 12:36:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[LastModifiedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleUseCases]    Script Date: 6/14/2022 12:36:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleUseCases](
	[RoleId] [int] NOT NULL,
	[UseCaseId] [int] NOT NULL,
 CONSTRAINT [PK_RoleUseCases] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UseCaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/14/2022 12:36:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Username] [nvarchar](450) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
	[ProfileImage] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[DeactivatedAt] [datetime2](7) NULL,
	[Active] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220603232132_First Migration', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220612172447_remove userusecases added RoleUserCases', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220612184124_added Audit Log table', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220612185012_collumn name change in Audit Log table', N'5.0.17')
GO
SET IDENTITY_INSERT [dbo].[AuditLogs] ON 

INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (1, N'User Registration', N'Anonymous', CAST(N'2022-06-13T21:10:24.4907436' AS DateTime2), N'{"Email":"nikola.gutic@outlook.com","Username":"NNikolaG","FirstName":"Nikola","LastName":"Gutic","Password":"Nikola123!"}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (2, N'User Registration', N'Anonymous', CAST(N'2022-06-13T21:11:38.5784303' AS DateTime2), N'{"Email":"marko.markovic@gmail.com","Username":"MMarko","FirstName":"Marko","LastName":"Markovic","Password":"Marko123!"}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (3, N'User Registration', N'Anonymous', CAST(N'2022-06-13T21:12:04.1759201' AS DateTime2), N'{"Email":"ana.ana@gmail.com","Username":"AAna","FirstName":"Ana","LastName":"Anastasijevic","Password":"AnaAna123!"}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (4, N'User Registration', N'Anonymous', CAST(N'2022-06-13T21:12:28.7174514' AS DateTime2), N'{"Email":"admin@gmail.com","Username":"Admin","FirstName":"Admin","LastName":"Admin","Password":"Admin123!"}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (5, N'User Registration', N'Anonymous', CAST(N'2022-06-13T21:12:46.9407887' AS DateTime2), N'{"Email":"user@gmail.com","Username":"User","FirstName":"User","LastName":"User","Password":"User123!"}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (6, N'Create Category', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:14:42.8696878' AS DateTime2), N'{"CategoryId":0,"Title":"NFT"}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (7, N'Create Category', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:14:49.2177237' AS DateTime2), N'{"CategoryId":0,"Title":"Nature"}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (8, N'Create Category', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:14:53.9874212' AS DateTime2), N'{"CategoryId":0,"Title":"Art"}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (9, N'Create Category', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:15:03.1896966' AS DateTime2), N'{"CategoryId":0,"Title":"Cars"}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (10, N'Get Categories', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:15:06.0280907' AS DateTime2), N'{"Keyword":null,"PerPage":10,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (11, N'Create Collection Command', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:17:07.0159740' AS DateTime2), N'{"Id":0,"Title":"Fungus","CategoryId":1,"BackgroundImage":"default.jpg","UserId":1}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (12, N'Get Categories', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:17:38.1948169' AS DateTime2), N'{"Keyword":null,"PerPage":10,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (13, N'Create Collection Command', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:17:59.2911620' AS DateTime2), N'{"Id":0,"Title":"Trees","CategoryId":3,"BackgroundImage":"default.jpg","UserId":2}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (14, N'Create Collection Command', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:18:24.5600895' AS DateTime2), N'{"Id":0,"Title":"Surreal Art","CategoryId":2,"BackgroundImage":"default.jpg","UserId":3}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (15, N'Create Collection Command', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:18:59.5103768' AS DateTime2), N'{"Id":0,"Title":"Super Cars","CategoryId":4,"BackgroundImage":"default.jpg","UserId":4}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (16, N'Get Collections', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:19:08.0926112' AS DateTime2), N'{"Keyword":null,"Username":null,"CategoryId":0,"PerPage":10,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (17, N'Create Collection Command', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:19:35.8118273' AS DateTime2), N'{"Id":0,"Title":"Bees","CategoryId":2,"BackgroundImage":"default.jpg","UserId":4}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (18, N'Create Collection Command', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:19:41.3314909' AS DateTime2), N'{"Id":0,"Title":"Ants","CategoryId":2,"BackgroundImage":"default.jpg","UserId":3}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (19, N'Create Collection Command', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:19:56.5938507' AS DateTime2), N'{"Id":0,"Title":"Nature Art","CategoryId":3,"BackgroundImage":"default.jpg","UserId":2}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (20, N'Create Collection Command', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:20:15.9543237' AS DateTime2), N'{"Id":0,"Title":"Garden","CategoryId":2,"BackgroundImage":"default.jpg","UserId":1}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (21, N'Get Collections', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:20:17.9483110' AS DateTime2), N'{"Keyword":null,"Username":null,"CategoryId":0,"PerPage":10,"Page":1}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (22, N'Get Followers', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:23:31.9521873' AS DateTime2), N'{"CollectionId":0,"UserId":0,"Username":null,"ProfileImage":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (23, N'Get Followers', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:23:39.0330470' AS DateTime2), N'{"CollectionId":0,"UserId":0,"Username":null,"ProfileImage":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (24, N'Get Followers', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:23:47.3675301' AS DateTime2), N'{"CollectionId":0,"UserId":0,"Username":null,"ProfileImage":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (25, N'Get Followers', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:23:59.7766948' AS DateTime2), N'{"CollectionId":0,"UserId":0,"Username":null,"ProfileImage":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (26, N'Get Followers', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:24:02.5176848' AS DateTime2), N'{"CollectionId":0,"UserId":0,"Username":null,"ProfileImage":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (27, N'Get Followers', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:24:59.9528377' AS DateTime2), N'{"CollectionId":0,"UserId":0,"Username":null,"ProfileImage":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (28, N'Get Followers', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:25:45.7339716' AS DateTime2), N'{"CollectionId":1,"UserId":0,"Username":null,"ProfileImage":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (29, N'Get Followers', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:26:00.3474544' AS DateTime2), N'{"CollectionId":0,"UserId":0,"Username":null,"ProfileImage":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (30, N'Get Followers', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:26:08.4136519' AS DateTime2), N'{"CollectionId":2,"UserId":0,"Username":null,"ProfileImage":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (31, N'Get Followers', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:26:09.7639743' AS DateTime2), N'{"CollectionId":3,"UserId":0,"Username":null,"ProfileImage":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (32, N'Add Item to Collection', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:33:52.8889158' AS DateTime2), N'{"Id":0,"Title":"#02Fungus","CollectionId":1,"Image":"fungi2.jpg","Model":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (33, N'Add Item to Collection', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:34:07.4374623' AS DateTime2), N'{"Id":0,"Title":"#03Fungus","CollectionId":1,"Image":"fungi3.jpg","Model":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (34, N'Add Item to Collection', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:34:11.2132945' AS DateTime2), N'{"Id":0,"Title":"#04Fungus","CollectionId":1,"Image":"fungi4.jpg","Model":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (35, N'Add Item to Collection', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:34:34.9534343' AS DateTime2), N'{"Id":0,"Title":"#01Tree","CollectionId":2,"Image":"tree01.jpg","Model":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (36, N'Add Item to Collection', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:34:38.7878902' AS DateTime2), N'{"Id":0,"Title":"#02Tree","CollectionId":2,"Image":"tree02.jpg","Model":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (37, N'Add Item to Collection', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:34:43.1934854' AS DateTime2), N'{"Id":0,"Title":"#03Tree","CollectionId":2,"Image":"tree03.jpg","Model":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (38, N'Add Item to Collection', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:34:46.9264152' AS DateTime2), N'{"Id":0,"Title":"#04Tree","CollectionId":2,"Image":"tree04.jpg","Model":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (39, N'Add Item to Collection', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:34:50.8009228' AS DateTime2), N'{"Id":0,"Title":"#05Tree","CollectionId":2,"Image":"tree05.jpg","Model":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (40, N'Add Item to Collection', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:35:10.0539584' AS DateTime2), N'{"Id":0,"Title":"#01Bee","CollectionId":5,"Image":"bee01.jpg","Model":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (41, N'Add Item to Collection', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:35:14.5686415' AS DateTime2), N'{"Id":0,"Title":"#02Bee","CollectionId":5,"Image":"bee02.jpg","Model":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (42, N'Add Item to Collection', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:35:18.4575898' AS DateTime2), N'{"Id":0,"Title":"#03Bee","CollectionId":5,"Image":"bee03.jpg","Model":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (43, N'Add Item to Collection', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:35:21.5224817' AS DateTime2), N'{"Id":0,"Title":"#04Bee","CollectionId":5,"Image":"bee04.jpg","Model":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (44, N'Add Item to Collection', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:35:26.3677507' AS DateTime2), N'{"Id":0,"Title":"#05Bee","CollectionId":5,"Image":"bee05.jpg","Model":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (45, N'Add Item to Collection', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:35:50.1347118' AS DateTime2), N'{"Id":0,"Title":"#01Ant","CollectionId":6,"Image":"ant01.jpg","Model":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (46, N'Add Item to Collection', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:35:54.5529089' AS DateTime2), N'{"Id":0,"Title":"#02Ant","CollectionId":6,"Image":"ant02.jpg","Model":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (47, N'Add Item to Collection', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:35:58.4230019' AS DateTime2), N'{"Id":0,"Title":"#03Ant","CollectionId":6,"Image":"ant03.jpg","Model":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (48, N'Add Item to Collection', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:36:01.8088213' AS DateTime2), N'{"Id":0,"Title":"#04Ant","CollectionId":6,"Image":"ant04.jpg","Model":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (49, N'Add Item to Collection', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T21:36:05.7446847' AS DateTime2), N'{"Id":0,"Title":"#05Ant","CollectionId":6,"Image":"ant05.jpg","Model":null}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (50, N'Create Item info', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T22:26:28.4888246' AS DateTime2), N'{"Id":0,"Title":"Author","Content":"NN","CollectionItemId":3}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (51, N'Create Item info', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T22:26:36.0049026' AS DateTime2), N'{"Id":0,"Title":"Author","Content":"NN","CollectionItemId":5}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (52, N'Create Item info', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T22:26:40.4111522' AS DateTime2), N'{"Id":0,"Title":"Author","Content":"NN","CollectionItemId":7}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (53, N'Create Item info', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T22:26:44.8178829' AS DateTime2), N'{"Id":0,"Title":"Author","Content":"NN","CollectionItemId":10}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (54, N'Create Item info', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T22:26:48.5936201' AS DateTime2), N'{"Id":0,"Title":"Author","Content":"NN","CollectionItemId":12}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (55, N'Create Item info', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T22:29:46.0571302' AS DateTime2), N'{"Id":0,"Title":"Author","Content":"Nancy","CollectionItemId":12}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (56, N'Create Item info', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T22:29:47.5787955' AS DateTime2), N'{"Id":0,"Title":"Author","Content":"Nancy","CollectionItemId":14}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (57, N'Create Item info', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T22:29:49.5277287' AS DateTime2), N'{"Id":0,"Title":"Author","Content":"Nancy","CollectionItemId":17}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (58, N'Create Item info', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T22:29:51.3591316' AS DateTime2), N'{"Id":0,"Title":"Author","Content":"Nancy","CollectionItemId":18}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (59, N'Create Item info', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T22:29:53.6946800' AS DateTime2), N'{"Id":0,"Title":"Author","Content":"Nancy","CollectionItemId":29}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (60, N'Create Item info', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T22:30:01.0621490' AS DateTime2), N'{"Id":0,"Title":"Author","Content":"Nancy","CollectionItemId":4}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (61, N'Create Item info', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T22:30:06.0584450' AS DateTime2), N'{"Id":0,"Title":"Author","Content":"Nancy","CollectionItemId":8}')
INSERT [dbo].[AuditLogs] ([Id], [Command], [Identity], [PerformedAt], [Data]) VALUES (62, N'Create Item info', N'nikola.gutic@outlook.com', CAST(N'2022-06-13T22:30:13.6414411' AS DateTime2), N'{"Id":0,"Title":"Author","Content":"Nancy","CollectionItemId":21}')
SET IDENTITY_INSERT [dbo].[AuditLogs] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Title], [CreatedAt], [LastModifiedAt]) VALUES (1, N'NFT', CAST(N'2022-06-13T21:14:42.8842316' AS DateTime2), NULL)
INSERT [dbo].[Categories] ([Id], [Title], [CreatedAt], [LastModifiedAt]) VALUES (2, N'Nature', CAST(N'2022-06-13T21:14:49.2325629' AS DateTime2), NULL)
INSERT [dbo].[Categories] ([Id], [Title], [CreatedAt], [LastModifiedAt]) VALUES (3, N'Art', CAST(N'2022-06-13T21:14:53.9966809' AS DateTime2), NULL)
INSERT [dbo].[Categories] ([Id], [Title], [CreatedAt], [LastModifiedAt]) VALUES (4, N'Cars', CAST(N'2022-06-13T21:15:03.1976847' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[CollectionItemInfos] ON 

INSERT [dbo].[CollectionItemInfos] ([Id], [Content], [CollectionItemId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (1, N'NN', 3, N'Author', CAST(N'2022-06-13T22:26:28.5039351' AS DateTime2), NULL)
INSERT [dbo].[CollectionItemInfos] ([Id], [Content], [CollectionItemId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (2, N'NN', 5, N'Author', CAST(N'2022-06-13T22:26:36.0074412' AS DateTime2), NULL)
INSERT [dbo].[CollectionItemInfos] ([Id], [Content], [CollectionItemId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (3, N'NN', 7, N'Author', CAST(N'2022-06-13T22:26:40.4213352' AS DateTime2), NULL)
INSERT [dbo].[CollectionItemInfos] ([Id], [Content], [CollectionItemId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (4, N'NN', 10, N'Author', CAST(N'2022-06-13T22:26:44.8205746' AS DateTime2), NULL)
INSERT [dbo].[CollectionItemInfos] ([Id], [Content], [CollectionItemId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (5, N'NN', 12, N'Author', CAST(N'2022-06-13T22:26:48.6374089' AS DateTime2), NULL)
INSERT [dbo].[CollectionItemInfos] ([Id], [Content], [CollectionItemId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (6, N'Nancy', 12, N'Author', CAST(N'2022-06-13T22:29:46.0634885' AS DateTime2), NULL)
INSERT [dbo].[CollectionItemInfos] ([Id], [Content], [CollectionItemId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (7, N'Nancy', 14, N'Author', CAST(N'2022-06-13T22:29:47.5820090' AS DateTime2), NULL)
INSERT [dbo].[CollectionItemInfos] ([Id], [Content], [CollectionItemId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (8, N'Nancy', 17, N'Author', CAST(N'2022-06-13T22:29:49.5309123' AS DateTime2), NULL)
INSERT [dbo].[CollectionItemInfos] ([Id], [Content], [CollectionItemId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (9, N'Nancy', 18, N'Author', CAST(N'2022-06-13T22:29:51.3614066' AS DateTime2), NULL)
INSERT [dbo].[CollectionItemInfos] ([Id], [Content], [CollectionItemId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (10, N'Nancy', 4, N'Author', CAST(N'2022-06-13T22:30:01.0649983' AS DateTime2), NULL)
INSERT [dbo].[CollectionItemInfos] ([Id], [Content], [CollectionItemId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (11, N'Nancy', 8, N'Author', CAST(N'2022-06-13T22:30:06.0653762' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[CollectionItemInfos] OFF
GO
SET IDENTITY_INSERT [dbo].[CollectionItems] ON 

INSERT [dbo].[CollectionItems] ([Id], [Image], [Model], [CollectionId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (1, N'fungi1.jpg', NULL, 1, N'#01Fungus', CAST(N'2022-06-13T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[CollectionItems] ([Id], [Image], [Model], [CollectionId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (2, N'fungi2.jpg', NULL, 1, N'#02Fungus', CAST(N'2022-06-13T21:33:52.9418399' AS DateTime2), NULL)
INSERT [dbo].[CollectionItems] ([Id], [Image], [Model], [CollectionId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (3, N'fungi3.jpg', NULL, 1, N'#03Fungus', CAST(N'2022-06-13T21:34:07.4459060' AS DateTime2), NULL)
INSERT [dbo].[CollectionItems] ([Id], [Image], [Model], [CollectionId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (4, N'fungi4.jpg', NULL, 1, N'#04Fungus', CAST(N'2022-06-13T21:34:11.2284453' AS DateTime2), NULL)
INSERT [dbo].[CollectionItems] ([Id], [Image], [Model], [CollectionId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (5, N'tree01.jpg', NULL, 2, N'#01Tree', CAST(N'2022-06-13T21:34:34.9568652' AS DateTime2), NULL)
INSERT [dbo].[CollectionItems] ([Id], [Image], [Model], [CollectionId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (6, N'tree02.jpg', NULL, 2, N'#02Tree', CAST(N'2022-06-13T21:34:38.7934081' AS DateTime2), NULL)
INSERT [dbo].[CollectionItems] ([Id], [Image], [Model], [CollectionId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (7, N'tree03.jpg', NULL, 2, N'#03Tree', CAST(N'2022-06-13T21:34:43.2166604' AS DateTime2), NULL)
INSERT [dbo].[CollectionItems] ([Id], [Image], [Model], [CollectionId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (8, N'tree04.jpg', NULL, 2, N'#04Tree', CAST(N'2022-06-13T21:34:46.9303693' AS DateTime2), NULL)
INSERT [dbo].[CollectionItems] ([Id], [Image], [Model], [CollectionId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (9, N'tree05.jpg', NULL, 2, N'#05Tree', CAST(N'2022-06-13T21:34:50.8068614' AS DateTime2), NULL)
INSERT [dbo].[CollectionItems] ([Id], [Image], [Model], [CollectionId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (10, N'bee01.jpg', NULL, 5, N'#01Bee', CAST(N'2022-06-13T21:35:10.0611754' AS DateTime2), NULL)
INSERT [dbo].[CollectionItems] ([Id], [Image], [Model], [CollectionId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (11, N'bee02.jpg', NULL, 5, N'#02Bee', CAST(N'2022-06-13T21:35:14.5714314' AS DateTime2), NULL)
INSERT [dbo].[CollectionItems] ([Id], [Image], [Model], [CollectionId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (12, N'bee03.jpg', NULL, 5, N'#03Bee', CAST(N'2022-06-13T21:35:18.4618736' AS DateTime2), NULL)
INSERT [dbo].[CollectionItems] ([Id], [Image], [Model], [CollectionId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (13, N'bee04.jpg', NULL, 5, N'#04Bee', CAST(N'2022-06-13T21:35:21.5862431' AS DateTime2), NULL)
INSERT [dbo].[CollectionItems] ([Id], [Image], [Model], [CollectionId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (14, N'bee05.jpg', NULL, 5, N'#05Bee', CAST(N'2022-06-13T21:35:26.3701925' AS DateTime2), NULL)
INSERT [dbo].[CollectionItems] ([Id], [Image], [Model], [CollectionId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (15, N'ant01.jpg', NULL, 6, N'#01Ant', CAST(N'2022-06-13T21:35:50.1395395' AS DateTime2), NULL)
INSERT [dbo].[CollectionItems] ([Id], [Image], [Model], [CollectionId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (16, N'ant02.jpg', NULL, 6, N'#02Ant', CAST(N'2022-06-13T21:35:54.5558645' AS DateTime2), NULL)
INSERT [dbo].[CollectionItems] ([Id], [Image], [Model], [CollectionId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (17, N'ant03.jpg', NULL, 6, N'#03Ant', CAST(N'2022-06-13T21:35:58.4295609' AS DateTime2), NULL)
INSERT [dbo].[CollectionItems] ([Id], [Image], [Model], [CollectionId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (18, N'ant04.jpg', NULL, 6, N'#04Ant', CAST(N'2022-06-13T21:36:01.8141453' AS DateTime2), NULL)
INSERT [dbo].[CollectionItems] ([Id], [Image], [Model], [CollectionId], [Title], [CreatedAt], [LastModifiedAt]) VALUES (19, N'ant05.jpg', NULL, 6, N'#05Ant', CAST(N'2022-06-13T21:36:05.7473461' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[CollectionItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Collections] ON 

INSERT [dbo].[Collections] ([Id], [UserId], [CategoryId], [BackgroundImage], [Title], [CreatedAt], [LastModifiedAt]) VALUES (1, 1, 1, N'default.jpg', N'Fungus', CAST(N'2022-06-13T21:17:07.0332634' AS DateTime2), NULL)
INSERT [dbo].[Collections] ([Id], [UserId], [CategoryId], [BackgroundImage], [Title], [CreatedAt], [LastModifiedAt]) VALUES (2, 2, 3, N'default.jpg', N'Trees', CAST(N'2022-06-13T21:17:59.3024783' AS DateTime2), NULL)
INSERT [dbo].[Collections] ([Id], [UserId], [CategoryId], [BackgroundImage], [Title], [CreatedAt], [LastModifiedAt]) VALUES (3, 3, 2, N'default.jpg', N'Surreal Art', CAST(N'2022-06-13T21:18:24.5654728' AS DateTime2), NULL)
INSERT [dbo].[Collections] ([Id], [UserId], [CategoryId], [BackgroundImage], [Title], [CreatedAt], [LastModifiedAt]) VALUES (4, 4, 4, N'default.jpg', N'Super Cars', CAST(N'2022-06-13T21:18:59.5169507' AS DateTime2), NULL)
INSERT [dbo].[Collections] ([Id], [UserId], [CategoryId], [BackgroundImage], [Title], [CreatedAt], [LastModifiedAt]) VALUES (5, 4, 2, N'default.jpg', N'Bees', CAST(N'2022-06-13T21:19:35.8191397' AS DateTime2), NULL)
INSERT [dbo].[Collections] ([Id], [UserId], [CategoryId], [BackgroundImage], [Title], [CreatedAt], [LastModifiedAt]) VALUES (6, 3, 2, N'default.jpg', N'Ants', CAST(N'2022-06-13T21:19:41.3357993' AS DateTime2), NULL)
INSERT [dbo].[Collections] ([Id], [UserId], [CategoryId], [BackgroundImage], [Title], [CreatedAt], [LastModifiedAt]) VALUES (7, 2, 3, N'default.jpg', N'Nature Art', CAST(N'2022-06-13T21:19:56.5968117' AS DateTime2), NULL)
INSERT [dbo].[Collections] ([Id], [UserId], [CategoryId], [BackgroundImage], [Title], [CreatedAt], [LastModifiedAt]) VALUES (8, 1, 2, N'default.jpg', N'Garden', CAST(N'2022-06-13T21:20:15.9737802' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Collections] OFF
GO
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (2, 1)
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (3, 1)
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (4, 1)
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (5, 1)
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (6, 1)
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (1, 2)
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (3, 2)
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (4, 2)
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (5, 2)
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (6, 2)
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (1, 3)
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (2, 3)
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (4, 3)
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (5, 3)
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (8, 3)
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (2, 4)
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (6, 4)
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (1, 5)
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (3, 5)
INSERT [dbo].[Follows] ([CollectionId], [UserId]) VALUES (5, 5)
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Title], [CreatedAt], [LastModifiedAt]) VALUES (1, N'Admin', CAST(N'2022-06-13T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Roles] ([Id], [Title], [CreatedAt], [LastModifiedAt]) VALUES (2, N'User', CAST(N'2022-06-13T00:00:00.0000000' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 1)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 10)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 11)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 12)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 13)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 14)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 15)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 16)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 17)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 18)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 19)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 20)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 21)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 22)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 23)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 24)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 25)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 26)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 27)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 28)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 30)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 31)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 32)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 33)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 11)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 16)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 17)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 18)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 19)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 20)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 21)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 22)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 23)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 24)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 25)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 26)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 27)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 28)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 30)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 31)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 32)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 33)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [ProfileImage], [CreatedAt], [DeactivatedAt], [Active], [RoleId]) VALUES (1, N'Nikola', N'Gutic', N'NNikolaG', N'$2a$11$hIwl4pJjswv2K3jfaBpYT.y/Y9DkfpL3oKchRuozlurB.WvZpifOe', N'nikola.gutic@outlook.com', N'default.img', CAST(N'2022-06-13T21:10:27.0507133' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [ProfileImage], [CreatedAt], [DeactivatedAt], [Active], [RoleId]) VALUES (2, N'Marko', N'Markovic', N'MMarko', N'$2a$11$3vO8JBOGgIKTA2w3J.SBI.JcG6211oUvfxFgyxN4FaTew0FwGsxsi', N'marko.markovic@gmail.com', N'default.img', CAST(N'2022-06-13T21:11:38.9454939' AS DateTime2), NULL, 0, 2)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [ProfileImage], [CreatedAt], [DeactivatedAt], [Active], [RoleId]) VALUES (3, N'Ana', N'Anastasijevic', N'AAna', N'$2a$11$Bf8QW/A2WenXDBQ8TMyvgelpBKHAz34LtAT7nKjOHo.7/NJ2GKfRS', N'ana.ana@gmail.com', N'default.img', CAST(N'2022-06-13T21:12:04.5091393' AS DateTime2), NULL, 0, 2)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [ProfileImage], [CreatedAt], [DeactivatedAt], [Active], [RoleId]) VALUES (4, N'Admin', N'Admin', N'Admin', N'$2a$11$nHR1H3jWXJqRVTP6hptttuNvacOmON/J.GP53koFMLaYx42bmPsx.', N'admin@gmail.com', N'default.img', CAST(N'2022-06-13T21:12:29.0282992' AS DateTime2), NULL, 0, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [ProfileImage], [CreatedAt], [DeactivatedAt], [Active], [RoleId]) VALUES (5, N'User', N'User', N'User', N'$2a$11$/vGXAfhlWN27.2pTT0iYSeackcNj4nMfod4oipqRhKp4AiTtESVeO', N'user@gmail.com', N'default.img', CAST(N'2022-06-13T21:12:47.2399625' AS DateTime2), NULL, 0, 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_CollectionItemInfos_CollectionItemId]    Script Date: 6/14/2022 12:36:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_CollectionItemInfos_CollectionItemId] ON [dbo].[CollectionItemInfos]
(
	[CollectionItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CollectionItems_CollectionId]    Script Date: 6/14/2022 12:36:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_CollectionItems_CollectionId] ON [dbo].[CollectionItems]
(
	[CollectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Collections_CategoryId]    Script Date: 6/14/2022 12:36:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_Collections_CategoryId] ON [dbo].[Collections]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Collections_Title]    Script Date: 6/14/2022 12:36:20 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Collections_Title] ON [dbo].[Collections]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Collections_UserId]    Script Date: 6/14/2022 12:36:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_Collections_UserId] ON [dbo].[Collections]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Follows_UserId]    Script Date: 6/14/2022 12:36:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_Follows_UserId] ON [dbo].[Follows]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Email]    Script Date: 6/14/2022 12:36:20 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Email] ON [dbo].[Users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_RoleId]    Script Date: 6/14/2022 12:36:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_Users_RoleId] ON [dbo].[Users]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Username]    Script Date: 6/14/2022 12:36:20 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Username] ON [dbo].[Users]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CollectionItemInfos]  WITH CHECK ADD  CONSTRAINT [FK_CollectionItemInfos_CollectionItems_CollectionItemId] FOREIGN KEY([CollectionItemId])
REFERENCES [dbo].[CollectionItems] ([Id])
GO
ALTER TABLE [dbo].[CollectionItemInfos] CHECK CONSTRAINT [FK_CollectionItemInfos_CollectionItems_CollectionItemId]
GO
ALTER TABLE [dbo].[CollectionItems]  WITH CHECK ADD  CONSTRAINT [FK_CollectionItems_Collections_CollectionId] FOREIGN KEY([CollectionId])
REFERENCES [dbo].[Collections] ([Id])
GO
ALTER TABLE [dbo].[CollectionItems] CHECK CONSTRAINT [FK_CollectionItems_Collections_CollectionId]
GO
ALTER TABLE [dbo].[Collections]  WITH CHECK ADD  CONSTRAINT [FK_Collections_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Collections] CHECK CONSTRAINT [FK_Collections_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Collections]  WITH CHECK ADD  CONSTRAINT [FK_Collections_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Collections] CHECK CONSTRAINT [FK_Collections_Users_UserId]
GO
ALTER TABLE [dbo].[Follows]  WITH CHECK ADD  CONSTRAINT [FK_Follows_Collections_CollectionId] FOREIGN KEY([CollectionId])
REFERENCES [dbo].[Collections] ([Id])
GO
ALTER TABLE [dbo].[Follows] CHECK CONSTRAINT [FK_Follows_Collections_CollectionId]
GO
ALTER TABLE [dbo].[Follows]  WITH CHECK ADD  CONSTRAINT [FK_Follows_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Follows] CHECK CONSTRAINT [FK_Follows_Users_UserId]
GO
ALTER TABLE [dbo].[RoleUseCases]  WITH CHECK ADD  CONSTRAINT [FK_RoleUseCases_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleUseCases] CHECK CONSTRAINT [FK_RoleUseCases_Roles_RoleId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_RoleId]
GO
USE [master]
GO
ALTER DATABASE [theFungi] SET  READ_WRITE 
GO

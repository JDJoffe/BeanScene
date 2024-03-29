USE [master]
GO
/****** Object:  Database [BeanSceneAppV1-JoshuaJoffe]    Script Date: 25/11/2022 2:07:39 PM ******/
CREATE DATABASE [BeanSceneAppV1-JoshuaJoffe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BeanSceneAppV1-JoshuaJoffe', FILENAME = N'C:\Users\joshua.joffe\BeanSceneAppV1-JoshuaJoffe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BeanSceneAppV1-JoshuaJoffe_log', FILENAME = N'C:\Users\joshua.joffe\BeanSceneAppV1-JoshuaJoffe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BeanSceneAppV1-JoshuaJoffe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET ARITHABORT OFF 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET  MULTI_USER 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET QUERY_STORE = OFF
GO
USE [BeanSceneAppV1-JoshuaJoffe]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 25/11/2022 2:07:39 PM ******/
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
/****** Object:  Table [dbo].[Area]    Script Date: 25/11/2022 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AreaAvailability]    Script Date: 25/11/2022 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AreaAvailability](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AreaId] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Start_Time] [time](7) NOT NULL,
	[End_Time] [time](7) NOT NULL,
 CONSTRAINT [PK_AreaAvailability] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 25/11/2022 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 25/11/2022 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 25/11/2022 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 25/11/2022 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 25/11/2022 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 25/11/2022 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[First_Name] [nvarchar](255) NOT NULL,
	[Last_Name] [nvarchar](255) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 25/11/2022 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 25/11/2022 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[TimeSlotId] [int] NOT NULL,
	[SittingId] [int] NOT NULL,
	[GuestAmmount] [int] NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[SeatingRequest] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sitting]    Script Date: 25/11/2022 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sitting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sitting_Type] [int] NOT NULL,
	[Start_Date] [datetime2](7) NOT NULL,
	[End_Date] [datetime2](7) NOT NULL,
	[Start_Time] [time](7) NOT NULL,
	[End_Time] [time](7) NOT NULL,
	[Capacity] [int] NOT NULL,
	[Guest_Total] [int] NOT NULL,
	[Tables_Available] [int] NOT NULL,
 CONSTRAINT [PK_Sitting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 25/11/2022 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Table_Name] [nvarchar](max) NOT NULL,
	[Table_Seats] [int] NOT NULL,
	[AreaId] [int] NOT NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableAvailability]    Script Date: 25/11/2022 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableAvailability](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TableId] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[TimeSlotId] [int] NOT NULL,
 CONSTRAINT [PK_TableAvailability] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableReservation]    Script Date: 25/11/2022 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableReservation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TableId] [int] NOT NULL,
	[ReservationId] [int] NOT NULL,
 CONSTRAINT [PK_TableReservation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeSlot]    Script Date: 25/11/2022 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSlot](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Time] [time](7) NOT NULL,
 CONSTRAINT [PK_TimeSlot] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221103233853_newbuild4', N'6.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221107041224_SeedIdentityData', N'6.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221118022459_tablereservation', N'6.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221119074827_unique', N'6.0.10')
GO
SET IDENTITY_INSERT [dbo].[Area] ON 

INSERT [dbo].[Area] ([Id], [Name]) VALUES (1, N'Main')
INSERT [dbo].[Area] ([Id], [Name]) VALUES (2, N'Balcony')
INSERT [dbo].[Area] ([Id], [Name]) VALUES (3, N'Outside')
SET IDENTITY_INSERT [dbo].[Area] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'0c696da5-1792-4243-8310-70a50a86830b', N'Manager', N'MANAGER', N'3323d9c6-e481-4f27-9a89-cfb8938797ac')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'86fa9752-0fba-4a40-bc94-fdce825eb417', N'Member', N'MEMBER', N'44fffd54-a007-40a2-9920-222f507323bf')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'bd5300a0-47f6-48c3-8cf1-f44265ec13fb', N'Staff', N'STAFF', N'f1d7904c-b70f-4fc0-9b0c-b8b06b3ab95c')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4aad9167-fe03-4100-ba60-01246bd96745', N'0c696da5-1792-4243-8310-70a50a86830b')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'eab9b0af-8098-4777-a67e-6e3ff5afe005', N'86fa9752-0fba-4a40-bc94-fdce825eb417')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4aad9167-fe03-4100-ba60-01246bd96745', N'bd5300a0-47f6-48c3-8cf1-f44265ec13fb')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a8b2fc99-3400-4e20-a722-4147bb670dca', N'bd5300a0-47f6-48c3-8cf1-f44265ec13fb')
GO
INSERT [dbo].[AspNetUsers] ([Id], [First_Name], [Last_Name], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'4aad9167-fe03-4100-ba60-01246bd96745', N'Barry', N'Bayman', N'Barry1@BeanScene.com', N'BARRY1@BEANSCENE.COM', N'Barry1@BeanScene.com', N'BARRY1@BEANSCENE.COM', 1, N'AQAAAAEAACcQAAAAECo8coF7tavRqm154TyAbMdxFjwbpTfRS8p/9ZTgCRdFadZxUsLX4XXP5ZUT2tMYyg==', N'aefe3805-a7d4-428a-9631-c8f34382f710', N'095d854b-f403-46ba-a157-e95d145d8439', NULL, 1, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [First_Name], [Last_Name], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a8b2fc99-3400-4e20-a722-4147bb670dca', N'Mitch', N'Michaels', N'Mitch1@BeanScene.com', N'MITCH1@BEANSCENE.COM', N'Mitch1@BeanScene.com', N'MITCH1@BEANSCENE.COM', 1, N'AQAAAAEAACcQAAAAEEVwY5L4dSME0K1QKZ9JoRbpdDOEhM7Z1vx1b0O6qrD3Qx3ccsLgcGjX6+4J4PAtoA==', N'e712525d-2d89-4ffb-ad5b-77d924f68dc8', N'1c9f0ca1-bb5d-4732-9d40-3a2654d6410b', NULL, 1, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [First_Name], [Last_Name], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'eab9b0af-8098-4777-a67e-6e3ff5afe005', N'Gary', N'Faulkner', N'GaryFaulkner1@Gmail.com', N'GARYFAULKNER1@GMAIL.COM', N'GaryFaulkner1@Gmail.com', N'GARYFAULKNER1@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEI5oXXSLNvcYFswuVPsZ/OYm6ZXyvck2UGzo82D5ShElaFpGkXpmd4SWQz0LbEJrDw==', N'7e64244f-4821-4b4b-a074-0241f36ae489', N'92c317d8-ef32-4a03-8abe-7c65968f9b8f', N'04100', 1, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Reservation] ON 

INSERT [dbo].[Reservation] ([Id], [Date], [TimeSlotId], [SittingId], [GuestAmmount], [FirstName], [LastName], [Phone], [Email], [SeatingRequest], [Status]) VALUES (1, CAST(N'2022-11-24T00:00:00.0000000' AS DateTime2), 9, 1, 6, N'Allen', N'Bates', N'04100', N'Allen@Gmail.com', N'Main By the window', 4)
INSERT [dbo].[Reservation] ([Id], [Date], [TimeSlotId], [SittingId], [GuestAmmount], [FirstName], [LastName], [Phone], [Email], [SeatingRequest], [Status]) VALUES (2, CAST(N'2022-11-24T00:00:00.0000000' AS DateTime2), 12, 3, 12, N'Joe', N'Taylor', N'04100', N'Joe@Gmail.com', N'Balcony', 4)
INSERT [dbo].[Reservation] ([Id], [Date], [TimeSlotId], [SittingId], [GuestAmmount], [FirstName], [LastName], [Phone], [Email], [SeatingRequest], [Status]) VALUES (3, CAST(N'2022-11-24T00:00:00.0000000' AS DateTime2), 12, 3, 4, N'Gary', N'Faulkner', N'04100', N'GaryFaulkner1@Gmail.com', N'Outside', 4)
INSERT [dbo].[Reservation] ([Id], [Date], [TimeSlotId], [SittingId], [GuestAmmount], [FirstName], [LastName], [Phone], [Email], [SeatingRequest], [Status]) VALUES (4, CAST(N'2022-11-29T00:00:00.0000000' AS DateTime2), 12, 3, 6, N'Barry', N'Bayman', N'04100', N'Barry1@BeanScene.com', N'indoors near Windows please2', 2)
SET IDENTITY_INSERT [dbo].[Reservation] OFF
GO
SET IDENTITY_INSERT [dbo].[Sitting] ON 

INSERT [dbo].[Sitting] ([Id], [Sitting_Type], [Start_Date], [End_Date], [Start_Time], [End_Time], [Capacity], [Guest_Total], [Tables_Available]) VALUES (1, 0, CAST(N'2022-10-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-31T00:00:00.0000000' AS DateTime2), CAST(N'09:00:00' AS Time), CAST(N'10:59:00' AS Time), 120, 16, 26)
INSERT [dbo].[Sitting] ([Id], [Sitting_Type], [Start_Date], [End_Date], [Start_Time], [End_Time], [Capacity], [Guest_Total], [Tables_Available]) VALUES (2, 0, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-31T00:00:00.0000000' AS DateTime2), CAST(N'08:00:00' AS Time), CAST(N'10:59:00' AS Time), 120, 0, 30)
INSERT [dbo].[Sitting] ([Id], [Sitting_Type], [Start_Date], [End_Date], [Start_Time], [End_Time], [Capacity], [Guest_Total], [Tables_Available]) VALUES (3, 1, CAST(N'2022-10-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-31T00:00:00.0000000' AS DateTime2), CAST(N'11:00:00' AS Time), CAST(N'15:59:00' AS Time), 120, 22, 26)
INSERT [dbo].[Sitting] ([Id], [Sitting_Type], [Start_Date], [End_Date], [Start_Time], [End_Time], [Capacity], [Guest_Total], [Tables_Available]) VALUES (4, 1, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-31T00:00:00.0000000' AS DateTime2), CAST(N'11:00:00' AS Time), CAST(N'15:59:00' AS Time), 120, 0, 30)
INSERT [dbo].[Sitting] ([Id], [Sitting_Type], [Start_Date], [End_Date], [Start_Time], [End_Time], [Capacity], [Guest_Total], [Tables_Available]) VALUES (5, 2, CAST(N'2022-10-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-31T00:00:00.0000000' AS DateTime2), CAST(N'16:00:00' AS Time), CAST(N'19:59:00' AS Time), 120, 16, 26)
INSERT [dbo].[Sitting] ([Id], [Sitting_Type], [Start_Date], [End_Date], [Start_Time], [End_Time], [Capacity], [Guest_Total], [Tables_Available]) VALUES (6, 2, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-31T00:00:00.0000000' AS DateTime2), CAST(N'16:00:00' AS Time), CAST(N'19:59:00' AS Time), 120, 0, 30)
SET IDENTITY_INSERT [dbo].[Sitting] OFF
GO
SET IDENTITY_INSERT [dbo].[Table] ON 

INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (1, N'M1', 4, 1)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (2, N'M2', 4, 1)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (3, N'M3', 4, 1)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (4, N'M4', 4, 1)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (5, N'M5', 4, 1)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (6, N'M6', 4, 1)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (7, N'M7', 4, 1)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (8, N'M8', 4, 1)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (9, N'M9', 4, 1)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (10, N'M10', 4, 1)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (11, N'B1', 4, 2)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (12, N'B2', 4, 2)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (13, N'B3', 4, 2)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (14, N'B4', 4, 2)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (15, N'B5', 4, 2)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (16, N'B6', 4, 2)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (17, N'B7', 4, 2)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (18, N'B8', 4, 2)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (19, N'B9', 4, 2)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (20, N'B10', 4, 2)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (21, N'O1', 4, 3)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (22, N'O2', 4, 3)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (23, N'O3', 4, 3)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (24, N'O4', 4, 3)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (25, N'O5', 4, 3)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (26, N'O6', 4, 3)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (27, N'O7', 4, 3)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (28, N'O8', 4, 3)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (29, N'O9', 4, 3)
INSERT [dbo].[Table] ([Id], [Table_Name], [Table_Seats], [AreaId]) VALUES (30, N'O10', 4, 3)
SET IDENTITY_INSERT [dbo].[Table] OFF
GO
SET IDENTITY_INSERT [dbo].[TableAvailability] ON 

INSERT [dbo].[TableAvailability] ([Id], [TableId], [Date], [TimeSlotId]) VALUES (1, 1, CAST(N'2022-11-24T00:00:00.0000000' AS DateTime2), 9)
INSERT [dbo].[TableAvailability] ([Id], [TableId], [Date], [TimeSlotId]) VALUES (2, 2, CAST(N'2022-11-24T00:00:00.0000000' AS DateTime2), 9)
INSERT [dbo].[TableAvailability] ([Id], [TableId], [Date], [TimeSlotId]) VALUES (3, 11, CAST(N'2022-11-24T00:00:00.0000000' AS DateTime2), 12)
INSERT [dbo].[TableAvailability] ([Id], [TableId], [Date], [TimeSlotId]) VALUES (4, 12, CAST(N'2022-11-24T00:00:00.0000000' AS DateTime2), 12)
INSERT [dbo].[TableAvailability] ([Id], [TableId], [Date], [TimeSlotId]) VALUES (5, 13, CAST(N'2022-11-24T00:00:00.0000000' AS DateTime2), 12)
INSERT [dbo].[TableAvailability] ([Id], [TableId], [Date], [TimeSlotId]) VALUES (6, 21, CAST(N'2022-11-24T00:00:00.0000000' AS DateTime2), 12)
INSERT [dbo].[TableAvailability] ([Id], [TableId], [Date], [TimeSlotId]) VALUES (7, 22, CAST(N'2022-11-24T00:00:00.0000000' AS DateTime2), 12)
INSERT [dbo].[TableAvailability] ([Id], [TableId], [Date], [TimeSlotId]) VALUES (8, 23, CAST(N'2022-11-24T00:00:00.0000000' AS DateTime2), 12)
SET IDENTITY_INSERT [dbo].[TableAvailability] OFF
GO
SET IDENTITY_INSERT [dbo].[TableReservation] ON 

INSERT [dbo].[TableReservation] ([Id], [TableId], [ReservationId]) VALUES (1, 1, 1)
INSERT [dbo].[TableReservation] ([Id], [TableId], [ReservationId]) VALUES (2, 2, 1)
INSERT [dbo].[TableReservation] ([Id], [TableId], [ReservationId]) VALUES (3, 11, 2)
INSERT [dbo].[TableReservation] ([Id], [TableId], [ReservationId]) VALUES (4, 12, 2)
INSERT [dbo].[TableReservation] ([Id], [TableId], [ReservationId]) VALUES (5, 13, 2)
INSERT [dbo].[TableReservation] ([Id], [TableId], [ReservationId]) VALUES (6, 21, 3)
INSERT [dbo].[TableReservation] ([Id], [TableId], [ReservationId]) VALUES (7, 22, 3)
INSERT [dbo].[TableReservation] ([Id], [TableId], [ReservationId]) VALUES (8, 23, 3)
SET IDENTITY_INSERT [dbo].[TableReservation] OFF
GO
SET IDENTITY_INSERT [dbo].[TimeSlot] ON 

INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (1, CAST(N'01:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (2, CAST(N'02:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (3, CAST(N'03:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (4, CAST(N'04:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (5, CAST(N'05:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (6, CAST(N'06:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (7, CAST(N'07:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (8, CAST(N'08:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (9, CAST(N'09:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (10, CAST(N'10:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (11, CAST(N'11:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (12, CAST(N'12:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (13, CAST(N'13:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (14, CAST(N'14:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (15, CAST(N'15:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (16, CAST(N'16:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (17, CAST(N'17:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (18, CAST(N'18:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (19, CAST(N'19:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (20, CAST(N'20:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (21, CAST(N'21:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (22, CAST(N'22:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (23, CAST(N'23:00:00' AS Time))
INSERT [dbo].[TimeSlot] ([Id], [Time]) VALUES (24, CAST(N'00:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[TimeSlot] OFF
GO
/****** Object:  Index [IX_AreaAvailability_AreaId]    Script Date: 25/11/2022 2:07:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_AreaAvailability_AreaId] ON [dbo].[AreaAvailability]
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 25/11/2022 2:07:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 25/11/2022 2:07:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 25/11/2022 2:07:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 25/11/2022 2:07:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 25/11/2022 2:07:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 25/11/2022 2:07:39 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 25/11/2022 2:07:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservation_SittingId]    Script Date: 25/11/2022 2:07:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Reservation_SittingId] ON [dbo].[Reservation]
(
	[SittingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservation_TimeSlotId]    Script Date: 25/11/2022 2:07:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Reservation_TimeSlotId] ON [dbo].[Reservation]
(
	[TimeSlotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Table_AreaId]    Script Date: 25/11/2022 2:07:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Table_AreaId] ON [dbo].[Table]
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TableAvailability_TableId_Date_TimeSlotId]    Script Date: 25/11/2022 2:07:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TableAvailability_TableId_Date_TimeSlotId] ON [dbo].[TableAvailability]
(
	[TableId] ASC,
	[Date] ASC,
	[TimeSlotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TableAvailability_TimeSlotId]    Script Date: 25/11/2022 2:07:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_TableAvailability_TimeSlotId] ON [dbo].[TableAvailability]
(
	[TimeSlotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TableReservation_ReservationId]    Script Date: 25/11/2022 2:07:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_TableReservation_ReservationId] ON [dbo].[TableReservation]
(
	[ReservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TableReservation_TableId_ReservationId]    Script Date: 25/11/2022 2:07:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TableReservation_TableId_ReservationId] ON [dbo].[TableReservation]
(
	[TableId] ASC,
	[ReservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Reservation] ADD  DEFAULT (N'') FOR [SeatingRequest]
GO
ALTER TABLE [dbo].[AreaAvailability]  WITH CHECK ADD  CONSTRAINT [FK_AreaAvailability_Area_AreaId] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AreaAvailability] CHECK CONSTRAINT [FK_AreaAvailability_Area_AreaId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Sitting_SittingId] FOREIGN KEY([SittingId])
REFERENCES [dbo].[Sitting] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Sitting_SittingId]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_TimeSlot_TimeSlotId] FOREIGN KEY([TimeSlotId])
REFERENCES [dbo].[TimeSlot] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_TimeSlot_TimeSlotId]
GO
ALTER TABLE [dbo].[Table]  WITH CHECK ADD  CONSTRAINT [FK_Table_Area_AreaId] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Table] CHECK CONSTRAINT [FK_Table_Area_AreaId]
GO
ALTER TABLE [dbo].[TableAvailability]  WITH CHECK ADD  CONSTRAINT [FK_TableAvailability_Table_TableId] FOREIGN KEY([TableId])
REFERENCES [dbo].[Table] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TableAvailability] CHECK CONSTRAINT [FK_TableAvailability_Table_TableId]
GO
ALTER TABLE [dbo].[TableAvailability]  WITH CHECK ADD  CONSTRAINT [FK_TableAvailability_TimeSlot_TimeSlotId] FOREIGN KEY([TimeSlotId])
REFERENCES [dbo].[TimeSlot] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TableAvailability] CHECK CONSTRAINT [FK_TableAvailability_TimeSlot_TimeSlotId]
GO
ALTER TABLE [dbo].[TableReservation]  WITH CHECK ADD  CONSTRAINT [FK_TableReservation_Reservation_ReservationId] FOREIGN KEY([ReservationId])
REFERENCES [dbo].[Reservation] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TableReservation] CHECK CONSTRAINT [FK_TableReservation_Reservation_ReservationId]
GO
ALTER TABLE [dbo].[TableReservation]  WITH CHECK ADD  CONSTRAINT [FK_TableReservation_Table_TableId] FOREIGN KEY([TableId])
REFERENCES [dbo].[Table] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TableReservation] CHECK CONSTRAINT [FK_TableReservation_Table_TableId]
GO
/****** Object:  StoredProcedure [dbo].[USP_AssignSitting]    Script Date: 25/11/2022 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE  [dbo].[USP_AssignSitting]
	-- Add the parameters for the stored procedure here
	@TimeSlotId int ,
	@Date date
	 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Time TIME(7) 
	DECLARE @TimeResult TIME(7)
	
	EXEC USP_GetTime @TimeSlotId,   @Time OUTPUT;
	SET DATEFORMAT DMY
	SELECT Id 
	FROM SITTING s 
    WHERE (@Date BETWEEN s.Start_Date AND s.End_Date) AND 
          (@Time BETWEEN s.Start_Time AND s.End_Time)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetTime]    Script Date: 25/11/2022 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE [dbo].[USP_GetTime]
	-- Add the parameters for the stored procedure here
	@TimeSlotId int,
	@TimeResult TIME(7) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    -- Insert statements for procedure here
	SELECT @TimeResult =(
	SELECT [Time] 
	FROM TIMESLOT t
    WHERE @TimeSlotId = t.Id
	)
END
GO
USE [master]
GO
ALTER DATABASE [BeanSceneAppV1-JoshuaJoffe] SET  READ_WRITE 
GO

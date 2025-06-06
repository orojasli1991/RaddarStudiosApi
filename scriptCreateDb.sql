USE [master]
GO
/****** Object:  Database [StudentManagementInterRapidisimoDb]    Script Date: 25/02/2025 1:49:58 a. m. ******/
CREATE DATABASE [StudentManagementInterRapidisimoDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentManagementInterRapidisimoDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\StudentManagementInterRapidisimoDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentManagementInterRapidisimoDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\StudentManagementInterRapidisimoDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentManagementInterRapidisimoDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET  MULTI_USER 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [StudentManagementInterRapidisimoDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 25/02/2025 1:49:58 a. m. ******/
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
/****** Object:  Table [dbo].[Students]    Script Date: 25/02/2025 1:49:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 25/02/2025 1:49:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Credits] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectSelections]    Script Date: 25/02/2025 1:49:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectSelections](
	[StudentId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
 CONSTRAINT [PK_SubjectSelections] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 25/02/2025 1:49:58 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250224015558_InitialCreate', N'9.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250224024231_UpdateSchema', N'9.0.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250224203421_AddSubjectSelectionRelation', N'9.0.2')
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [Name], [Email]) VALUES (1, N'prueba 34', N'prueba342@prueba.com')
INSERT [dbo].[Students] ([Id], [Name], [Email]) VALUES (2, N'prueba 2', N'orojasli19911@outlook.com')
INSERT [dbo].[Students] ([Id], [Name], [Email]) VALUES (3, N'prueba 3', N'orojasli19911@gmail.com')
INSERT [dbo].[Students] ([Id], [Name], [Email]) VALUES (5, N'prueba 5', N'orojasli199111@outlook.com')
INSERT [dbo].[Students] ([Id], [Name], [Email]) VALUES (7, N'prueba 101', N'orojasli19913@outlook.com')
INSERT [dbo].[Students] ([Id], [Name], [Email]) VALUES (8, N'oscar alexander rojas linares', N'orojasli1991@outlook.com')
INSERT [dbo].[Students] ([Id], [Name], [Email]) VALUES (10, N'prueba 2', N'orojasli19915@outlook.com')
INSERT [dbo].[Students] ([Id], [Name], [Email]) VALUES (13, N'pepito', N'pepito@hotmail.com')
INSERT [dbo].[Students] ([Id], [Name], [Email]) VALUES (14, N'pepito', N'pepito2@hotmail.com')
INSERT [dbo].[Students] ([Id], [Name], [Email]) VALUES (15, N'pepita rojas', N'pepita@hotmail.com')
INSERT [dbo].[Students] ([Id], [Name], [Email]) VALUES (17, N'pepita rojas', N'pepita5@hotmail.com')
INSERT [dbo].[Students] ([Id], [Name], [Email]) VALUES (19, N'prueba25', N'prueba25@outlook.com')
INSERT [dbo].[Students] ([Id], [Name], [Email]) VALUES (20, N'prueba2514', N'prueba2514@outlook.com')
INSERT [dbo].[Students] ([Id], [Name], [Email]) VALUES (21, N'andres hernandez', N'orojasli1990@outlook.com')
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[Subjects] ON 

INSERT [dbo].[Subjects] ([Id], [Name], [Credits], [TeacherId]) VALUES (3, N'Matemáticas ', 3, 1)
INSERT [dbo].[Subjects] ([Id], [Name], [Credits], [TeacherId]) VALUES (4, N'Física ', 3, 2)
INSERT [dbo].[Subjects] ([Id], [Name], [Credits], [TeacherId]) VALUES (5, N'Química ', 3, 3)
INSERT [dbo].[Subjects] ([Id], [Name], [Credits], [TeacherId]) VALUES (6, N'Biología ', 3, 4)
INSERT [dbo].[Subjects] ([Id], [Name], [Credits], [TeacherId]) VALUES (7, N'Historia ', 3, 5)
INSERT [dbo].[Subjects] ([Id], [Name], [Credits], [TeacherId]) VALUES (8, N'Geografía ', 3, 1)
INSERT [dbo].[Subjects] ([Id], [Name], [Credits], [TeacherId]) VALUES (9, N'Lengua Española ', 3, 2)
INSERT [dbo].[Subjects] ([Id], [Name], [Credits], [TeacherId]) VALUES (10, N'Literatura ', 3, 3)
INSERT [dbo].[Subjects] ([Id], [Name], [Credits], [TeacherId]) VALUES (11, N'Cálculo ', 3, 4)
INSERT [dbo].[Subjects] ([Id], [Name], [Credits], [TeacherId]) VALUES (12, N'Estadística ', 3, 5)
SET IDENTITY_INSERT [dbo].[Subjects] OFF
GO
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (7, 3)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (8, 3)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (10, 3)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (7, 4)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (8, 4)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (10, 4)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (21, 4)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (2, 5)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (7, 5)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (8, 5)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (19, 5)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (2, 6)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (19, 6)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (21, 6)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (2, 7)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (10, 7)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (19, 7)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (21, 7)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (17, 10)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (17, 11)
INSERT [dbo].[SubjectSelections] ([StudentId], [SubjectId]) VALUES (17, 12)
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([Id], [FullName]) VALUES (1, N'Profesor A')
INSERT [dbo].[Teacher] ([Id], [FullName]) VALUES (2, N'Profesor B')
INSERT [dbo].[Teacher] ([Id], [FullName]) VALUES (3, N'Profesor C')
INSERT [dbo].[Teacher] ([Id], [FullName]) VALUES (4, N'Profesor D')
INSERT [dbo].[Teacher] ([Id], [FullName]) VALUES (5, N'Profesor E')
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
/****** Object:  Index [IX_Subjects_TeacherId]    Script Date: 25/02/2025 1:49:58 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Subjects_TeacherId] ON [dbo].[Subjects]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubjectSelections_SubjectId]    Script Date: 25/02/2025 1:49:58 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_SubjectSelections_SubjectId] ON [dbo].[SubjectSelections]
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_Teacher_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subjects_Teacher_TeacherId]
GO
ALTER TABLE [dbo].[SubjectSelections]  WITH CHECK ADD  CONSTRAINT [FK_SubjectSelections_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubjectSelections] CHECK CONSTRAINT [FK_SubjectSelections_Students_StudentId]
GO
ALTER TABLE [dbo].[SubjectSelections]  WITH CHECK ADD  CONSTRAINT [FK_SubjectSelections_Subjects_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubjectSelections] CHECK CONSTRAINT [FK_SubjectSelections_Subjects_SubjectId]
GO
USE [master]
GO
ALTER DATABASE [StudentManagementInterRapidisimoDb] SET  READ_WRITE 
GO

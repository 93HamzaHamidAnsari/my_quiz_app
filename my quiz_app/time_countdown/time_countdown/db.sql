USE [master]
GO
/****** Object:  Database [quiz]    Script Date: 10/20/2016 4:05:16 PM ******/
CREATE DATABASE [quiz]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'quiz', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\quiz.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'quiz_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\quiz_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [quiz] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [quiz].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [quiz] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [quiz] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [quiz] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [quiz] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [quiz] SET ARITHABORT OFF 
GO
ALTER DATABASE [quiz] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [quiz] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [quiz] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [quiz] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [quiz] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [quiz] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [quiz] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [quiz] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [quiz] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [quiz] SET  DISABLE_BROKER 
GO
ALTER DATABASE [quiz] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [quiz] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [quiz] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [quiz] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [quiz] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [quiz] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [quiz] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [quiz] SET RECOVERY FULL 
GO
ALTER DATABASE [quiz] SET  MULTI_USER 
GO
ALTER DATABASE [quiz] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [quiz] SET DB_CHAINING OFF 
GO
ALTER DATABASE [quiz] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [quiz] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [quiz] SET DELAYED_DURABILITY = DISABLED 
GO
USE [quiz]
GO
/****** Object:  Table [dbo].[login]    Script Date: 10/20/2016 4:05:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[login](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[roll_no] [int] NULL,
	[status] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[marks]    Script Date: 10/20/2016 4:05:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[marks] [int] NULL,
	[std_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[myexcel$]    Script Date: 10/20/2016 4:05:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[myexcel$](
	[id] [int] NULL,
	[name] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[quiz_pro]    Script Date: 10/20/2016 4:05:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[quiz_pro](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](255) NULL,
	[ans1] [nvarchar](50) NULL,
	[ans2] [nvarchar](50) NULL,
	[ans3] [nvarchar](50) NULL,
	[r#ans] [nvarchar](50) NULL,
	[num] [int] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[login] ON 

INSERT [dbo].[login] ([id], [name], [password], [roll_no], [status]) VALUES (1, N'hamza', N'111', 1, 1)
INSERT [dbo].[login] ([id], [name], [password], [roll_no], [status]) VALUES (2, N'ali', N'222', 2, NULL)
INSERT [dbo].[login] ([id], [name], [password], [roll_no], [status]) VALUES (3, N'qaisar', N'333', 3, NULL)
SET IDENTITY_INSERT [dbo].[login] OFF
SET IDENTITY_INSERT [dbo].[marks] ON 

INSERT [dbo].[marks] ([id], [marks], [std_id]) VALUES (1, 6, 1)
INSERT [dbo].[marks] ([id], [marks], [std_id]) VALUES (2, 6, 2)
INSERT [dbo].[marks] ([id], [marks], [std_id]) VALUES (3, 6, 3)
INSERT [dbo].[marks] ([id], [marks], [std_id]) VALUES (4, 6, NULL)
INSERT [dbo].[marks] ([id], [marks], [std_id]) VALUES (5, 6, NULL)
SET IDENTITY_INSERT [dbo].[marks] OFF
INSERT [dbo].[myexcel$] ([id], [name]) VALUES (1, N'hamza')
INSERT [dbo].[myexcel$] ([id], [name]) VALUES (2, N'ali')
SET IDENTITY_INSERT [dbo].[quiz_pro] ON 

INSERT [dbo].[quiz_pro] ([id], [Question], [ans1], [ans2], [ans3], [r#ans], [num]) VALUES (1, N'Which number should come next in the series?1 - 1 - 2 - 3 - 5 - 8 - 13', N'8', N'13', N'21', N'21', 1)
INSERT [dbo].[quiz_pro] ([id], [Question], [ans1], [ans2], [ans3], [r#ans], [num]) VALUES (2, N'Which one of the five choices makes the best comparison? PEACH is to HCAEP as 46251 is to:', N'15264', N'15268', N'85215', N'15264', 1)
INSERT [dbo].[quiz_pro] ([id], [Question], [ans1], [ans2], [ans3], [r#ans], [num]) VALUES (3, N'Mary, who is sixteen years old, is four times as old as her brother. How old will Mary be when she is twice as old as her brother?', N'25', N'24', N'32', N'24', 1)
INSERT [dbo].[quiz_pro] ([id], [Question], [ans1], [ans2], [ans3], [r#ans], [num]) VALUES (4, N'Which one of the numbers does not belong in the following series?2 - 3 - 6 - 7 - 8 - 14 - 15 - 30', N'8', N'7', N'15', N'8', 1)
INSERT [dbo].[quiz_pro] ([id], [Question], [ans1], [ans2], [ans3], [r#ans], [num]) VALUES (5, N'The day after the day after tomorrow is four days before Monday. What day is it today?', N'Tuesday', N'Monday', N'Sunday', N'Monday', 1)
INSERT [dbo].[quiz_pro] ([id], [Question], [ans1], [ans2], [ans3], [r#ans], [num]) VALUES (6, N'Forest is to tree as tree is to ?', N'Tree', N'Leaf', N'Branch', N'Leaf', 1)
INSERT [dbo].[quiz_pro] ([id], [Question], [ans1], [ans2], [ans3], [r#ans], [num]) VALUES (7, N' If you rearrange the letters "CIFAIPC" you would have the name of a(n):', N'Ocean', N'River', N'Country', N'Ocean', 1)
INSERT [dbo].[quiz_pro] ([id], [Question], [ans1], [ans2], [ans3], [r#ans], [num]) VALUES (8, N'John needs 13 bottles of water from the store. John can only carry 3 at a time. What''s the minimum number of trips John needs to make to the store?', N'5', N'4', N'6', N'5', 1)
INSERT [dbo].[quiz_pro] ([id], [Question], [ans1], [ans2], [ans3], [r#ans], [num]) VALUES (9, N'If all Bloops are Razzies and all Razzies are Lazzies, then all Bloops are definitely Lazzies?', N'True', N'False', N'None of them', N'True', 1)
INSERT [dbo].[quiz_pro] ([id], [Question], [ans1], [ans2], [ans3], [r#ans], [num]) VALUES (10, N' Choose the word most similar to "Trustworthy":', N'Reliable', N'Relevant', N'Both A & B', N'Reliable', 2)
SET IDENTITY_INSERT [dbo].[quiz_pro] OFF
USE [master]
GO
ALTER DATABASE [quiz] SET  READ_WRITE 
GO

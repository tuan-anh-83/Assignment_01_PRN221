USE [master]
GO
/****** Object:  Database [BookManagement]    Script Date: 2/24/2024 4:55:13 PM ******/
CREATE DATABASE [BookManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.PHAMTUANANH\MSSQL\DATA\BookManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.PHAMTUANANH\MSSQL\DATA\BookManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BookManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BookManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [BookManagement] SET  MULTI_USER 
GO
ALTER DATABASE [BookManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookManagement', N'ON'
GO
ALTER DATABASE [BookManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [BookManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BookManagement]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 2/24/2024 4:55:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookId] [nvarchar](50) NOT NULL,
	[BookName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[ReleaseDate] [datetime] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[BookCategoryId] [nvarchar](50) NOT NULL,
	[Author] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookBorrow]    Script Date: 2/24/2024 4:55:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookBorrow](
	[BookBorrowId] [nvarchar](50) NOT NULL,
	[BookId] [nvarchar](50) NOT NULL,
	[MemberId] [nvarchar](50) NOT NULL,
	[BorrowDate] [datetime] NOT NULL,
	[ReturnDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BookBorrowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookCategory]    Script Date: 2/24/2024 4:55:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookCategory](
	[BookCategoryId] [nvarchar](50) NOT NULL,
	[BookGenreType] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BookCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookManagementMember]    Script Date: 2/24/2024 4:55:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookManagementMember](
	[MemberId] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[MemberRole] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Book] ([BookId], [BookName], [Description], [ReleaseDate], [Quantity], [Price], [BookCategoryId], [Author]) VALUES (N'BK01', N'Romeo and Juliet', N'Romeo and Juliet', CAST(N'2023-12-04T00:00:00.000' AS DateTime), 4, 22.5, N'Book 01', N'Romeo and Juliet')
INSERT [dbo].[Book] ([BookId], [BookName], [Description], [ReleaseDate], [Quantity], [Price], [BookCategoryId], [Author]) VALUES (N'Bk02', N'Thor', N'Strong human', CAST(N'2023-12-03T00:00:00.000' AS DateTime), 3, 44.9, N'Book 02', N'Amber')
INSERT [dbo].[Book] ([BookId], [BookName], [Description], [ReleaseDate], [Quantity], [Price], [BookCategoryId], [Author]) VALUES (N'Bk03', N'Hello', N'Hello', CAST(N'2024-02-08T00:00:00.000' AS DateTime), 4, 55, N'Book 03', N'Hello')
GO
INSERT [dbo].[BookBorrow] ([BookBorrowId], [BookId], [MemberId], [BorrowDate], [ReturnDate]) VALUES (N'BR 01', N'Bk01', N'Member', CAST(N'2023-12-05T00:00:00.000' AS DateTime), CAST(N'2023-12-07T00:00:00.000' AS DateTime))
INSERT [dbo].[BookBorrow] ([BookBorrowId], [BookId], [MemberId], [BorrowDate], [ReturnDate]) VALUES (N'BR 02', N'Bk02', N'Admin', CAST(N'2023-12-06T00:00:00.000' AS DateTime), CAST(N'2023-12-08T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[BookCategory] ([BookCategoryId], [BookGenreType], [Description]) VALUES (N'Book 01', N'Love Story', N'The story about 2 person')
INSERT [dbo].[BookCategory] ([BookCategoryId], [BookGenreType], [Description]) VALUES (N'Book 02', N'Legendary Story', N'Imagine')
INSERT [dbo].[BookCategory] ([BookCategoryId], [BookGenreType], [Description]) VALUES (N'Book 03', N'Fairy Tale', N'The stories talk about the king')
INSERT [dbo].[BookCategory] ([BookCategoryId], [BookGenreType], [Description]) VALUES (N'Book 05', N'Happy Ending', N'Happy')
GO
INSERT [dbo].[BookManagementMember] ([MemberId], [Password], [Email], [FullName], [MemberRole]) VALUES (N'Admin', N'admin123', N'admin@gmail.com', N'Jason Statham', 1)
INSERT [dbo].[BookManagementMember] ([MemberId], [Password], [Email], [FullName], [MemberRole]) VALUES (N'Member', N'member123', N'member@gmail.com', N'Steve Job', 2)
INSERT [dbo].[BookManagementMember] ([MemberId], [Password], [Email], [FullName], [MemberRole]) VALUES (N'Staff', N'staff123', N'staff@gmail.com', N'Nguyen Thu Hoai', 3)
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_BookCategory] FOREIGN KEY([BookCategoryId])
REFERENCES [dbo].[BookCategory] ([BookCategoryId])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_BookCategory]
GO
ALTER TABLE [dbo].[BookBorrow]  WITH CHECK ADD  CONSTRAINT [FK_BookBorrow_Book] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([BookId])
GO
ALTER TABLE [dbo].[BookBorrow] CHECK CONSTRAINT [FK_BookBorrow_Book]
GO
ALTER TABLE [dbo].[BookBorrow]  WITH CHECK ADD  CONSTRAINT [FK_BookBorrow_BookManagementMember] FOREIGN KEY([MemberId])
REFERENCES [dbo].[BookManagementMember] ([MemberId])
GO
ALTER TABLE [dbo].[BookBorrow] CHECK CONSTRAINT [FK_BookBorrow_BookManagementMember]
GO
USE [master]
GO
ALTER DATABASE [BookManagement] SET  READ_WRITE 
GO

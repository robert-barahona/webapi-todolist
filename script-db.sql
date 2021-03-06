USE [master]
GO
/****** Object:  Database [DB_A66912_dbtodolist]    Script Date: 8/9/2020 12:47:03 ******/
CREATE DATABASE [DB_A66912_dbtodolist]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_A66912_dbtodolist_Data', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DB_A66912_dbtodolist_DATA.mdf' , SIZE = 8192KB , MAXSIZE = 1024000KB , FILEGROWTH = 10%)
 LOG ON 
( NAME = N'DB_A66912_dbtodolist_Log', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DB_A66912_dbtodolist_Log.LDF' , SIZE = 3072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_A66912_dbtodolist].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET  MULTI_USER 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET QUERY_STORE = OFF
GO
USE [DB_A66912_dbtodolist]
GO
/****** Object:  Table [dbo].[Board]    Script Date: 8/9/2020 12:47:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Board](
	[id_board] [int] IDENTITY(1,1) NOT NULL,
	[name_board] [varchar](50) NOT NULL,
	[id_owner] [int] NOT NULL,
	[id_participants] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_board] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[List]    Script Date: 8/9/2020 12:47:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[List](
	[id_list] [int] IDENTITY(1,1) NOT NULL,
	[name_list] [varchar](20) NOT NULL,
	[id_board] [int] NOT NULL,
	[index_list] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_list] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 8/9/2020 12:47:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[id_task] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](200) NOT NULL,
	[descr] [varchar](1000) NULL,
	[asigned_to] [int] NULL,
	[id_list] [int] NOT NULL,
	[index_task] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_task] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/9/2020 12:47:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](50) NOT NULL,
	[last_name] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[pass] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Board] ON 

INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (1, N'Proyecto 1', 1, N'2 6')
INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (19, N'Proyecto X', 1, N'')
INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (24, N'Hola', 2, N'')
INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (25, N'Como estas', 2, N'')
INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (26, N't', 6, NULL)
INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (27, N'hj', 6, NULL)
INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (28, N'po', 6, NULL)
INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (29, N'sdfsdfsd', 6, N'')
INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (30, N'sadfasd', 2, N'')
INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (31, N'a', 9, N'')
INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (32, N'wqewqe', 15, N'')
INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (33, N'b', 10, NULL)
INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (34, N'c', 11, NULL)
INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (35, N'd', 12, NULL)
INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (36, N'456654', 14, N'')
INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (37, N'5667', 14, NULL)
INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (38, N'pol', 14, NULL)
INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (39, N'7884ewqr', 14, NULL)
INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (40, N'3dfsdf', 15, NULL)
INSERT [dbo].[Board] ([id_board], [name_board], [id_owner], [id_participants]) VALUES (41, N'ee', 13, NULL)
SET IDENTITY_INSERT [dbo].[Board] OFF
GO
SET IDENTITY_INSERT [dbo].[List] ON 

INSERT [dbo].[List] ([id_list], [name_list], [id_board], [index_list]) VALUES (1, N'Por Hacer', 1, 0)
INSERT [dbo].[List] ([id_list], [name_list], [id_board], [index_list]) VALUES (2, N'En Proceso', 1, 1)
INSERT [dbo].[List] ([id_list], [name_list], [id_board], [index_list]) VALUES (3, N'Terminado', 1, 2)
INSERT [dbo].[List] ([id_list], [name_list], [id_board], [index_list]) VALUES (15, N'aaa', 19, 0)
INSERT [dbo].[List] ([id_list], [name_list], [id_board], [index_list]) VALUES (25, N's', 19, 1)
SET IDENTITY_INSERT [dbo].[List] OFF
GO
SET IDENTITY_INSERT [dbo].[Task] ON 

INSERT [dbo].[Task] ([id_task], [title], [descr], [asigned_to], [id_list], [index_task]) VALUES (2, N'Tarea B', NULL, NULL, 2, 1)
INSERT [dbo].[Task] ([id_task], [title], [descr], [asigned_to], [id_list], [index_task]) VALUES (3, N'Tarea C', NULL, NULL, 1, 2)
INSERT [dbo].[Task] ([id_task], [title], [descr], [asigned_to], [id_list], [index_task]) VALUES (4, N'Tarea D dadas', N'adasdas', NULL, 3, 0)
INSERT [dbo].[Task] ([id_task], [title], [descr], [asigned_to], [id_list], [index_task]) VALUES (5, N'Tarea Es sa', NULL, NULL, 1, 1)
INSERT [dbo].[Task] ([id_task], [title], [descr], [asigned_to], [id_list], [index_task]) VALUES (6, N'Tarea F', NULL, NULL, 1, 0)
INSERT [dbo].[Task] ([id_task], [title], [descr], [asigned_to], [id_list], [index_task]) VALUES (7, N'Tarea G', N'dsad asdasdas', NULL, 2, 5)
INSERT [dbo].[Task] ([id_task], [title], [descr], [asigned_to], [id_list], [index_task]) VALUES (8, N'Tarea H', NULL, NULL, 3, 1)
INSERT [dbo].[Task] ([id_task], [title], [descr], [asigned_to], [id_list], [index_task]) VALUES (23, N'Tarea AA', NULL, NULL, 1, 3)
INSERT [dbo].[Task] ([id_task], [title], [descr], [asigned_to], [id_list], [index_task]) VALUES (27, N'as', NULL, NULL, 15, 0)
INSERT [dbo].[Task] ([id_task], [title], [descr], [asigned_to], [id_list], [index_task]) VALUES (29, N'sdsss', NULL, NULL, 15, 1)
INSERT [dbo].[Task] ([id_task], [title], [descr], [asigned_to], [id_list], [index_task]) VALUES (31, N'tt', NULL, NULL, 2, 4)
INSERT [dbo].[Task] ([id_task], [title], [descr], [asigned_to], [id_list], [index_task]) VALUES (35, N'rrrr', NULL, NULL, 1, 4)
SET IDENTITY_INSERT [dbo].[Task] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id_user], [first_name], [last_name], [email], [pass]) VALUES (1, N'Emilia Sandra', N'Castillo Lozano', N'castillo55@gmail.com', N'123')
INSERT [dbo].[Users] ([id_user], [first_name], [last_name], [email], [pass]) VALUES (2, N'Andres', N'Moya', N'andres-moya101@hotmail.com', N'12345678')
INSERT [dbo].[Users] ([id_user], [first_name], [last_name], [email], [pass]) VALUES (6, N'Test', N'Bot', N'test@gmail.com', N'123456')
INSERT [dbo].[Users] ([id_user], [first_name], [last_name], [email], [pass]) VALUES (9, N'aaa aaaa', N'aaaa aaa', N'aaaaaaa@example.com', N'aaaa')
INSERT [dbo].[Users] ([id_user], [first_name], [last_name], [email], [pass]) VALUES (10, N'bbb bbb', N'bbb bbb', N'bbbbb@example.com', N'bbbbb')
INSERT [dbo].[Users] ([id_user], [first_name], [last_name], [email], [pass]) VALUES (11, N'ccc ccccccc', N'ccccc ccc', N'ccccc@example.com', N'123')
INSERT [dbo].[Users] ([id_user], [first_name], [last_name], [email], [pass]) VALUES (12, N'dd ddd', N'dddd ddd', N'dddd@example.com', N'ddddd')
INSERT [dbo].[Users] ([id_user], [first_name], [last_name], [email], [pass]) VALUES (13, N'eeeee eeeee', N'eeee eeeee', N'eeeeee@example.com', N'eeeeee')
INSERT [dbo].[Users] ([id_user], [first_name], [last_name], [email], [pass]) VALUES (14, N'ffff ffff', N'ffff ffff', N'fffffff@example.com', N'123')
INSERT [dbo].[Users] ([id_user], [first_name], [last_name], [email], [pass]) VALUES (15, N'gggg gggg', N'gggg ggggg', N'ggggg@gmail.com', N'gggg')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Board]  WITH CHECK ADD  CONSTRAINT [fk_User] FOREIGN KEY([id_owner])
REFERENCES [dbo].[Users] ([id_user])
GO
ALTER TABLE [dbo].[Board] CHECK CONSTRAINT [fk_User]
GO
ALTER TABLE [dbo].[List]  WITH CHECK ADD  CONSTRAINT [fk_Board] FOREIGN KEY([id_board])
REFERENCES [dbo].[Board] ([id_board])
GO
ALTER TABLE [dbo].[List] CHECK CONSTRAINT [fk_Board]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_List] FOREIGN KEY([id_list])
REFERENCES [dbo].[List] ([id_list])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_List]
GO
/****** Object:  StoredProcedure [dbo].[rptUsuariosxLista]    Script Date: 8/9/2020 12:47:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rptUsuariosxLista]
	-- Add the parameters for the stored procedure here
	@num_us int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		SELECT TOP (@num_us) us.id_user as Usuario, count(br.id_owner) as Tableros FROM dbo.Users AS us INNER JOIN dbo.Board as br ON us.id_user = br.id_owner
	GROUP BY us.id_user, br.id_owner
END
GO
/****** Object:  StoredProcedure [dbo].[rtpUxT]    Script Date: 8/9/2020 12:47:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rtpUxT]
	-- Add the parameters for the stored procedure here
	@num_us int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if(@num_us = 0)
		SELECT us.id_user as Usuario, count(br.id_owner) as Tableros FROM dbo.Users AS us INNER JOIN dbo.Board as br ON us.id_user = br.id_owner
		GROUP BY us.id_user, br.id_owner
	else
		SELECT TOP (@num_us) us.id_user as Usuario, count(br.id_owner) as Tableros FROM dbo.Users AS us INNER JOIN dbo.Board as br ON us.id_user = br.id_owner
		GROUP BY us.id_user, br.id_owner
	
			
END
GO
/****** Object:  StoredProcedure [dbo].[TablerosxUsuarios]    Script Date: 8/9/2020 12:47:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TablerosxUsuarios]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 25 us.id_user as Usuario, count(br.id_owner) as Tableros FROM dbo.Users AS us INNER JOIN dbo.Board as br ON us.id_user = br.id_owner
	GROUP BY us.id_user, br.id_owner
END
GO
USE [master]
GO
ALTER DATABASE [DB_A66912_dbtodolist] SET  READ_WRITE 
GO

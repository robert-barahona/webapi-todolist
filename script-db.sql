USE [dbtodolist]
GO
/****** Object:  Table [dbo].[Board]    Script Date: 6/8/2020 3:01:24 ******/
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
/****** Object:  Table [dbo].[List]    Script Date: 6/8/2020 3:01:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[List](
	[id_list] [int] IDENTITY(1,1) NOT NULL,
	[name_list] [varchar](20) NOT NULL,
	[id_board] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_list] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 6/8/2020 3:01:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[id_task] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](20) NOT NULL,
	[descr] [varchar](100) NOT NULL,
	[asigned_to] [int] NULL,
	[id_list] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_task] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/8/2020 3:01:24 ******/
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

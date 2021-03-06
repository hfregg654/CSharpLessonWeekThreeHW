USE [ProjectImmediateReply]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 2021/4/3 下午 01:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[GradeID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[PresidentProjectGrade] [tinyint] NOT NULL,
	[PresidentInterviewGrade] [tinyint] NOT NULL,
	[PresidentComments] [nvarchar](max) NULL,
	[PMProjectGrade] [tinyint] NOT NULL,
	[PMInterviewGrade] [tinyint] NOT NULL,
	[PMComments] [nvarchar](max) NULL,
	[CreateDate] [datetime] NOT NULL,
	[WhoCreate] [nvarchar](50) NOT NULL,
	[DeleteDate] [datetime] NULL,
	[WhoDelete] [nvarchar](50) NULL,
 CONSTRAINT [PK_Grades_1] PRIMARY KEY CLUSTERED 
(
	[GradeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 2021/4/3 下午 01:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](50) NOT NULL,
	[TeamID] [int] NOT NULL,
	[TeamName] [nvarchar](50) NOT NULL,
	[WorkID] [varchar](255) NULL,
	[Schedule] [float] NULL,
	[DeadLine] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[WhoCreate] [nvarchar](50) NOT NULL,
	[DeleteDate] [datetime] NULL,
	[WhoDelete] [nvarchar](50) NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2021/4/3 下午 01:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Account] [varchar](255) NULL,
	[PassWord] [varchar](255) NULL,
	[Name] [nvarchar](50) NULL,
	[Phone] [char](10) NULL,
	[Mail] [varchar](255) NULL,
	[LineID] [varchar](255) NULL,
	[ClassNumber] [char](10) NULL,
	[License] [char](16) NOT NULL,
	[ProjectID] [int] NULL,
	[TeamID] [int] NULL,
	[TeamName] [nvarchar](50) NULL,
	[WorkID] [varchar](255) NULL,
	[Privilege] [varchar](16) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[WhoCreate] [nvarchar](50) NOT NULL,
	[DeleteDate] [datetime] NULL,
	[WhoDelete] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Works]    Script Date: 2021/4/3 下午 01:02:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Works](
	[ProjectID] [int] NOT NULL,
	[TeamID] [int] NOT NULL,
	[WorkID] [int] IDENTITY(1,1) NOT NULL,
	[Work] [nvarchar](255) NOT NULL,
	[WorkDescription] [nvarchar](max) NULL,
	[DeadLine] [datetime] NOT NULL,
	[FilePath] [varchar](max) NULL,
	[UpdateTime] [datetime] NULL,
	[SpendTime] [datetime] NULL,
	[CreateDate] [datetime] NOT NULL,
	[WhoCreate] [nvarchar](50) NOT NULL,
	[DeleteTime] [datetime] NULL,
	[WhoDelete] [nvarchar](50) NULL,
 CONSTRAINT [PK_Works] PRIMARY KEY CLUSTERED 
(
	[WorkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Projects1] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ProjectID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Projects1]
GO
ALTER TABLE [dbo].[Works]  WITH CHECK ADD  CONSTRAINT [FK_Works_Projects1] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ProjectID])
GO
ALTER TABLE [dbo].[Works] CHECK CONSTRAINT [FK_Works_Projects1]
GO

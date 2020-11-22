USE [LimbaBackOfficeDB]
GO

/****** Object:  Table [WorkSpaceUser]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

DROP TABLE IF EXISTS dbo.WorkSpaceUser
GO

CREATE TABLE [WorkSpaceUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkSpaceId] [int] NOT NULL,
	[AppUserId] [int] NOT NULL,
	[Position] [varchar](50) NULL,
	[DepartmentId] [int] NULL,
	[AccessLevel] [int] NOT NULL,

 CONSTRAINT [PK_WorkSpaceUser] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** End:  Table [WorkSpaceUser]  ******/
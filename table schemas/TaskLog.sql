USE [LimbaBackOfficeDB]
GO

/****** Object: Table [TaskLog]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

DROP TABLE IF EXISTS dbo.TaskLog
GO

CREATE TABLE [TaskLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkSpaceUserId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Category] [int] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[Note] [varchar](500) NULL,

 CONSTRAINT [PK_TaskLog] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** End: Table [TaskLog]  ******/

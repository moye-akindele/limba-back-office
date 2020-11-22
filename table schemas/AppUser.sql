USE [LimbaBackOfficeDB]
GO

/****** Object: Table [AppUser]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

DROP TABLE IF EXISTS dbo.AppUser
GO

CREATE TABLE [AppUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[ForcePasswordReset] [bit] Not NULL DEFAULT 0,
	--[LastLogin] [varchar](50) NULL,
	--[Status] [varchar](50) NULL,

 CONSTRAINT [PK_AppUser] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** End: Table [AppUser]  ******/



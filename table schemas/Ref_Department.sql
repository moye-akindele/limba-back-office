/****** Table Schema  ******/

USE [LimbaBackOfficeDB]
GO

/****** Object:  Table [Ref_Department]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

DROP TABLE IF EXISTS dbo.Ref_Department
GO

CREATE TABLE [Ref_Department](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Name] [varchar](50) Not NULL,
	[Description] [varchar](500) NULL,
	[InternalType] [bit] Not NULL DEFAULT 0,
	[WorkSpaceId] [int] NULL,

 CONSTRAINT [PK_Ref_Department] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** End:  Table [Ref_Department]  ******/

/****** Table Data  ******/

USE [LimbaBackOfficeDB]
GO

/****** Object:  Table [Ref_Department]  ******/

INSERT INTO Ref_Department 
	([Name], [Description], [InternalType])
VALUES 
	('Pseudo department', 'Default value in lieu of selected department.', 1),
	('Accounting', 'Accounting and Finance', 1),
	('Admin', '', 1),
	('Customer Support', '', 1),
	('Directorate', 'Group for executive positions e.g. CEO and Board of Directors.', 1),
	('Engineering', '', 1),
	('Human Resources', '', 1),
	('Information technology', '', 1),
	('Marketing', '', 1),
	('Operations', '', 1),
	('Production', '', 1),
	('Sales', '', 1),
	('Security', '', 1),
	('Software Engineering', '', 1);
GO

/****** End:  Table [Ref_Department]  ******/



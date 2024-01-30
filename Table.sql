

====================================
Download Both BE and FE and execute the Below Table Script
FE 
- Install NPM

BE 
- BE Should be executed on Below Port
  https://localhost:7191




===================================
CREATE DATABASE TaskManagement;

USE [TaskManagement]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskItemEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Description] [varchar](max) NULL,
	[TaskId] [int] NOT NULL,
	[DueDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


SET IDENTITY_INSERT [dbo].[TaskStatus] ON 
INSERT [dbo].[TaskStatus] ([Id], [Name]) VALUES (1, N'To Do')
INSERT [dbo].[TaskStatus] ([Id], [Name]) VALUES (2, N'In Progress')
INSERT [dbo].[TaskStatus] ([Id], [Name]) VALUES (3, N'Done')
SET IDENTITY_INSERT [dbo].[TaskStatus] OFF
GO


ALTER TABLE [dbo].[TaskItemEntity]  WITH CHECK ADD  CONSTRAINT [FK_TaskItemEntity_TaskStatus] FOREIGN KEY([TaskId])
REFERENCES [dbo].[TaskStatus] ([Id])
GO
ALTER TABLE [dbo].[TaskItemEntity] CHECK CONSTRAINT [FK_TaskItemEntity_TaskStatus]
GO
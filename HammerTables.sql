USE [Hammer]
GO
/****** Object:  Table [dbo].[Hammers]    Script Date: 8/18/2016 2:00:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Hammers](
	[HammerId] [int] IDENTITY(1,1) NOT NULL,
	[HammerName] [varchar](500) NOT NULL,
	[HammerDescription] [nvarchar](1000) NULL,
	[IsActive] [bit] NOT NULL,
	[TypeId] [int] NOT NULL,
	[CreatedBy] [varchar](500) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](500) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Hammers] PRIMARY KEY CLUSTERED 
(
	[HammerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HammerTypes]    Script Date: 8/18/2016 2:00:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HammerTypes](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](500) NOT NULL,
	[TypeDesc] [varchar](1000) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [varchar](500) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](500) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_HammerTypes] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Hammers] ON 

GO
INSERT [dbo].[Hammers] ([HammerId], [HammerName], [HammerDescription], [IsActive], [TypeId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'Hammer 1', N'test desc1', 1, 1, N'SYSTEM', CAST(N'2016-08-04 16:27:04.617' AS DateTime), N'SYSTEM', CAST(N'2016-08-04 12:03:29.490' AS DateTime))
GO
INSERT [dbo].[Hammers] ([HammerId], [HammerName], [HammerDescription], [IsActive], [TypeId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'Hammer 2', N'test desc2', 1, 4, N'SYSTEM', CAST(N'2016-08-04 17:11:52.420' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Hammers] ([HammerId], [HammerName], [HammerDescription], [IsActive], [TypeId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'Hammer 3', N'test desc3', 1, 5, N'SYSTEM', CAST(N'2016-08-04 12:01:29.557' AS DateTime), N'SYSTEM', CAST(N'2016-08-04 12:03:36.187' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Hammers] OFF
GO
SET IDENTITY_INSERT [dbo].[HammerTypes] ON 

GO
INSERT [dbo].[HammerTypes] ([TypeId], [TypeName], [TypeDesc], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Type 100', N'test 1', 1, N'SYSTEM', CAST(N'2016-08-04 13:12:18.010' AS DateTime), N'SYSTEM', CAST(N'2016-08-04 17:25:09.533' AS DateTime))
GO
INSERT [dbo].[HammerTypes] ([TypeId], [TypeName], [TypeDesc], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'Type2', N'test 2', 1, N'SYSTEM', CAST(N'2016-08-04 14:05:04.657' AS DateTime), N'SYSTEM', CAST(N'2016-08-04 17:25:26.283' AS DateTime))
GO
INSERT [dbo].[HammerTypes] ([TypeId], [TypeName], [TypeDesc], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (5, N'Type 3', N'test 3', 1, N'SYSTEM', CAST(N'2016-08-04 17:12:10.707' AS DateTime), N'SYSTEM', CAST(N'2016-08-04 17:25:32.437' AS DateTime))
GO
INSERT [dbo].[HammerTypes] ([TypeId], [TypeName], [TypeDesc], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (6, N'Type 4', N'test 4', 1, N'SYSTEM', CAST(N'2016-08-04 17:12:20.917' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[HammerTypes] ([TypeId], [TypeName], [TypeDesc], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (7, N'Type 5', N'test 5', 1, N'SYSTEM', CAST(N'2016-08-04 17:12:31.173' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[HammerTypes] ([TypeId], [TypeName], [TypeDesc], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (8, N'Type 6', N'test 6', 1, N'SYSTEM', CAST(N'2016-08-04 17:12:41.777' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[HammerTypes] ([TypeId], [TypeName], [TypeDesc], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (9, N'Type 7', N'test 7', 1, N'SYSTEM', CAST(N'2016-08-04 17:12:50.683' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[HammerTypes] ([TypeId], [TypeName], [TypeDesc], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (10, N'Type 8', N'test8', 1, N'SYSTEM', CAST(N'2016-08-04 17:13:01.717' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[HammerTypes] ([TypeId], [TypeName], [TypeDesc], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (11, N'Type 9', N'test 9', 1, N'SYSTEM', CAST(N'2016-08-04 17:13:16.280' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[HammerTypes] ([TypeId], [TypeName], [TypeDesc], [IsActive], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (12, N'Type 10', N'test 10', 1, N'SYSTEM', CAST(N'2016-08-04 17:13:26.450' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[HammerTypes] OFF
GO
ALTER TABLE [dbo].[Hammers]  WITH CHECK ADD  CONSTRAINT [FK_Hammers_HammerTypes] FOREIGN KEY([TypeId])
REFERENCES [dbo].[HammerTypes] ([TypeId])
GO
ALTER TABLE [dbo].[Hammers] CHECK CONSTRAINT [FK_Hammers_HammerTypes]
GO

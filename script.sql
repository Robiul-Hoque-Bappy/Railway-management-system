 
CREATE TABLE [dbo].[DaysList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DayName] [nvarchar](50) NULL,
 CONSTRAINT [PK_DaysList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Main_Schedule]    Script Date: 3/10/2020 12:24:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Main_Schedule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TrainId] [int] NULL,
	[SubRouteId] [int] NULL,
	[RouteId] [int] NULL,
	[Day] [nvarchar](30) NULL,
	[ArrivalTime] [float] NULL,
	[DepartureTime] [float] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Main_Schedule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Main_Schedule_Details]    Script Date: 3/10/2020 12:24:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Main_Schedule_Details](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Day] [nvarchar](50) NULL,
	[RouteId] [int] NULL,
	[ArrivalTime] [float] NULL,
	[ReachedTime] [float] NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Main_Schedule_Details] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Route]    Script Date: 3/10/2020 12:24:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Route](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[station]    Script Date: 3/10/2020 12:24:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[station](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
 CONSTRAINT [PK_station] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sub_Route]    Script Date: 3/10/2020 12:24:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sub_Route](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Station_Name] [nvarchar](50) NULL,
	[RouteId] [int] NULL,
	[Distance] [float] NULL,
	[ShortOrder] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Sub_Route] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[train]    Script Date: 3/10/2020 12:24:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[train](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[speed] [float] NULL,
 CONSTRAINT [PK_train] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTable]    Script Date: 3/10/2020 12:24:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[UserPassword] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DaysList] ON 

INSERT [dbo].[DaysList] ([Id], [DayName]) VALUES (1, N'Saturday')
INSERT [dbo].[DaysList] ([Id], [DayName]) VALUES (2, N'Sunday')
INSERT [dbo].[DaysList] ([Id], [DayName]) VALUES (3, N'Monday')
INSERT [dbo].[DaysList] ([Id], [DayName]) VALUES (4, N'Tuesday')
INSERT [dbo].[DaysList] ([Id], [DayName]) VALUES (5, N'Wednesday')
INSERT [dbo].[DaysList] ([Id], [DayName]) VALUES (6, N'Thursday')
INSERT [dbo].[DaysList] ([Id], [DayName]) VALUES (7, N'Friday')
SET IDENTITY_INSERT [dbo].[DaysList] OFF
SET IDENTITY_INSERT [dbo].[Main_Schedule] ON 

INSERT [dbo].[Main_Schedule] ([Id], [TrainId], [SubRouteId], [RouteId], [Day], [ArrivalTime], [DepartureTime], [IsActive]) VALUES (9, 1, 1, 1, N'Saturday', 10.16, 10.26, 1)
INSERT [dbo].[Main_Schedule] ([Id], [TrainId], [SubRouteId], [RouteId], [Day], [ArrivalTime], [DepartureTime], [IsActive]) VALUES (10, 1, 2, 1, N'Saturday', 10.5, 11, 1)
INSERT [dbo].[Main_Schedule] ([Id], [TrainId], [SubRouteId], [RouteId], [Day], [ArrivalTime], [DepartureTime], [IsActive]) VALUES (11, 1, 3, 1, N'Saturday', 11.24, 11.34, 1)
INSERT [dbo].[Main_Schedule] ([Id], [TrainId], [SubRouteId], [RouteId], [Day], [ArrivalTime], [DepartureTime], [IsActive]) VALUES (12, 1, 4, 1, N'Saturday', 11.44, 11.54, 1)
INSERT [dbo].[Main_Schedule] ([Id], [TrainId], [SubRouteId], [RouteId], [Day], [ArrivalTime], [DepartureTime], [IsActive]) VALUES (13, 4, 5, 2, N'Wednesday', 15.3, 15.4, 1)
INSERT [dbo].[Main_Schedule] ([Id], [TrainId], [SubRouteId], [RouteId], [Day], [ArrivalTime], [DepartureTime], [IsActive]) VALUES (14, 4, 6, 2, N'Wednesday', 16.02, 16.12, 1)
INSERT [dbo].[Main_Schedule] ([Id], [TrainId], [SubRouteId], [RouteId], [Day], [ArrivalTime], [DepartureTime], [IsActive]) VALUES (15, 4, 7, 2, N'Wednesday', 17.5, 18, 1)
INSERT [dbo].[Main_Schedule] ([Id], [TrainId], [SubRouteId], [RouteId], [Day], [ArrivalTime], [DepartureTime], [IsActive]) VALUES (16, 4, 8, 2, N'Wednesday', 19, 19.1, 1)
INSERT [dbo].[Main_Schedule] ([Id], [TrainId], [SubRouteId], [RouteId], [Day], [ArrivalTime], [DepartureTime], [IsActive]) VALUES (17, 4, 9, 2, N'Wednesday', 22.1, 22.2, 1)
SET IDENTITY_INSERT [dbo].[Main_Schedule] OFF
SET IDENTITY_INSERT [dbo].[Route] ON 

INSERT [dbo].[Route] ([Id], [Name], [IsActive]) VALUES (1, N'Dhaka to Mymensingh', 1)
INSERT [dbo].[Route] ([Id], [Name], [IsActive]) VALUES (2, N'Dhaka to Sylhet', 1)
SET IDENTITY_INSERT [dbo].[Route] OFF
SET IDENTITY_INSERT [dbo].[station] ON 

INSERT [dbo].[station] ([id], [name]) VALUES (1, N'Dhaka')
INSERT [dbo].[station] ([id], [name]) VALUES (2, N'Airport')
INSERT [dbo].[station] ([id], [name]) VALUES (3, N'Tongi')
INSERT [dbo].[station] ([id], [name]) VALUES (4, N'Chittagong')
INSERT [dbo].[station] ([id], [name]) VALUES (6, N'Sylhet')
INSERT [dbo].[station] ([id], [name]) VALUES (7, N'Norshindi')
INSERT [dbo].[station] ([id], [name]) VALUES (8, N'Bhairab')
INSERT [dbo].[station] ([id], [name]) VALUES (9, N'Brahmanbaria')
INSERT [dbo].[station] ([id], [name]) VALUES (10, N'
Akhaura')
INSERT [dbo].[station] ([id], [name]) VALUES (11, N'Comilla')
INSERT [dbo].[station] ([id], [name]) VALUES (12, N'Mymensingh')
INSERT [dbo].[station] ([id], [name]) VALUES (13, N'Rajshahi')
INSERT [dbo].[station] ([id], [name]) VALUES (14, N'Pabna')
INSERT [dbo].[station] ([id], [name]) VALUES (15, N'Rangpur')
INSERT [dbo].[station] ([id], [name]) VALUES (16, N'Kaunia')
INSERT [dbo].[station] ([id], [name]) VALUES (17, N'Dinajpur')
INSERT [dbo].[station] ([id], [name]) VALUES (18, N'Chilahati')
INSERT [dbo].[station] ([id], [name]) VALUES (19, N'Panchabibi')
INSERT [dbo].[station] ([id], [name]) VALUES (20, N'Joypurhat')
INSERT [dbo].[station] ([id], [name]) VALUES (21, N'Jamalganj')
INSERT [dbo].[station] ([id], [name]) VALUES (22, N'Jafarpur')
INSERT [dbo].[station] ([id], [name]) VALUES (23, N'Akkelpur')
INSERT [dbo].[station] ([id], [name]) VALUES (24, N'Rohanpur')
SET IDENTITY_INSERT [dbo].[station] OFF
SET IDENTITY_INSERT [dbo].[Sub_Route] ON 

INSERT [dbo].[Sub_Route] ([Id], [Station_Name], [RouteId], [Distance], [ShortOrder], [IsActive]) VALUES (1, N'Mymensingh', 1, 20, 3, 1)
INSERT [dbo].[Sub_Route] ([Id], [Station_Name], [RouteId], [Distance], [ShortOrder], [IsActive]) VALUES (2, N'Dhaka', 1, 30, 1, 1)
INSERT [dbo].[Sub_Route] ([Id], [Station_Name], [RouteId], [Distance], [ShortOrder], [IsActive]) VALUES (3, N'Tongi', 1, 30, 2, 1)
INSERT [dbo].[Sub_Route] ([Id], [Station_Name], [RouteId], [Distance], [ShortOrder], [IsActive]) VALUES (4, N'Dhaka', 1, 12, 4, 0)
INSERT [dbo].[Sub_Route] ([Id], [Station_Name], [RouteId], [Distance], [ShortOrder], [IsActive]) VALUES (5, N'Dhaka', 2, 0, 1, 0)
INSERT [dbo].[Sub_Route] ([Id], [Station_Name], [RouteId], [Distance], [ShortOrder], [IsActive]) VALUES (6, N'Airport', 2, 15, 2, 0)
INSERT [dbo].[Sub_Route] ([Id], [Station_Name], [RouteId], [Distance], [ShortOrder], [IsActive]) VALUES (7, N'Norshindi', 2, 65, 3, 1)
INSERT [dbo].[Sub_Route] ([Id], [Station_Name], [RouteId], [Distance], [ShortOrder], [IsActive]) VALUES (8, N'Bhairab', 2, 40, 4, 0)
INSERT [dbo].[Sub_Route] ([Id], [Station_Name], [RouteId], [Distance], [ShortOrder], [IsActive]) VALUES (9, N'Sylhet', 2, 120, 5, 0)
SET IDENTITY_INSERT [dbo].[Sub_Route] OFF
SET IDENTITY_INSERT [dbo].[train] ON 

INSERT [dbo].[train] ([id], [name], [speed]) VALUES (1, N'Tista express', 75)
INSERT [dbo].[train] ([id], [name], [speed]) VALUES (2, N'Egarosindhur godhuli', 55)
INSERT [dbo].[train] ([id], [name], [speed]) VALUES (3, N'Jamuna', 45)
INSERT [dbo].[train] ([id], [name], [speed]) VALUES (4, N'Simanto Rxpress', 40)
SET IDENTITY_INSERT [dbo].[train] OFF
ALTER TABLE [dbo].[Main_Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Main_Schedule_Main_Schedule_Route] FOREIGN KEY([RouteId])
REFERENCES [dbo].[Route] ([Id])
GO
ALTER TABLE [dbo].[Main_Schedule] CHECK CONSTRAINT [FK_Main_Schedule_Main_Schedule_Route]
GO
ALTER TABLE [dbo].[Main_Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Main_Schedule_train] FOREIGN KEY([TrainId])
REFERENCES [dbo].[train] ([id])
GO
ALTER TABLE [dbo].[Main_Schedule] CHECK CONSTRAINT [FK_Main_Schedule_train]
GO
ALTER TABLE [dbo].[Main_Schedule_Details]  WITH CHECK ADD  CONSTRAINT [FK_Main_Schedule_Details_Route] FOREIGN KEY([RouteId])
REFERENCES [dbo].[Route] ([Id])
GO
ALTER TABLE [dbo].[Main_Schedule_Details] CHECK CONSTRAINT [FK_Main_Schedule_Details_Route]
GO
ALTER TABLE [dbo].[Sub_Route]  WITH CHECK ADD  CONSTRAINT [FK_Sub_Route_Route] FOREIGN KEY([RouteId])
REFERENCES [dbo].[Route] ([Id])
GO
ALTER TABLE [dbo].[Sub_Route] CHECK CONSTRAINT [FK_Sub_Route_Route]
GO
USE [master]
GO
ALTER DATABASE [RailwayMSDb] SET  READ_WRITE 
GO

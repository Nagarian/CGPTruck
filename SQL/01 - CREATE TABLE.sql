USE [CGPTruck]
GO
/****** Object:  Table [dbo].[Attachments]    Script Date: 22/01/2016 15:11:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attachments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Path] [nvarchar](50) NULL,
	[Mission_Id] [int] NULL,
	[Failure_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FailureDetails]    Script Date: 22/01/2016 15:11:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FailureDetails](
	[Failure_Id] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Write_Date] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Failure_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Failures]    Script Date: 22/01/2016 15:11:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Failures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Vehicule_Id] [int] NOT NULL,
	[State] [int] NOT NULL,
	[Mission_id] [int] NOT NULL,
	[Failure_Detail_Id] [int] NULL,
	[Repairer_Id] [int] NULL,
	[Repairer_Vehicule_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Missions]    Script Date: 22/01/2016 15:11:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Missions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Date] [date] NOT NULL,
	[Vehicule_Id] [int] NOT NULL,
	[Driver_Id] [int] NOT NULL,
	[Pickup_Place_Id] [int] NOT NULL,
	[Delivery_Place_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Phones]    Script Date: 22/01/2016 15:11:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Serial_Code] [nvarchar](50) NOT NULL,
	[Phone_State] [int] NOT NULL,
 CONSTRAINT [PK_Phones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Places]    Script Date: 22/01/2016 15:11:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Places](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Position_Id] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Place_Type] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Places] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Positions]    Script Date: 22/01/2016 15:11:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Longitude] [float] NOT NULL,
	[Latitude] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Steps]    Script Date: 22/01/2016 15:11:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Steps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StepNumber] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Position_Id] [int] NOT NULL,
	[Informations] [nvarchar](max) NULL,
	[Step_Type] [int] NOT NULL,
	[Mission_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 22/01/2016 15:11:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AspNetId] [nvarchar](128) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Birthday] [date] NOT NULL,
	[Sexe] [bit] NOT NULL,
	[AccountType] [int] NOT NULL,
	[DriverLicenseType] [int] NOT NULL,
	[Active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsersPhones]    Script Date: 22/01/2016 15:11:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersPhones](
	[User_Id] [int] NOT NULL,
	[Phone_Id] [int] NOT NULL,
 CONSTRAINT [UQ_UsersPhones_Phone] UNIQUE NONCLUSTERED 
(
	[Phone_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_UsersPhones_User] UNIQUE NONCLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vehicules]    Script Date: 22/01/2016 15:11:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Position_Id] [int] NOT NULL,
	[Brand] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Vehicule_State] [int] NOT NULL,
	[Vehicule_Type] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Vehicules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Attachments]  WITH CHECK ADD  CONSTRAINT [FK_Attachments_Failure_Detail] FOREIGN KEY([Failure_Id])
REFERENCES [dbo].[FailureDetails] ([Failure_Id])
GO
ALTER TABLE [dbo].[Attachments] CHECK CONSTRAINT [FK_Attachments_Failure_Detail]
GO
ALTER TABLE [dbo].[Attachments]  WITH CHECK ADD  CONSTRAINT [FK_Attachments_Mission] FOREIGN KEY([Mission_Id])
REFERENCES [dbo].[Missions] ([Id])
GO
ALTER TABLE [dbo].[Attachments] CHECK CONSTRAINT [FK_Attachments_Mission]
GO
ALTER TABLE [dbo].[FailureDetails]  WITH CHECK ADD  CONSTRAINT [FK_FailureDetails_Failure] FOREIGN KEY([Failure_Id])
REFERENCES [dbo].[Failures] ([Id])
GO
ALTER TABLE [dbo].[FailureDetails] CHECK CONSTRAINT [FK_FailureDetails_Failure]
GO
ALTER TABLE [dbo].[Failures]  WITH CHECK ADD  CONSTRAINT [FK_Failures_Mission] FOREIGN KEY([Mission_id])
REFERENCES [dbo].[Missions] ([Id])
GO
ALTER TABLE [dbo].[Failures] CHECK CONSTRAINT [FK_Failures_Mission]
GO
ALTER TABLE [dbo].[Failures]  WITH CHECK ADD  CONSTRAINT [FK_Failures_Repairer] FOREIGN KEY([Repairer_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Failures] CHECK CONSTRAINT [FK_Failures_Repairer]
GO
ALTER TABLE [dbo].[Failures]  WITH CHECK ADD  CONSTRAINT [FK_Failures_Repairer_Vehicule] FOREIGN KEY([Repairer_Vehicule_Id])
REFERENCES [dbo].[Vehicules] ([Id])
GO
ALTER TABLE [dbo].[Failures] CHECK CONSTRAINT [FK_Failures_Repairer_Vehicule]
GO
ALTER TABLE [dbo].[Failures]  WITH CHECK ADD  CONSTRAINT [FK_Failures_Vehicule] FOREIGN KEY([Vehicule_Id])
REFERENCES [dbo].[Vehicules] ([Id])
GO
ALTER TABLE [dbo].[Failures] CHECK CONSTRAINT [FK_Failures_Vehicule]
GO
ALTER TABLE [dbo].[Missions]  WITH CHECK ADD  CONSTRAINT [FK_Missions_Delivery_Place] FOREIGN KEY([Delivery_Place_Id])
REFERENCES [dbo].[Places] ([Id])
GO
ALTER TABLE [dbo].[Missions] CHECK CONSTRAINT [FK_Missions_Delivery_Place]
GO
ALTER TABLE [dbo].[Missions]  WITH CHECK ADD  CONSTRAINT [FK_Missions_Driver] FOREIGN KEY([Driver_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Missions] CHECK CONSTRAINT [FK_Missions_Driver]
GO
ALTER TABLE [dbo].[Missions]  WITH CHECK ADD  CONSTRAINT [FK_Missions_Pickup_Place] FOREIGN KEY([Pickup_Place_Id])
REFERENCES [dbo].[Places] ([Id])
GO
ALTER TABLE [dbo].[Missions] CHECK CONSTRAINT [FK_Missions_Pickup_Place]
GO
ALTER TABLE [dbo].[Missions]  WITH CHECK ADD  CONSTRAINT [FK_Missions_Vehicule] FOREIGN KEY([Vehicule_Id])
REFERENCES [dbo].[Vehicules] ([Id])
GO
ALTER TABLE [dbo].[Missions] CHECK CONSTRAINT [FK_Missions_Vehicule]
GO
ALTER TABLE [dbo].[Places]  WITH CHECK ADD  CONSTRAINT [FK_Places_Position] FOREIGN KEY([Position_Id])
REFERENCES [dbo].[Positions] ([Id])
GO
ALTER TABLE [dbo].[Places] CHECK CONSTRAINT [FK_Places_Position]
GO
ALTER TABLE [dbo].[Steps]  WITH CHECK ADD  CONSTRAINT [FK_Step_Mission] FOREIGN KEY([Mission_Id])
REFERENCES [dbo].[Missions] ([Id])
GO
ALTER TABLE [dbo].[Steps] CHECK CONSTRAINT [FK_Step_Mission]
GO
ALTER TABLE [dbo].[Steps]  WITH CHECK ADD  CONSTRAINT [FK_Step_Position] FOREIGN KEY([Position_Id])
REFERENCES [dbo].[Positions] ([Id])
GO
ALTER TABLE [dbo].[Steps] CHECK CONSTRAINT [FK_Step_Position]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_AspNet] FOREIGN KEY([AspNetId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_AspNet]
GO
ALTER TABLE [dbo].[UsersPhones]  WITH CHECK ADD  CONSTRAINT [FK_UsersPhones_Phone] FOREIGN KEY([Phone_Id])
REFERENCES [dbo].[Phones] ([Id])
GO
ALTER TABLE [dbo].[UsersPhones] CHECK CONSTRAINT [FK_UsersPhones_Phone]
GO
ALTER TABLE [dbo].[UsersPhones]  WITH CHECK ADD  CONSTRAINT [FK_UsersPhones_User] FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UsersPhones] CHECK CONSTRAINT [FK_UsersPhones_User]
GO
ALTER TABLE [dbo].[Vehicules]  WITH CHECK ADD  CONSTRAINT [FK_Vehicules_Position] FOREIGN KEY([Position_Id])
REFERENCES [dbo].[Positions] ([Id])
GO
ALTER TABLE [dbo].[Vehicules] CHECK CONSTRAINT [FK_Vehicules_Position]
GO
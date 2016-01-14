SET QUOTED_IDENTIFIER OFF;
GO
USE [CGPTruck];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Attachments_Mission]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Attachments] DROP CONSTRAINT [FK_Attachments_Mission];
GO
IF OBJECT_ID(N'[dbo].[FK_Events_Mission]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_Events_Mission];
GO
IF OBJECT_ID(N'[dbo].[FK_Missions_Phone]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Missions] DROP CONSTRAINT [FK_Missions_Phone];
GO
IF OBJECT_ID(N'[dbo].[FK_Missions_Vehicule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Missions] DROP CONSTRAINT [FK_Missions_Vehicule];
GO
IF OBJECT_ID(N'[dbo].[FK_Places_Postion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Places] DROP CONSTRAINT [FK_Places_Postion];
GO
IF OBJECT_ID(N'[dbo].[FK_Step_StepType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Step] DROP CONSTRAINT [FK_Step_StepType];
GO
IF OBJECT_ID(N'[dbo].[FK_Vehicules_Position]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicules] DROP CONSTRAINT [FK_Vehicules_Position];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Attachments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Attachments];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[Missions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Missions];
GO
IF OBJECT_ID(N'[dbo].[Phones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Phones];
GO
IF OBJECT_ID(N'[dbo].[Places]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Places];
GO
IF OBJECT_ID(N'[dbo].[Positions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Positions];
GO
IF OBJECT_ID(N'[dbo].[Step]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Step];
GO
IF OBJECT_ID(N'[dbo].[StepTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StepTypes];
GO
IF OBJECT_ID(N'[dbo].[Vehicules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vehicules];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(90)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Mission_Id] int  NOT NULL
);
GO

-- Creating table 'Phones'
CREATE TABLE [dbo].[Phones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NULL,
    [Serial_Code] nvarchar(50)  NOT NULL,
    [Phone_State] int  NOT NULL
);
GO

-- Creating table 'Places'
CREATE TABLE [dbo].[Places] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Position_Id] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Place_Type] int  NOT NULL
);
GO

-- Creating table 'Positions'
CREATE TABLE [dbo].[Positions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Latitude] float  NOT NULL,
    [Longitude] float  NOT NULL
);
GO

-- Creating table 'Steps'
CREATE TABLE [dbo].[Steps] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [StepType_Id] int  NOT NULL
);
GO

-- Creating table 'StepTypes'
CREATE TABLE [dbo].[StepTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Vehicules'
CREATE TABLE [dbo].[Vehicules] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Brand] nvarchar(50)  NOT NULL,
    [Model] nvarchar(50)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Vehicule_State] int  NOT NULL,
    [Position_Id] int  NOT NULL,
    [Vehicule_Type] int  NOT NULL
);
GO

-- Creating table 'Attachments'
CREATE TABLE [dbo].[Attachments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Mission_Id] int  NOT NULL
);
GO

-- Creating table 'Missions'
CREATE TABLE [dbo].[Missions] (
    [Id] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Vehicule_Id] int  NOT NULL,
    [Driver_Id] nvarchar(128)  NOT NULL,
    [Shipment] nvarchar(50)  NULL,
    [Phone_Id] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Phones'
ALTER TABLE [dbo].[Phones]
ADD CONSTRAINT [PK_Phones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Places'
ALTER TABLE [dbo].[Places]
ADD CONSTRAINT [PK_Places]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Positions'
ALTER TABLE [dbo].[Positions]
ADD CONSTRAINT [PK_Positions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Steps'
ALTER TABLE [dbo].[Steps]
ADD CONSTRAINT [PK_Steps]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StepTypes'
ALTER TABLE [dbo].[StepTypes]
ADD CONSTRAINT [PK_StepTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Vehicules'
ALTER TABLE [dbo].[Vehicules]
ADD CONSTRAINT [PK_Vehicules]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Attachments'
ALTER TABLE [dbo].[Attachments]
ADD CONSTRAINT [PK_Attachments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Missions'
ALTER TABLE [dbo].[Missions]
ADD CONSTRAINT [PK_Missions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Position_Id] in table 'Places'
ALTER TABLE [dbo].[Places]
ADD CONSTRAINT [FK_Places_Postion]
    FOREIGN KEY ([Position_Id])
    REFERENCES [dbo].[Positions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Places_Postion'
CREATE INDEX [IX_FK_Places_Postion]
ON [dbo].[Places]
    ([Position_Id]);
GO

-- Creating foreign key on [Position_Id] in table 'Vehicules'
ALTER TABLE [dbo].[Vehicules]
ADD CONSTRAINT [FK_Vehicules_Position]
    FOREIGN KEY ([Position_Id])
    REFERENCES [dbo].[Positions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Vehicules_Position'
CREATE INDEX [IX_FK_Vehicules_Position]
ON [dbo].[Vehicules]
    ([Position_Id]);
GO

-- Creating foreign key on [StepType_Id] in table 'Steps'
ALTER TABLE [dbo].[Steps]
ADD CONSTRAINT [FK_Step_StepType]
    FOREIGN KEY ([StepType_Id])
    REFERENCES [dbo].[StepTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Step_StepType'
CREATE INDEX [IX_FK_Step_StepType]
ON [dbo].[Steps]
    ([StepType_Id]);
GO

-- Creating foreign key on [Mission_Id] in table 'Attachments'
ALTER TABLE [dbo].[Attachments]
ADD CONSTRAINT [FK_Attachments_Mission]
    FOREIGN KEY ([Mission_Id])
    REFERENCES [dbo].[Missions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Attachments_Mission'
CREATE INDEX [IX_FK_Attachments_Mission]
ON [dbo].[Attachments]
    ([Mission_Id]);
GO

-- Creating foreign key on [Mission_Id] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_Events_Mission]
    FOREIGN KEY ([Mission_Id])
    REFERENCES [dbo].[Missions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Events_Mission'
CREATE INDEX [IX_FK_Events_Mission]
ON [dbo].[Events]
    ([Mission_Id]);
GO

-- Creating foreign key on [Phone_Id] in table 'Missions'
ALTER TABLE [dbo].[Missions]
ADD CONSTRAINT [FK_Missions_Phone]
    FOREIGN KEY ([Phone_Id])
    REFERENCES [dbo].[Phones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Missions_Phone'
CREATE INDEX [IX_FK_Missions_Phone]
ON [dbo].[Missions]
    ([Phone_Id]);
GO

-- Creating foreign key on [Vehicule_Id] in table 'Missions'
ALTER TABLE [dbo].[Missions]
ADD CONSTRAINT [FK_Missions_Vehicule]
    FOREIGN KEY ([Vehicule_Id])
    REFERENCES [dbo].[Vehicules]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Missions_Vehicule'
CREATE INDEX [IX_FK_Missions_Vehicule]
ON [dbo].[Missions]
    ([Vehicule_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
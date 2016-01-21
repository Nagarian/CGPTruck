
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/21/2016 17:01:18
-- Generated from EDMX file: C:\Users\onyx_\Documents\Visual Studio 2015\Projects\CGPTruck\CGPTruck.WebAPI\Entities\EFCGPTruck.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CGPTruck];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Attachments_Failure_Detail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Attachments] DROP CONSTRAINT [FK_Attachments_Failure_Detail];
GO
IF OBJECT_ID(N'[dbo].[FK_Attachments_Mission]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Attachments] DROP CONSTRAINT [FK_Attachments_Mission];
GO
IF OBJECT_ID(N'[dbo].[FK_FailureDetails_Failure]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FailureDetails] DROP CONSTRAINT [FK_FailureDetails_Failure];
GO
IF OBJECT_ID(N'[dbo].[FK_Failures_Mission]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Failures] DROP CONSTRAINT [FK_Failures_Mission];
GO
IF OBJECT_ID(N'[dbo].[FK_Failures_Repairer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Failures] DROP CONSTRAINT [FK_Failures_Repairer];
GO
IF OBJECT_ID(N'[dbo].[FK_Failures_Repairer_Vehicule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Failures] DROP CONSTRAINT [FK_Failures_Repairer_Vehicule];
GO
IF OBJECT_ID(N'[dbo].[FK_Failures_Vehicule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Failures] DROP CONSTRAINT [FK_Failures_Vehicule];
GO
IF OBJECT_ID(N'[dbo].[FK_Missions_Delivery_Place]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Missions] DROP CONSTRAINT [FK_Missions_Delivery_Place];
GO
IF OBJECT_ID(N'[dbo].[FK_Missions_Driver]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Missions] DROP CONSTRAINT [FK_Missions_Driver];
GO
IF OBJECT_ID(N'[dbo].[FK_Missions_Pickup_Place]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Missions] DROP CONSTRAINT [FK_Missions_Pickup_Place];
GO
IF OBJECT_ID(N'[dbo].[FK_Missions_Vehicule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Missions] DROP CONSTRAINT [FK_Missions_Vehicule];
GO
IF OBJECT_ID(N'[dbo].[FK_Places_Position]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Places] DROP CONSTRAINT [FK_Places_Position];
GO
IF OBJECT_ID(N'[dbo].[FK_Step_Mission]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Steps] DROP CONSTRAINT [FK_Step_Mission];
GO
IF OBJECT_ID(N'[dbo].[FK_Step_Position]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Steps] DROP CONSTRAINT [FK_Step_Position];
GO
IF OBJECT_ID(N'[CGPTruckModelStoreContainer].[FK_UsersPhones_Phone]', 'F') IS NOT NULL
    ALTER TABLE [CGPTruckModelStoreContainer].[UsersPhones] DROP CONSTRAINT [FK_UsersPhones_Phone];
GO
IF OBJECT_ID(N'[CGPTruckModelStoreContainer].[FK_UsersPhones_User]', 'F') IS NOT NULL
    ALTER TABLE [CGPTruckModelStoreContainer].[UsersPhones] DROP CONSTRAINT [FK_UsersPhones_User];
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
IF OBJECT_ID(N'[dbo].[FailureDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FailureDetails];
GO
IF OBJECT_ID(N'[dbo].[Failures]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Failures];
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
IF OBJECT_ID(N'[dbo].[Steps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Steps];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Vehicules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vehicules];
GO
IF OBJECT_ID(N'[CGPTruckModelStoreContainer].[UsersPhones]', 'U') IS NOT NULL
    DROP TABLE [CGPTruckModelStoreContainer].[UsersPhones];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Attachments'
CREATE TABLE [dbo].[Attachments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Path] nvarchar(50)  NULL,
    [Mission_Id] int  NULL,
    [Failure_Id] int  NULL
);
GO

-- Creating table 'FailureDetails'
CREATE TABLE [dbo].[FailureDetails] (
    [Failure_Id] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Write_Date] datetime  NOT NULL
);
GO

-- Creating table 'Failures'
CREATE TABLE [dbo].[Failures] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Vehicule_Id] int  NOT NULL,
    [State] int  NOT NULL,
    [Mission_id] int  NOT NULL,
    [Failure_Detail_Id] int  NULL,
    [Repairer_Id] int  NULL,
    [Repairer_Vehicule_Id] int  NULL
);
GO

-- Creating table 'Missions'
CREATE TABLE [dbo].[Missions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Date] datetime  NOT NULL,
    [Vehicule_Id] int  NOT NULL,
    [Driver_Id] int  NOT NULL,
    [Pickup_Place_Id] int  NOT NULL,
    [Delivery_Place_Id] int  NOT NULL
);
GO

-- Creating table 'Phones'
CREATE TABLE [dbo].[Phones] (
    [Id] int  NOT NULL,
    [Name] nvarchar(250)  NULL,
    [Serial_Code] nvarchar(50)  NOT NULL,
    [Phone_State] int  NOT NULL
);
GO

-- Creating table 'Places'
CREATE TABLE [dbo].[Places] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Position_Id] int  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Place_Type] int  NOT NULL,
    [Active] bit  NOT NULL
);
GO

-- Creating table 'Steps'
CREATE TABLE [dbo].[Steps] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StepNumber] int  NOT NULL,
    [Position_Id] int  NOT NULL,
    [Informations] nvarchar(max)  NULL,
    [Step_Type] int  NOT NULL,
    [Mission_Id] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AspNetId] nvarchar(128)  NOT NULL,
    [AccountType] int  NOT NULL,
    [DriverLicenseType] int  NOT NULL,
    [Active] bit  NOT NULL
);
GO

-- Creating table 'Vehicules'
CREATE TABLE [dbo].[Vehicules] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Position_Id] int  NOT NULL,
    [Brand] nvarchar(50)  NOT NULL,
    [Model] nvarchar(50)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Vehicule_State] int  NOT NULL,
    [Vehicule_Type] int  NOT NULL,
    [Active] bit  NOT NULL
);
GO

-- Creating table 'Positions'
CREATE TABLE [dbo].[Positions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Longitude] float  NOT NULL,
    [Latitude] float  NOT NULL
);
GO

-- Creating table 'UsersPhones'
CREATE TABLE [dbo].[UsersPhones] (
    [Phones_Id] int  NOT NULL,
    [Users_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Attachments'
ALTER TABLE [dbo].[Attachments]
ADD CONSTRAINT [PK_Attachments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Failure_Id] in table 'FailureDetails'
ALTER TABLE [dbo].[FailureDetails]
ADD CONSTRAINT [PK_FailureDetails]
    PRIMARY KEY CLUSTERED ([Failure_Id] ASC);
GO

-- Creating primary key on [Id] in table 'Failures'
ALTER TABLE [dbo].[Failures]
ADD CONSTRAINT [PK_Failures]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Missions'
ALTER TABLE [dbo].[Missions]
ADD CONSTRAINT [PK_Missions]
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

-- Creating primary key on [Id] in table 'Steps'
ALTER TABLE [dbo].[Steps]
ADD CONSTRAINT [PK_Steps]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Vehicules'
ALTER TABLE [dbo].[Vehicules]
ADD CONSTRAINT [PK_Vehicules]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Positions'
ALTER TABLE [dbo].[Positions]
ADD CONSTRAINT [PK_Positions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Phones_Id], [Users_Id] in table 'UsersPhones'
ALTER TABLE [dbo].[UsersPhones]
ADD CONSTRAINT [PK_UsersPhones]
    PRIMARY KEY CLUSTERED ([Phones_Id], [Users_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Failure_Id] in table 'Attachments'
ALTER TABLE [dbo].[Attachments]
ADD CONSTRAINT [FK_Attachments_Failure_Detail]
    FOREIGN KEY ([Failure_Id])
    REFERENCES [dbo].[FailureDetails]
        ([Failure_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Attachments_Failure_Detail'
CREATE INDEX [IX_FK_Attachments_Failure_Detail]
ON [dbo].[Attachments]
    ([Failure_Id]);
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

-- Creating foreign key on [Failure_Id] in table 'FailureDetails'
ALTER TABLE [dbo].[FailureDetails]
ADD CONSTRAINT [FK_FailureDetails_Failure]
    FOREIGN KEY ([Failure_Id])
    REFERENCES [dbo].[Failures]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Mission_id] in table 'Failures'
ALTER TABLE [dbo].[Failures]
ADD CONSTRAINT [FK_Failures_Mission]
    FOREIGN KEY ([Mission_id])
    REFERENCES [dbo].[Missions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Failures_Mission'
CREATE INDEX [IX_FK_Failures_Mission]
ON [dbo].[Failures]
    ([Mission_id]);
GO

-- Creating foreign key on [Repairer_Id] in table 'Failures'
ALTER TABLE [dbo].[Failures]
ADD CONSTRAINT [FK_Failures_Repairer]
    FOREIGN KEY ([Repairer_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Failures_Repairer'
CREATE INDEX [IX_FK_Failures_Repairer]
ON [dbo].[Failures]
    ([Repairer_Id]);
GO

-- Creating foreign key on [Repairer_Vehicule_Id] in table 'Failures'
ALTER TABLE [dbo].[Failures]
ADD CONSTRAINT [FK_Failures_Repairer_Vehicule]
    FOREIGN KEY ([Repairer_Vehicule_Id])
    REFERENCES [dbo].[Vehicules]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Failures_Repairer_Vehicule'
CREATE INDEX [IX_FK_Failures_Repairer_Vehicule]
ON [dbo].[Failures]
    ([Repairer_Vehicule_Id]);
GO

-- Creating foreign key on [Vehicule_Id] in table 'Failures'
ALTER TABLE [dbo].[Failures]
ADD CONSTRAINT [FK_Failures_Vehicule]
    FOREIGN KEY ([Vehicule_Id])
    REFERENCES [dbo].[Vehicules]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Failures_Vehicule'
CREATE INDEX [IX_FK_Failures_Vehicule]
ON [dbo].[Failures]
    ([Vehicule_Id]);
GO

-- Creating foreign key on [Delivery_Place_Id] in table 'Missions'
ALTER TABLE [dbo].[Missions]
ADD CONSTRAINT [FK_Missions_Delivery_Place]
    FOREIGN KEY ([Delivery_Place_Id])
    REFERENCES [dbo].[Places]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Missions_Delivery_Place'
CREATE INDEX [IX_FK_Missions_Delivery_Place]
ON [dbo].[Missions]
    ([Delivery_Place_Id]);
GO

-- Creating foreign key on [Driver_Id] in table 'Missions'
ALTER TABLE [dbo].[Missions]
ADD CONSTRAINT [FK_Missions_Driver]
    FOREIGN KEY ([Driver_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Missions_Driver'
CREATE INDEX [IX_FK_Missions_Driver]
ON [dbo].[Missions]
    ([Driver_Id]);
GO

-- Creating foreign key on [Pickup_Place_Id] in table 'Missions'
ALTER TABLE [dbo].[Missions]
ADD CONSTRAINT [FK_Missions_Pickup_Place]
    FOREIGN KEY ([Pickup_Place_Id])
    REFERENCES [dbo].[Places]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Missions_Pickup_Place'
CREATE INDEX [IX_FK_Missions_Pickup_Place]
ON [dbo].[Missions]
    ([Pickup_Place_Id]);
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

-- Creating foreign key on [Mission_Id] in table 'Steps'
ALTER TABLE [dbo].[Steps]
ADD CONSTRAINT [FK_Step_Mission]
    FOREIGN KEY ([Mission_Id])
    REFERENCES [dbo].[Missions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Step_Mission'
CREATE INDEX [IX_FK_Step_Mission]
ON [dbo].[Steps]
    ([Mission_Id]);
GO

-- Creating foreign key on [Phones_Id] in table 'UsersPhones'
ALTER TABLE [dbo].[UsersPhones]
ADD CONSTRAINT [FK_UsersPhones_Phone]
    FOREIGN KEY ([Phones_Id])
    REFERENCES [dbo].[Phones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_Id] in table 'UsersPhones'
ALTER TABLE [dbo].[UsersPhones]
ADD CONSTRAINT [FK_UsersPhones_User]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersPhones_User'
CREATE INDEX [IX_FK_UsersPhones_User]
ON [dbo].[UsersPhones]
    ([Users_Id]);
GO

-- Creating foreign key on [Position_Id] in table 'Places'
ALTER TABLE [dbo].[Places]
ADD CONSTRAINT [FK_Places_Position]
    FOREIGN KEY ([Position_Id])
    REFERENCES [dbo].[Positions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Places_Position'
CREATE INDEX [IX_FK_Places_Position]
ON [dbo].[Places]
    ([Position_Id]);
GO

-- Creating foreign key on [Position_Id] in table 'Steps'
ALTER TABLE [dbo].[Steps]
ADD CONSTRAINT [FK_Step_Position]
    FOREIGN KEY ([Position_Id])
    REFERENCES [dbo].[Positions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Step_Position'
CREATE INDEX [IX_FK_Step_Position]
ON [dbo].[Steps]
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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
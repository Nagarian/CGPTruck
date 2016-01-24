USE [CGPTruck]
--ALTER TABLE Steps
--ADD [Date] DATE NOT NULL;
--GO

--ALTER TABLE Users
--ADD [FirstName] NVARCHAR(50) NOT NULL
--ALTER TABLE Users
--ADD [LastName] NVARCHAR(50) NOT NULL 
--ALTER TABLE Users
--ADD [Birthday] DATE NOT NULL
--ALTER TABLE Users
--ADD [Sexe] BIT NOT NULL DEFAULT(0) 
--GO

--ALTER TABLE [dbo].[Steps]
--ALTER COLUMN [Date] DATETIME NOT NULL
--GO

--ALTER TABLE [dbo].[Failures]
--ALTER COLUMN [Date] DATETIME NOT NULL
--GO

---- Ajouter le IDENTITY sur la colonne Id de la table Phones

--ALTER TABLE [dbo].[Failures]
--DROP COLUMN [Failure_Detail_Id];

UPDATE [Positions]
SET [Latitude] = [Longitude], [Longitude] = [Latitude]
GO

INSERT INTO Missions(Name, Description, Date, Vehicule_Id, Driver_Id, Pickup_Place_Id, Delivery_Place_Id)
VALUES ('Livraison - Lactel Bis', 'Livraison des packs de lait Lactel au client "Auchan - Bordeaux Lac"', '2016-02-24 11:10', 1, 1, 10, 8)
GO

UPDATE [Steps]
SET [Mission_Id] = 2
WHERE [Id] >= 8 AND [Id] <= 17
GO

UPDATE [Steps]
SET [StepNumber] = [Id]
WHERE [Id] < 8

UPDATE [Steps]
SET [StepNumber] = [Id] - 7
WHERE [Id] >= 8 AND [Id] <= 17
GO
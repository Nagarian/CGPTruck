INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName])
VALUES (N'1662c79f-1a26-42a7-a7fa-631c798b5562', NULL, 0, N'ACDaNK0T8fASsN9wi9hVTmL8NuZ/p7y8T/K3iPfXsPsd4OEHMTg7+RbD0ZNCUhO2zg==', N'88a2b2a9-ade3-4576-ab0d-8da022ab7e48', NULL, 0, 0, NULL, 0, 0, N'hans.herbretzel')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName])
VALUES (N'224419eb-7d1b-45ed-a611-5921adbc0541', NULL, 0, N'AGFfCjb/Rk8iBosqTGOrZSU6z/vHhGgIOdHw/M1LJ+iZG96U2G390yed4y3S11HgdA==', N'bdfda632-092c-4b9e-b39a-fdd51d6ae13e', NULL, 0, 0, NULL, 0, 0, N'michel.martin')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName])
VALUES (N'59742ae1-d2b7-48bd-9b15-eeefe3d3e8a8', NULL, 0, N'AHz35DpzM53PJaqWC0Ro4WjJ0Tgr1rtUR5lEFZu3x72kuYcKl4Ch+wwryxAm+wX7qA==', N'24b4aa26-7121-45ca-98a3-3f71f63f0fb6', NULL, 0, 0, NULL, 0, 0, N'louis.dupont')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName])
VALUES (N'5c8575fd-78ed-4c62-8583-a7ead6c2f6cd', NULL, 0, N'AEub3mul+XtAZ+hq3b3e1qoAayTKq8wEO489SR+44TdRE6d03RcKPiuNUqdvskI2NA==', N'96e9bc14-4e19-4127-a115-49c9aaa7df6e', NULL, 0, 0, NULL, 0, 0, N'hector.robert')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName])
VALUES (N'ae9e1771-d979-45ca-adf4-662a636c95d1', NULL, 0, N'ACkM5lXmyCuEBLkEVnwaZ5+Fy8DWUPEoIWqtn4sGqoK6kUQQRA/izkvDEdYz+cagbw==', N'2be5fe7b-76d9-4734-932d-c2c48f20735a', NULL, 0, 0, NULL, 0, 0, N'helene.martin')
GO

INSERT INTO [dbo].[Users] ([AspNetId], [FirstName], [LastName], [Birthday], [Sexe], [AccountType], [DriverLicenseType], [Active])
VALUES (N'5c8575fd-78ed-4c62-8583-a7ead6c2f6cd', N'Hector', N'Robert', N'1968-12-05', 1, 0, 2, 1)
INSERT INTO [dbo].[Users] ([AspNetId], [FirstName], [LastName], [Birthday], [Sexe], [AccountType], [DriverLicenseType], [Active])
VALUES (N'59742ae1-d2b7-48bd-9b15-eeefe3d3e8a8', N'Louis', N'DUPONT', N'1987-03-28', 1, 0, 2, 1)
INSERT INTO [dbo].[Users] ([AspNetId], [FirstName], [LastName], [Birthday], [Sexe], [AccountType], [DriverLicenseType], [Active])
VALUES (N'1662c79f-1a26-42a7-a7fa-631c798b5562', N'Hans', N'HERBRETZEL', N'1991-09-02', 1, 2, 0, 1)
INSERT INTO [dbo].[Users] ([AspNetId], [FirstName], [LastName], [Birthday], [Sexe], [AccountType], [DriverLicenseType], [Active])
VALUES (N'224419eb-7d1b-45ed-a611-5921adbc0541', N'Michel', N'MARTIN', N'1976-11-18', 1, 1, 0, 1)
INSERT INTO [dbo].[Users] ([AspNetId], [FirstName], [LastName], [Birthday], [Sexe], [AccountType], [DriverLicenseType], [Active])
VALUES (N'ae9e1771-d979-45ca-adf4-662a636c95d1', N'Hélène', N'MARTIN', N'1979-05-24', 0, 1, 0, 1)
GO


INSERT INTO Phones(Name, Serial_Code, Phone_State)
VALUES ('HTC Windows Phone 1', 'df6s15df6165s1df5sf5s1df6sdf', 0);
INSERT INTO Phones(Name, Serial_Code, Phone_State)
VALUES ('HTC Windows Phone 2', 'd15df616dfsf5s1dsf5s754df6sdf', 0);
INSERT INTO Phones(Name, Serial_Code, Phone_State)
VALUES ('Nokia Lumia 950', '8946er46f5d654s6465gd1g6s54d', 0);
INSERT INTO Phones(Name, Serial_Code, Phone_State)
VALUES ('Nokia Lumia 950 XL', 'zae984za6e54a65z4e68a5ea4z6e5', 0);
INSERT INTO Phones(Name, Serial_Code, Phone_State)
VALUES ('Nokia Lumia 950 XL', '984846klj64hg65465j4k6hj1g654', 1);
GO

INSERT INTO UsersPhones(User_Id, Phone_Id)
VALUES (1, 1)
INSERT INTO UsersPhones(User_Id, Phone_Id)
VALUES (2, 2)
INSERT INTO UsersPhones(User_Id, Phone_Id)
VALUES (4, 3)
INSERT INTO UsersPhones(User_Id, Phone_Id)
VALUES (5, 4)
GO

-- Position Vehicule
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.853976, -0.566818);
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.851344, -0.570428);
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.854221, -0.572156);
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.8594357,-0.5732093)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.870366, -0.554700)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.870902, -0.547295)
GO

-- Position Places
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.859468, -0.592314)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.870902, -0.547295)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.847792, -0.601885)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.864294, -0.585834)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.865898, -0.588774)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.863928, -0.589976)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.862498, -0.589450)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.879848, -0.566574)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.772630, -0.614232)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.846583, -0.546875)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.848825, -0.540108)
GO

-- Positions Missions 1
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.870902, -0.547295)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.870902, -0.547295)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.846583, -0.546875)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.846583, -0.546875)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.879848, -0.566574)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.879848, -0.566574)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.870902, -0.547295)
GO

-- Positions Missions 2
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.859468, -0.592314)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.859468, -0.592314)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.848825, -0.540108)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.848825, -0.540108)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.820108, -0.569584)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.865898, -0.588774)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.865898, -0.588774)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.772630, -0.614232)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.772630, -0.614232)
INSERT INTO Positions(Longitude, Latitude)
VALUES (44.859468, -0.592314)
GO

INSERT INTO Vehicules(Position_Id, Brand, Model, Description, Vehicule_State, Vehicule_Type, Active)
VALUES (1, 'GrosTruck', '1856xm', 'Immat : 32-FPOD-52. Vehicule de la marque GrosTruck, en circulation depuis 1987. Supporte 500 tonnes.', 0, 1, 1);
INSERT INTO Vehicules(Position_Id, Brand, Model, Description, Vehicule_State, Vehicule_Type, Active)
VALUES (2, 'GrosTruck', '1856xm', 'Immat : 12-FRFD-98. Vehicule de la marque GrosTruck, en circulation depuis 1995. Supporte 500 tonnes.', 0, 1, 1);
INSERT INTO Vehicules(Position_Id, Brand, Model, Description, Vehicule_State, Vehicule_Type, Active)
VALUES (3, 'GrosTruck', '1856xm', 'Immat : 45-FDGD-32. Vehicule de la marque GrosTruck, en circulation depuis 1992. Supporte 500 tonnes.', 0, 1, 1);
INSERT INTO Vehicules(Position_Id, Brand, Model, Description, Vehicule_State, Vehicule_Type, Active)
VALUES (4, 'GrosTruck', '1856xm', 'Immat : 65-PODF-38. Vehicule de la marque GrosTruck, en circulation depuis 1993. Supporte 500 tonnes.', 2, 1, 1);
INSERT INTO Vehicules(Position_Id, Brand, Model, Description, Vehicule_State, Vehicule_Type, Active)
VALUES (5, 'Peugeot', '206', 'Immat :89-PEUG-23. Vehicule en circulation depuis 1994. Couleur bleu métalisé.', 2, 2, 1);
INSERT INTO Vehicules(Position_Id, Brand, Model, Description, Vehicule_State, Vehicule_Type, Active)
VALUES (6, 'Peugeot', '206cc', 'Immat :89-PEIG-23. Vehicule en circulation depuis 2006. Couleur bleu métalisé.', 2, 2, 1);
GO

INSERT INTO Places(Name, Position_Id, Description, Place_Type, Active)
VALUES ('Garage 1', 7, 'Garage principal des transport "Camion''Heures"', 0, 1)
INSERT INTO Places(Name, Position_Id, Description, Place_Type, Active)
VALUES ('Garage 2', 8, 'Garage principal des transport "Camion''Heures"', 0, 1)
INSERT INTO Places(Name, Position_Id, Description, Place_Type, Active)
VALUES ('Garage 3', 9, 'Garage loué dans les environs de Bordeaux par les transport "Camion''Heures". Location terminée.', 0, 0)
INSERT INTO Places(Name, Position_Id, Description, Place_Type, Active)
VALUES ('Repar''Tout 1', 10, 'Centre de réparation agréé en cas de panne des transporteurs "Camion''Heures".', 2, 1)
INSERT INTO Places(Name, Position_Id, Description, Place_Type, Active)
VALUES ('Repar''Tout 2', 11, 'Centre de réparation agréé en cas de panne des transporteurs "Camion''Heures".', 2, 1)
INSERT INTO Places(Name, Position_Id, Description, Place_Type, Active)
VALUES ('Chez Tito - Pizza', 12, 'Tito et sa famille vous accueille dans son restaurant, dans une ambiance qui sent bon la Sicille.', 3, 1)
INSERT INTO Places(Name, Position_Id, Description, Place_Type, Active)
VALUES ('Total Station', 13, 'Station-service Total accessible aux poids-lourds.', 4, 1)
INSERT INTO Places(Name, Position_Id, Description, Place_Type, Active)
VALUES ('Auchan - Bordeaux Lac', 14, 'Centre commercial situé à Bordeaux Lac, client privilégié. Accessible aisément.', 5, 1)
INSERT INTO Places(Name, Position_Id, Description, Place_Type, Active)
VALUES ('Magasin "Chez l''Autre, là"', 15, 'Petit commerce nécessitant souvent des livraisons d''électro-ménager.', 5, 1)
INSERT INTO Places(Name, Position_Id, Description, Place_Type, Active)
VALUES ('Entrepôt "Camion''Heures" 1', 16, 'Entrepôt principal des transport "Camion''Heures"', 1, 1)
INSERT INTO Places(Name, Position_Id, Description, Place_Type, Active)
VALUES ('Entrepôt "Camion''Heures" 2', 17, 'Entrepôt secondaire  des transport "Camion''Heures"', 1, 1)
GO

INSERT INTO Missions(Name, Description, Date, Vehicule_Id, Driver_Id, Pickup_Place_Id, Delivery_Place_Id)
VALUES ('Livraison - Lactel', 'Livraison des packs de lait Lactel au client "Auchan - Bordeaux Lac"', '2015-11-24 16:14', 1, 1, 10, 8)
INSERT INTO Missions(Name, Description, Date, Vehicule_Id, Driver_Id, Pickup_Place_Id, Delivery_Place_Id)
VALUES ('Livraison - Electro-ménager', 'Livraison des produits électro-ménager au client "Chez l''Autre, là"', '2016-01-12 10:11', 2, 2, 11, 9)
GO

INSERT INTO Failures(Date, Vehicule_Id, State, Mission_id, Repairer_Id, Repairer_Vehicule_Id)
VALUES ('2016-01-12 12:10:00', 2, 3, 2, 5, 5)
GO

INSERT INTO FailureDetails(Failure_Id, Description, Write_Date)
VALUES (1, 'Gros problème de parallélisme détecté sur les roues avants. 
	Un retour au centre de réparation a été nécessaire.
	La panne a été réparée en 3h. Le camion est prêt à repartir.', '2016-01-12 16:10')
GO

INSERT INTO Steps(StepNumber, Date, Position_Id, Informations, Step_Type, Mission_Id)
VALUES (1, '2015-11-24 16:14:00', 18, 'RAS', 0, 1)
INSERT INTO Steps(StepNumber, Date, Position_Id, Informations, Step_Type, Mission_Id)
VALUES (1, '2015-11-24 16:23:00', 19, 'RAS', 1, 1)
INSERT INTO Steps(StepNumber, Date, Position_Id, Informations, Step_Type, Mission_Id)
VALUES (1, '2015-11-24 17:23:00', 20, 'RAS', 2, 1)
INSERT INTO Steps(StepNumber, Date, Position_Id, Informations, Step_Type, Mission_Id)
VALUES (1, '2015-11-24 17:42:00', 21, 'RAS', 3, 1)
INSERT INTO Steps(StepNumber, Date, Position_Id, Informations, Step_Type, Mission_Id)
VALUES (1, '2015-11-24 18:56:00', 22, 'RAS', 4, 1)
INSERT INTO Steps(StepNumber, Date, Position_Id, Informations, Step_Type, Mission_Id)
VALUES (1, '2015-11-24 19:12:00', 23, 'RAS', 5, 1)
INSERT INTO Steps(StepNumber, Date, Position_Id, Informations, Step_Type, Mission_Id)
VALUES (1, '2015-11-24 20:12:00', 24, 'RAS', 6, 1)
GO

INSERT INTO Steps(StepNumber, Date, Position_Id, Informations, Step_Type, Mission_Id)
VALUES (2, '2016-01-12 10:11:00', 25, 'RAS', 0, 1)
INSERT INTO Steps(StepNumber, Date, Position_Id, Informations, Step_Type, Mission_Id)
VALUES (2, '2016-01-12 10:15:00', 26, 'RAS', 1, 1)
INSERT INTO Steps(StepNumber, Date, Position_Id, Informations, Step_Type, Mission_Id)
VALUES (2, '2016-01-12 11:35:00', 27, 'RAS', 2, 1)
INSERT INTO Steps(StepNumber, Date, Position_Id, Informations, Step_Type, Mission_Id)
VALUES (2, '2016-01-12 11:55:00', 28, 'RAS', 3, 1)
INSERT INTO Steps(StepNumber, Date, Position_Id, Informations, Step_Type, Mission_Id)
VALUES (2, '2016-01-12 12:10:00', 29, 'RAS', 7, 1)
INSERT INTO Steps(StepNumber, Date, Position_Id, Informations, Step_Type, Mission_Id)
VALUES (2, '2016-01-12 15:24:00', 30, 'RAS', 8, 1)
INSERT INTO Steps(StepNumber, Date, Position_Id, Informations, Step_Type, Mission_Id)
VALUES (2, '2016-01-12 15:24:00', 31, 'RAS', 3, 1)
INSERT INTO Steps(StepNumber, Date, Position_Id, Informations, Step_Type, Mission_Id)
VALUES (2, '2016-01-12 16:45:00', 32, 'RAS', 4, 1)
INSERT INTO Steps(StepNumber, Date, Position_Id, Informations, Step_Type, Mission_Id)
VALUES (2, '2016-01-12 17:02:00', 33, 'RAS', 5, 1)
INSERT INTO Steps(StepNumber, Date, Position_Id, Informations, Step_Type, Mission_Id)
VALUES (2, '2016-01-12 18:02:00', 34, 'RAS', 6, 1)
GO
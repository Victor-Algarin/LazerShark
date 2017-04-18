IF EXISTS (SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'lazerSharkDB')
BEGIN
	DROP DATABASE lazerSharkDB
	print '' print '*** dropping database lazerSharkDB ***'
END
GO

CREATE DATABASE lazerSharkDB
GO

print '' print '*** using database lazerSharkDB ***' 
GO
USE [lazerSharkDB]
GO

print '' print '*** Creating Movies Table ***'
GO
/* ***Object: Table[dbo].[Movies]*** */

CREATE TABLE [dbo].[Movies](
	[MovieID]			[int]IDENTITY(100000,1)	NOT NULL,
	[Title]				[varchar](250)			NOT NULL,
	[GenreID]			[varchar](50)			NOT NULL,
	[Description]		[varchar](500)			NOT NULL,
	[Rating]			[varchar](15)			NOT NULL,
	[MediumID]			[varchar](10)			NOT NULL,
	[QuantityAvailable]	[int]					NOT NULL,
	[Quantity]			[int]					NOT NULL,
	[RentalPrice]		[decimal](7,2)			NOT NULL,
	[Active]			[bit]					NOT NULL DEFAULT 1

	
	CONSTRAINT [pk_MovieID] PRIMARY KEY ([MovieID] ASC)
)
GO

print '' print '*** Inserting Movies Sample Records ***'
GO
INSERT INTO [dbo].[Movies]
		([Title], [GenreID], [Description], [Rating], [MediumID], [QuantityAvailable], [Quantity], [RentalPrice])
	VALUES
		('Face Kicker', 'Action', "Jack Thompson kicks some dude's face in", 'R', 'Blu-Ray', 3, 5, 2.99),
		('Apples 2 Oranges', 'Drama', 'No one can compare this movie to any other movie', 'PG','DVD', 1, 1, 1.99),
		('Mission Capable', 'Action', 'Jack Thompson is back in the sequel to Face Kicker, and he is pissed! Someone is about to get their face kicked off', 'R', 'Blu-Ray', 2, 5, 4.99),
		('The Farce Awakens', 'Comedy', 'Solo Dolo and the rest of his grey haired cast members return in this adequate reboot of a series beloved by nerds all across the galaxy.', 'PG-13', 'Blu-Ray', 3, 4, 4.99),
		('Straight To DVD', 'Action', 'This movie sucks so bad, that it didnt even make it to the silver screen', 'PG-13', 'DVD', 1, 1, 1.99),
		('The Craptastic Adventure', 'Comedy', 'Crappy times that never seem to end', 'PG', 'Blu-Ray', 2, 2, 2.99 ),
		('Super Space Action', 'Action', "Caption Tom Falsey and his crew set out to save the galaxy aboard an experimental star cruiser and kick some alien ass.", 'R', 'Blu-Ray', 1, 5, 4.99),
		('Cowboy Robot Santa', 'Comedy', "Santa is a robot cowboy, or 'COWBOT' this Christmas... Buckle-Up, Buckaroo", 'PG-13', 'DVD', 1, 1, 1.99),
		('The Soulmate Nanny', 'Drama', "She's the nanny and the soulmate of the ostentatious playboy James McMillan... but he's married to another woman.", 'R', 'Blu-Ray', 2, 3, 2.99 ),
		('Electric Zoo Gorilla', 'Comedy', "This electrifying tale of a silverback gorilla will shock you into laughter", 'R', 'DVD', 2, 2, 1.99),
		('Star Wars: The New One', 'Action', 'The Imperial Forces -- under orders from cruel Dark Crater hold Princess Freia hostage, in their efforts to quell the rebellion against the Galactic Space Empire... in space.', 'PG-13', 'Blu-Ray', 3, 5, 4.99 ),
		('Hugh Janus: Pirate Lawyer', 'Action', 'Half pirate, half lawyer, half Janus. Hugh Janus will shiver his timbers in the court room as he prepares to defend the notorious pirate, captain Black Sparrow.', 'R', 'Blu-Ray', 1, 1, 3.99)
GO

print '' print '*** Creating Games Table ***'
GO
/* ***Object: Table[dbo].[Games]*** */

CREATE TABLE [dbo].[Games](
	[GameID] 			[int]IDENTITY(100000,1)	NOT NULL,
	[Title]				[varchar](250)			NOT NULL,
	[GenreID]			[varchar](50)			NOT NULL,
	[Description]		[varchar](500)			NOT NULL,
	[Rating]			[varchar](15)			NOT NULL,
	[MediumID]			[varchar](10)			NOT NULL,
	[QuantityAvailable]	[int]					NOT NULL,
	[Quantity]			[int]					NOT NULL,
	[RentalPrice]		[decimal](7,2)			NOT NULL,
	[Active]			[bit]					NOT NULL DEFAULT 1
	
	CONSTRAINT [pk_GameID] PRIMARY KEY ([GameID] ASC)
)
GO


print '' print '*** Inserting Games Sample Records ***'
GO
INSERT INTO [dbo].[Games]
	([Title], [GenreID], [Description], [Rating], [MediumID], [QuantityAvailable], [Quantity], [RentalPrice])
	VALUES
		('Clown Simulator', 'Simulation', 'Super boring clown simulation game', 'E', 'PC', 1, 2, 5.99),
		('Shrapnel', 'Shooter', 'Shoot all of the bad guys', 'M', 'XBONE', 1, 2, 6.99),
		('Swords and Shields', 'RPG', 'Use the ultimate sword to avenge the death of your father and reclaim your honor', 'M', 'PS4', 2, 3, 5.99),
		('1942', 'Shooter', 'Fight on the frontlines of the most brutal battles the world has ever witnessed', 'M', 'PS4', 2, 4, 6.99),
		('Space Flight', 'Simulation', 'Realism in space flight such as this has never been achieved until now', 'E', 'PC', 1, 1, 4.99),
		('Dust and Dungeons', 'RPG', 'Explore the deepest darkest dungeons, in an effort to save the princess', 'T', 'XBONE', 2, 3, 5.99 ),
		('Ricochet', 'Shooter', 'Bank shot your way through the baddest of baddies', 'M', 'XBONE', 1 , 3, 6.99) ,
		('Echo', 'RPG', 'Play as Echo, a mage on a journey to the great beyond', 'T', 'PS4', 2, 2, 5.99),
		('Master Blaster', 'Action', 'Journey to the center of the galaxy, as you blast your way through derelict space ships', 'M', 'PC', 1, 1, 2.99)
		
GO


print '' print '*** Creating Customer Table *** '
GO
/* ***Object: Table[dbo].[Customer]*** */

CREATE TABLE [dbo].[Customer](
	[CustomerID]	[int]IDENTITY(100000,1)	NOT NULL,
	[Username]		[varchar](20)			NOT NULL,
	[PasswordHash]	[varchar](100)			NOT NULL DEFAULT '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
	[FirstName]		[varchar](250)			NOT NULL,
	[LastName]		[varchar](250)			NOT NULL,
	[PhoneNumber]	[varchar](9)			NOT NULL,
	[Address]		[varchar](500)			NOT NULL,
	[Email]			[varchar](200)			NOT NULL,
	
	CONSTRAINT [pk_CustomerID] PRIMARY KEY ([CustomerID] ASC),
	CONSTRAINT [ak_Username] UNIQUE ([Username] ASC)
)
GO

print '' print '*** Inserting Customer Sample Records ***'
GO
INSERT INTO [dbo].[Customer]
	([Username], [FirstName], [LastName], [PhoneNumber], [Address], [Email])
	VALUES
		('jimmyjohn', 'Jimmy', 'John', '123456789', '123 Abcd Street, Bowes, CA', 'jimmyjohn@food.com'),
		('muffman', 'Muffin', 'Mann', '234567891', '100 Drury Lane, Bowes, CA', 'muffinman@kirkwood.edu'),
		('duckman', 'Daffy', 'Duck', '345678912', '231 Looney Tunes Road, Bowes, CA', 'daffyduck@looneytunes.com'),
		('newuser', 'new', 'user', '456789131', '100 Fake Address Fake City, CA', 'fake@fake.com')
GO

	
print '' print' **** Creating RentalRecord Table **** '
GO
/* ***Object: Table[dbo].[RentalRecord]*** */

CREATE TABLE [dbo].[RentalRecord](
	[RentalRecordID]	[int]IDENTITY(100000, 1)	NOT NULL, 
	[Terms]				[varchar](250)				NOT NULL,
	[PaymentMethod]		[varchar](250)				NOT NULL,
	[CustomerID]		[int]						NOT NULL,
	[KioskID]			[int]						NOT NULL,
	[DateRented]		[date]						NOT NULL,
	[MovieID]			[int]						,
	[GameID]			[int]						,
	
	CONSTRAINT [pk_RentalRecordID] PRIMARY KEY ([RentalRecordID] ASC)
)
GO

print '' print '*** Inserting Sample RentalRecords *** ' 
GO
INSERT INTO [dbo].[RentalRecord]
	([Terms], [PaymentMethod], [CustomerID], [KioskID], [DateRented], [MovieID], [GameID])
	VALUES
		('5 Days', 'MasterCard', 100000, 100000, '10/01/2016', 100000, NULL),
		('10 Days', 'Visa', 100001, 100000, '11/01/2016', NULL, 100000), 
		('15 Days', 'American Express', 100002, 100000, '11/01/2016', 100001, 100001)
GO


print '' print '**** Creating Administrator Table ****'
GO
/* ***Object: Table[dbo].[Administrator]*** */

CREATE TABLE [dbo].[Administrator] (
	[AdministratorID]	[int]IDENTITY(100000, 1)	NOT NULL,
	[FirstName]			[varchar](250)				NOT NULL,
	[LastName]			[varchar](250)				NOT NULL,
	[Username]			[varchar](200)				NOT NULL,
	[PasswordHash]		[varchar](200)				NOT NULL DEFAULT '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
	
	CONSTRAINT [pk_AdministratorID] PRIMARY KEY ([AdministratorID]ASC)
)
GO

print '' print'**** Inserting Sample Administrator Records ****'
GO
INSERT INTO [dbo].[Administrator]
	([FirstName], [LastName], [Username])
VALUES
	('Boob', 'Builder', 'boobTheBuilder'),
	('Arnie', 'Mann', 'admin')
GO

print '' print '**** Creating Supplier Table **** '
GO
/* ***Object: Table[dbo].[Supplier]*** */

CREATE TABLE [dbo].[Supplier](
	[SupplierID]	[int]IDENTITY(100000, 1)	NOT NULL,
	[Name]			[varchar](250)				NOT NULL,
	
	CONSTRAINT [pk_SupplierID] PRIMARY KEY ([SupplierID] ASC),
	CONSTRAINT [ak_Name] UNIQUE ([Name] ASC)
)
GO

print '' print'**** Inserting Supplier Sample Records ****'
GO
INSERT INTO [dbo].[Supplier]
	([Name])
	VALUES
		('CJ Media Supply'),
		('Wholesale Media'),
		('Da Electronic Entertainment Supplier')

GO

print '' print '**** Creating Kiosk Table ****'
GO
/* ***Object: Table[dbo].[Kiosk]*** */

CREATE TABLE [dbo].[Kiosk](
	[KioskID] 			[int]IDENTITY(100000, 1)	NOT NULL,
	[AdministratorID]	[int]						NOT NULL,
	[GameID]			[int]						NULL,
	[MovieID]			[int]						NULL,
	
	CONSTRAINT	[pk_KioskID] PRIMARY KEY ([KioskID]ASC)
)
GO

print '' print'**** Inserting Sample Kiosk Records ****'
GO
INSERT INTO [dbo].[Kiosk]
	([AdministratorID], [GameID], [MovieID])
	VALUES
		(100001, 100001, 100001),
		(100001, 100002, 100002),
		(100001, 100003, 100003),
		(100001, 100004, 100004),
		(100001, NULL,  100005),
		(100001, 100005, 100006),
		(100001, 100006, 100007),
		(100001, 100007, 100008),
		(100001, 100008, 100009),
		(100001, NULL, 1000010),
		(100001, NULL, 100011)
GO

print '' print '**** Creating Genre Table ****'
GO
/* ***Object: Table[dbo].[Genre]*** */

CREATE TABLE [dbo].[Genre] (
	[GenreID] [varchar](50)	NOT NULL,
	
	CONSTRAINT[pk_GenreID] PRIMARY KEY ([GenreID] ASC)
)
GO

print '' print '**** Inserting Sample Genre Records ****'
GO
INSERT INTO [dbo].[Genre]
	([GenreID])
	VALUES
		('Action'),
		('Drama'),
		('Comedy'),
		('Romance'),
		('Shooter'),
		('Simulation'),
		('RPG')
GO

print '' print '**** Creating Medium Table ****'
GO
/* ***Object: Table[dbo].[Medium]*** */

CREATE TABLE [dbo].[Medium] (
	[MediumID] [varchar](10)	NOT NULL,
	
	CONSTRAINT[pk_MediumID] PRIMARY KEY ([MediumID] ASC)
)
GO

print '' print '**** Inserting Medium sample records ****'
GO
INSERT INTO [dbo].[Medium]
	([MediumID])
	VALUES
		('DVD'),
		('Blu-Ray'),
		('PS4'),
		('XBONE'),
		('PC')
GO

print '' print'**** Creating SupplyRecord Table ****'
GO
/* ***Object: Table[dbo].[SupplyRecord]*** */

CREATE TABLE [dbo].[SupplyRecord](
	[SupplyRecordID]	[int]IDENTITY(100000, 1)	NOT NULL,
	[KioskID]			[int]						NOT NULL,
	[SupplierID]		[int]						NOT NULL,
	[MovieID]			[int]						,
	[GameID]			[int]						,
	
	CONSTRAINT	[pk_SupplyRecordID] PRIMARY KEY ([SupplyRecordID] ASC)
)
GO

print '' print '**** Inserting SupplyRecord Sample Records ****'
GO
INSERT INTO [dbo].[SupplyRecord]
	([KioskID], [SupplierID], [MovieID], [GameID])
	VALUES
		(100000, 100000, 100000, 100000),
		(100000, 100000, 100001, 100001),
		(100000, 100000, 100002, NULL),
		(100000, 100000, 100003, NULL),
		(100000, 100001, 100004, 100002),
		(100000, 100001, 100005, 100003),
		(100000, 100001, 100006, 100004),
		(100000, 100001, 100007, NULL),
		(100000, 100002, 100008, 100005),
		(100000, 100002, 100009, 100006),
		(100000, 100002, 100010, 100007),
		(100000, 100002, 100011, 100008)
GO



print '' print '**** Creating Movies GenreID Foreign Key ****'
GO
ALTER TABLE [dbo].[Movies] WITH NOCHECK
	ADD CONSTRAINT [fk_GenreID] FOREIGN KEY ([GenreID])
	REFERENCES [dbo].[Genre] ([GenreID])
	ON UPDATE CASCADE
GO

print '' print '**** Creating Medium MediumID FOREIGN Key ****'
GO
ALTER TABLE [dbo].[Movies] WITH NOCHECK
	ADD CONSTRAINT [fk_MediumID] FOREIGN KEY ([MediumID])
	REFERENCES [dbo].[Medium] ([MediumID])
	ON UPDATE CASCADE
GO
	
print '' print '**** Creating RentalRecord KioskID foreign key ****'
GO
ALTER TABLE [dbo].[RentalRecord] WITH NOCHECK
	ADD CONSTRAINT [fk_KioskID] FOREIGN KEY ([KioskID])
	REFERENCES [dbo].[Kiosk] ([KioskID])
	ON UPDATE CASCADE
GO

print '' print '**** Creating RentalRecord CustomerID foreign key ****'
GO
ALTER TABLE [dbo].[RentalRecord] WITH NOCHECK
	ADD CONSTRAINT [fk_CustomerID] FOREIGN KEY ([CustomerID])
	REFERENCES [dbo].[Customer] ([CustomerID])
	ON UPDATE CASCADE
GO

print '' print '**** Creating RentalRecord MovieID foreign key ****'
GO
ALTER TABLE [dbo].[RentalRecord] WITH NOCHECK
	ADD CONSTRAINT [fk_MovieID] FOREIGN KEY ([MovieID])
	REFERENCES [dbo].[Movies] ([MovieID])
	ON UPDATE CASCADE
GO

print '' print '**** Creating RentalRecord GameID foreign key ****'
GO
ALTER TABLE [dbo].[RentalRecord] WITH NOCHECK
	ADD CONSTRAINT [fk_GameID] FOREIGN KEY ([GameID])
	REFERENCES [dbo].[Games] ([GameID])
	ON UPDATE CASCADE
GO

print '' print '**** Creating SuplyRecord SupplierID foreign key ****'
GO
ALTER TABLE [dbo].[SupplyRecord] WITH NOCHECK
	ADD CONSTRAINT [fk_SupplierID] FOREIGN KEY ([SupplierID])
	REFERENCES [dbo].[Supplier] ([SupplierID])
	ON UPDATE CASCADE
GO

print '' print '**** Creating sp_create_movie ****'
GO
CREATE PROCEDURE [dbo].[sp_create_movie]
	(
		@Title				varchar(250),
		@GenreID			varchar(50),
		@Description		varchar(500),
		@Rating				varchar(15),
		@MediumID			varchar(10),
		@QuantityAvailable	int,
		@Quantity			int,
		@RentalPrice		decimal(7, 2)
	)
AS
	BEGIN
		INSERT INTO [dbo].[Movies]
			([Title], [GenreID], [Description], [Rating], [MediumID], [QuantityAvailable], [Quantity], [RentalPrice])
		VALUES
			(@Title, @GenreID, @Description, @Rating, @MediumID, @QuantityAvailable, @Quantity, @RentalPrice)
		RETURN @@ROWCOUNT
	END
GO

print '' print '**** Creating sp_authenticate_user ****'
GO
CREATE PROCEDURE [dbo].[sp_authenticate_user]
	(
	@Username varchar(20),
	@PasswordHash varchar(100)
	)
AS
	BEGIN
		SELECT COUNT (CustomerID)
		FROM Customer
		WHERE Username = @Username
		AND PasswordHash = @PasswordHash
	END
GO

print '' print '**** Creating sp_retrieve_customer_by_username'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_customer_by_username]
	(
	@Username varchar(20)
	)
AS
	BEGIN
		SELECT CustomerID, FirstName, LastName, PhoneNumber, Address, Email, Username
		FROM Customer
		WHERE Username = @Username
	END
GO

print '' print '**** Creating sp_authenticate_administrator ****'
GO
CREATE PROCEDURE [dbo].[sp_authenticate_administrator]
	(
	@Username varchar(20),
	@PasswordHash varchar(100)
	)
AS
	BEGIN
		SELECT COUNT (AdministratorID)
		FROM Administrator
		WHERE Username = @Username
		AND PasswordHash = @PasswordHash
	END
GO

print '' print '**** Creating sp_retrieve_administrator_by_username ****'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_administrator_by_username]
	(
	@Username varchar(100)
	)
AS
	BEGIN
		SELECT AdministratorID, FirstName, LastName, Username
		FROM Administrator
		WHERE Username = @Username
	END
GO
	
print '' print '**** Creating sp_update_passwordHash ****'
GO
CREATE PROCEDURE [dbo].[sp_update_passwordHash]
(
	@Username varchar(20),
	@OldPasswordHash varchar(100),
	@NewPasswordHash varchar(100)
)
AS
	BEGIN
		UPDATE Customer
			SET PasswordHash = @NewPasswordHash
			WHERE Username = @Username
			AND PasswordHash = @OldPasswordHash
		RETURN @@ROWCOUNT
	END
GO

print '' print '**** Creating sp_edit_movie *******'
GO
CREATE PROCEDURE [dbo].[sp_edit_movie]
	(
	@MovieID int,
	@OldDescription varchar(500),
	@NewDescription varchar(500),
	@OldQuantity	int,
	@NewQuantity	int,
	@OldQuantityAvailable int, 
	@NewQuantityAvailable int,
	@OldRentalPrice decimal(7, 2),
	@NewRentalPrice decimal(7, 2 ),
	@OldActive bit, 
	@NewActive bit
	)
AS	
	BEGIN
		UPDATE Movies
			SET Description = @NewDescription,
				Active = @NewActive,
				RentalPrice = @NewRentalPrice,
				Quantity = @NewQuantity,
				QuantityAvailable = @NewQuantityAvailable
			WHERE MovieID = @MovieID
			AND Active = @OldActive
		RETURN @@ROWCOUNT
	END
GO



print '' print '**** Creating sp_add_user ****'
GO
CREATE PROCEDURE [dbo].[sp_add_user]
(
	@Username varchar(20),
	@PasswordHash varchar(100),
	@FirstName varchar(250), 
	@LastName varchar(250), 
	@PhoneNumber varchar(9),
	@Address varchar(500),
	@Email varchar(200)
)
AS
	BEGIN
		INSERT INTO [dbo].[Customer]
		([Username], [PasswordHash], [FirstName], [LastName], [PhoneNumber], [Address], [Email])
		VALUES
			(@Username, @PasswordHash, @FirstName, @LastName, @PhoneNumber, @Address, @Email)
	END
GO

print '' print '**** Creating sp_retrieve_available_movies ****'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_available_movies]
AS 
	BEGIN
		SELECT MovieID, Title, GenreID, Description, Rating, MediumID, QuantityAvailable, Quantity, RentalPrice
		FROM Movies
		WHERE QuantityAvailable >= 1
		AND Active = 1
	END
GO

print '' print'**** Creating sp_retrieve_all_available_games ****'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_all_available_games]
AS
	BEGIN
		SELECT GameID, Title, GenreID, Description, Rating, MediumID, QuantityAvailable, Quantity, RentalPrice
		FROM Games
		WHERE QuantityAvailable >= 1
		AND Active = 1
	END
GO

print '' print '**** Creating sp_retrieve_movies_by_medium ****'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_movies_by_medium]
	(
	@MediumID varchar(20)
	)
AS 
	BEGIN
		SELECT MovieID, Title, GenreID, Description, Rating, MediumID, QuantityAvailable, Quantity, RentalPrice
		FROM Movies
		WHERE MediumID = @MediumID
		AND MediumID LIKE CONCAT('%',@MediumID,'%')
		AND QuantityAvailable >= 1
		AND Active = 1
	END
GO

print '' print '**** Creating sp_retrieve_games_by_medium ****'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_games_by_medium]
	(
	@MediumID varchar(20)
	)
AS 
	BEGIN
		SELECT GameID, Title, GenreID, Description, Rating, MediumID, QuantityAvailable, Quantity, RentalPrice
		FROM Games
		WHERE MediumID = @MediumID
		AND MediumID LIKE CONCAT('%',@MediumID,'%')
		AND QuantityAvailable >= 1
		AND Active = 1
	END
GO

print '' print '**** Creating sp_filter_movies_by_genre ****'
GO
CREATE PROCEDURE [dbo].[sp_filter_movies_by_genre]
	(
		@GenreID varchar(50)
	)
AS 
	BEGIN
		SELECT MovieID, Title, GenreID, Description, Rating, MediumID, QuantityAvailable, Quantity, RentalPrice
		FROM Movies
		WHERE GenreID = @GenreID
		AND QuantityAvailable >= 1
		AND Active = 1
	END
GO

print '' print '**** Creating sp_filter_games_by_genre ****'
GO
CREATE PROCEDURE [dbo].[sp_filter_games_by_genre]
	(
		@GenreID varchar(50)
	)
AS 
	BEGIN
		SELECT GameID, Title, GenreID, Description, Rating, MediumID, QuantityAvailable, Quantity, RentalPrice
		FROM Games
		WHERE GenreID = @GenreID
		AND QuantityAvailable >= 1
		AND Active = 1
	END
GO

print '' print '**** Creating sp_filter_movies_by_genre_and_medium ****'
GO
CREATE PROCEDURE [dbo].[sp_filter_movies_by_genre_and_medium]
	(
	@GenreID varchar(50),
	@MediumID varchar(20)
	)
AS
	BEGIN
		SELECT MovieID, Title, GenreID, Description, Rating, MediumID, QuantityAvailable, Quantity, RentalPrice
		FROM Movies
		WHERE GenreID = @GenreID
		AND MediumID = @MediumID
		AND QuantityAvailable >= 1
		AND Active = 1
	END
GO

print '' print '**** Creating sp_filter_games_by_genre_and_medium ****'
GO
CREATE PROCEDURE [dbo].[sp_filter_games_by_genre_and_medium]
	(
	@GenreID varchar(50),
	@MediumID varchar(20)
	)
AS
	BEGIN
		SELECT GameID, Title, GenreID, Description, Rating, MediumID, QuantityAvailable, Quantity, RentalPrice
		FROM Games
		WHERE GenreID = @GenreID
		AND MediumID = @MediumID
		AND QuantityAvailable >= 1
		AND Active = 1
	END
GO

print '' print '**** Creating sp_retrieve_movies_by_kioskId_and_adminId ****'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_movies_by_kioskId_and_adminId]
	(
	@KioskID int,
	@AdministratorID int
	)
AS
	BEGIN
		SELECT DISTINCT Movies.MovieID, Movies.Title, Movies.GenreID, Movies.Description, Movies.Rating, Movies.MediumID, Movies.QuantityAvailable, Movies.Quantity, Movies.RentalPrice
		FROM Kiosk, Movies, Administrator
		WHERE Kiosk.KioskID = @KioskID
		AND Kiosk.AdministratorID = @AdministratorID
		AND Movies.Active = 1
	END
GO

print '' print '**** Creating sp_retreive_games_by_kioskId_and_adminId ****'
GO
CREATE PROCEDURE [dbo].[sp_retreive_games_by_kioskId_and_adminId]
	(
	@KioskID int,
	@AdministratorID int
	)
AS
	BEGIN
		SELECT DISTINCT Games.GameID, Games.Title, Games.GenreID, Games.Description, Games.Rating, Games.MediumID, Games.QuantityAvailable, Games.Quantity, Games.RentalPrice
		FROM Kiosk, Games, Administrator
		WHERE Kiosk.KioskID = @KioskID
		AND Kiosk.AdministratorID = @AdministratorID
		AND Games.Active = 1
	END
GO

print '' print '**** Creating sp_deactivate_movies ****'
GO
CREATE PROCEDURE [dbo].[sp_change_movie_status]
	(
	@MovieID int,
	@OldActive bit, 
	@NewActive bit
	)
AS	
	BEGIN
		UPDATE Movies
			SET Active = @NewActive
			WHERE MovieID = @MovieID
			AND Active = @OldActive
		RETURN @@ROWCOUNT
	END
GO

print '' print '**** Creating sp_change_game_status ****'
GO
CREATE PROCEDURE [dbo].[sp_change_game_status]
	(
	@GameID int,
	@OldActive bit,
	@NewActive bit
	)
AS
	BEGIN
		UPDATE Games
			SET Active = @NewActive
			WHERE Active = @OldActive
			AND GameID = @GameID
		RETURN @@ROWCOUNT
	END
GO

print '' print '**** Creating sp_retreive_supplier_movie_stock ****'
GO
CREATE PROCEDURE [dbo].[sp_retreive_supplier_movie_stock]
	(
	@SupplierID int
	)
AS
	BEGIN
		SELECT DISTINCT SupplyRecord.MovieID, Movies.Title, Movies.GenreID, Movies.Description, Movies.Rating, Movies.MediumID, Movies.QuantityAvailable, Movies.Quantity, Movies.RentalPrice
		FROM Supplier, Movies, SupplyRecord
		WHERE SupplyRecord.MovieID = Movies.MovieID
		AND SupplyRecord.SupplierID = @SupplierID
		AND Active = 0
	END
GO

print '' print '**** Creating sp_retreive_supplier_game_stock ****' print ''
GO
CREATE PROCEDURE [dbo].[sp_retreive_supplier_game_stock]
	(
	@SupplierID int
	)
AS
	BEGIN
		SELECT DISTINCT SupplyRecord.GameID, Games.Title, Games.GenreID, Games.Description, Games.Rating, Games.MediumID, Games.QuantityAvailable, Games.Quantity, Games.RentalPrice
		FROM Supplier, Games, SupplyRecord
		WHERE SupplyRecord.GameID = Games.GameID
		AND SupplyRecord.SupplierID = @SupplierID
		AND Active = 0
	END
GO
USE CIS;

GO

--InsertBand script--

CREATE PROCEDURE InsertBand
	@BandName VARCHAR(60),
	@BandCountry VARCHAR(60),
	@BandID INT = 0 OUT
AS
	DECLARE @Counter INT
	
	SELECT @Counter = COUNT(BandID) FROM Band WHERE Name = @BandName AND Country = @BandCountry
	
	IF (@Counter > 0)
	BEGIN
		SELECT @BandID = BandID FROM Band WHERE Name = @BandName AND Country = @BandCountry
	END
	
	ELSE
	BEGIN
		INSERT INTO Band (Name, Country) VALUES (@BandName, @BandCountry)
		SELECT @BandID = BandID FROM Band WHERE Name = @BandName AND Country = @BandCountry
	END

--InsertPlace script--

GO

CREATE PROCEDURE InsertPlace
	@PlaceName VARCHAR(60),
	@PlaceID INT = 0 OUT
AS
	DECLARE @Counter INT
	
	SELECT @Counter = COUNT(PlaceID) FROM Place WHERE Name = @PlaceName
	
	IF (@Counter > 0)
	BEGIN
		SELECT @PlaceID = PlaceID FROM Place WHERE Name = @PlaceName
	END
	
	ELSE
	BEGIN
		INSERT INTO Place (Name) VALUES (@PlaceName)
		SELECT @PlaceID = PlaceID FROM Place WHERE Name = @PlaceName
	END

--InsertBandConcert script--

GO

CREATE PROCEDURE InsertBandConcert
	@BandID INT,
	@ConcertID INT
AS
	DECLARE @Counter INT
	
	SELECT @Counter = COUNT(BandID) FROM BandConcertMap WHERE BandID = @BandID AND ConcertID = @ConcertID
	
	IF (@Counter = 0)
	BEGIN
		INSERT INTO BandConcertMap (BandID, ConcertID) VALUES (@BandID, @ConcertID)
	END

--InsertConcert script--

GO

CREATE PROCEDURE InsertConcert
	@ConcertName VARCHAR(45),
	@PlaceID INT,
	@Date DATETIME,
	@ConcertID INT = 0 OUT
AS
	DECLARE @Counter INT
	
	SELECT @Counter = COUNT(ConcertID) FROM Concert WHERE Name = @ConcertName AND PlaceID = @PlaceID AND Date = @Date
	
	IF (@Counter > 0)
	BEGIN
		SELECT @ConcertID = ConcertID FROM Concert WHERE Name = @ConcertName AND PlaceID = @PlaceID AND Date = @Date
	END
	
	ELSE
	BEGIN
		INSERT INTO Concert (Name, PlaceID, Date) VALUES (@ConcertName, @PlaceID, @Date)
		SELECT @ConcertID = ConcertID FROM Concert WHERE Name = @ConcertName AND PlaceID = @PlaceID AND Date = @Date
	END

--InsertGenre script--

GO

CREATE PROCEDURE InsertGenre
	@GenreName VARCHAR(45),
	@GenreID INT = 0 OUT
AS
	DECLARE @Counter INT
	
	SELECT @Counter = COUNT(GenreID) FROM Genre WHERE Name = @GenreName
	
	IF (@Counter = 0)
	BEGIN
		INSERT INTO Genre (Name) VALUES (@GenreName)
	END

	BEGIN
		SELECT @GenreID = GenreID FROM Genre WHERE Name = @GenreName
	END

--InsertBandGenreMap script--

GO

CREATE PROCEDURE InsertBandGenreMap
	@BandID INT,
	@GenreID INT
AS
	DECLARE @Counter INT
	
	SELECT @Counter = COUNT(BandID) FROM BandGenreMap WHERE BandID = @BandID AND GenreID = @GenreID
	
	IF (@Counter = 0)
	BEGIN
		INSERT INTO BandGenreMap (BandID, GenreID) VALUES (@BandID, @GenreID)
	END

--InsertAdmin script--

GO

CREATE PROCEDURE InsertAdmin
	@AdminEmail VARCHAR(45),
	@AdminName VARCHAR(45),
	@AdminSalt VARCHAR(32),
	@AdminHash VARCHAR(32)
AS
	INSERT INTO Admin (Email, Name, PasswordHash, Salt) VALUES (@AdminEmail, @AdminName, @AdminHash, @AdminSalt)

--GetAdmins script--

GO

CREATE PROCEDURE GetAdmins
AS
	SELECT Email, Name FROM Admin

--InsertBandFeedback script--

GO

CREATE PROCEDURE InsertBandFeedback
	@BandID INT,
	@Email VARCHAR(45),
	@Name VARCHAR(45),
	@Comment TEXT,
	@Vote INT,
	@Message VARCHAR(45) OUT
AS
	DECLARE @Counter INT

	SELECT @Counter=COUNT(Email) FROM BandFeedback WHERE Email = @Email AND BandID = @BandID

	IF (@Counter = 0)
	BEGIN
		INSERT INTO BandFeedback (BandID, Email, Name, Comment, Vote) VALUES (@BandID, @Email, @Name, @Comment, @Vote)
		SET @Message = 'OK'
	END
	ELSE
	BEGIN
		SET @Message = 'Already exists, updating...'
		UPDATE BandFeedback SET Name = @Name, Comment = @Comment, Vote = @Vote WHERE BandID = @BandID AND Email = @Email
	END

--InsertPlaceFeedback script--

GO

CREATE PROCEDURE InsertPlaceFeedback
	@PlaceID INT,
	@Email VARCHAR(45),
	@Name VARCHAR(45),
	@Comment TEXT,
	@Vote INT,
	@Message VARCHAR(45) OUT
AS
	DECLARE @Counter INT

	SELECT @Counter=COUNT(Email) FROM PlaceFeedback WHERE Email = @Email AND PlaceID = @PlaceID

	IF (@Counter = 0)
	BEGIN
		INSERT INTO PlaceFeedback (PlaceID, Email, Name, Comment, Vote) VALUES (@PlaceID, @Email, @Name, @Comment, @Vote)
		SET @Message = 'OK'
	END
	ELSE
	BEGIN
		SET @Message = 'Already exists, updating...'
		UPDATE PlaceFeedback SET Name = @Name, Comment = @Comment, Vote = @Vote WHERE PlaceID = @PlaceID AND Email = @Email
	END

--InsertConcertFeedback script--

GO

CREATE PROCEDURE InsertConcertFeedback
	@ConcertID INT,
	@Email VARCHAR(45),
	@Name VARCHAR(45),
	@Comment TEXT,
	@Vote INT,
	@Message VARCHAR(45) OUT
AS
	DECLARE @Counter INT

	SELECT @Counter=COUNT(Email) FROM ConcertFeedback WHERE Email = @Email AND ConcertID = @ConcertID

	IF (@Counter = 0)
	BEGIN
		INSERT INTO ConcertFeedback (ConcertID, Email, Name, Comment, Vote) VALUES (@ConcertID, @Email, @Name, @Comment, @Vote)
		SET @Message = 'OK'
	END
	ELSE
	BEGIN
		SET @Message = 'Already exists, updating...'
		UPDATE ConcertFeedback SET Name = @Name, Comment = @Comment, Vote = @Vote WHERE ConcertID = @ConcertID AND Email = @Email
	END
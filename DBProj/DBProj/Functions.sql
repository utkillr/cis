USE CIS

GO

CREATE FUNCTION dbo.CountAdmins ()
RETURNS INT
	AS
	BEGIN
		DECLARE @Count INT
		SELECT @Count = Count(Email) FROM Admin
		RETURN @Count
	END

GO

CREATE FUNCTION GetSalt
	(@Email VARCHAR(45))
RETURNS VARCHAR(32)
	AS
	BEGIN
		DECLARE @Salt VARCHAR(32)
		SELECT @Salt = Salt FROM Admin WHERE Email=@Email
		RETURN @Salt
	END

GO

CREATE FUNCTION GetHash
	(@Email VARCHAR(45))
RETURNS VARCHAR(32)
	AS
	BEGIN
		DECLARE @Hash VARCHAR(32)
		SELECT @Hash = PasswordHash FROM Admin WHERE Email=@Email
		RETURN @Hash
	END

GO

CREATE FUNCTION GetBandRating
	(@BandID AS INT)
RETURNS FLOAT
	AS
	BEGIN
		DECLARE @Rating FLOAT
		SELECT @Rating = AVG(Cast(Vote AS FLOAT)) FROM BandFeedback WHERE BandID = @BandID
		RETURN @Rating
	END

GO

CREATE FUNCTION GetPlaceRating
	(@PlaceID AS INT)
RETURNS FLOAT
	AS
	BEGIN
		DECLARE @Rating FLOAT
		SELECT @Rating = AVG(Cast(Vote AS FLOAT)) FROM PlaceFeedback WHERE PlaceID = @PlaceID
		RETURN @Rating
	END

GO

CREATE FUNCTION GetConcertRating
	(@ConcertID AS INT)
RETURNS FLOAT
	AS
	BEGIN
		DECLARE @Rating FLOAT
		SELECT @Rating = AVG(Cast(Vote AS FLOAT)) FROM ConcertFeedback WHERE ConcertID = @ConcertID
		RETURN @Rating
	END

GO

CREATE FUNCTION GetLiveRating
	(@BandID AS INT)
RETURNS FLOAT
	AS
	BEGIN
		DECLARE @Rating FLOAT
		SELECT @Rating = AVG(Cast(ConcertFeedback.Vote AS FLOAT)) FROM ConcertFeedback
			INNER JOIN Concert ON Concert.ConcertID = ConcertFeedback.ConcertID
			INNER JOIN BandConcertMap ON BandConcertMap.ConcertID = Concert.ConcertID
			WHERE BandConcertMap.BandID = @BandID
		RETURN @Rating
	END

--listings--

GO

--Criteria: 0 - No, 1 - Rating, 2 - LiveRating--
--Amount: 0 - all
CREATE FUNCTION GetNBands
	(@Amount INT, @Criteria INT)
RETURNS @R TABLE (
	BandID INT NOT NULL,
	Name VARCHAR(60) NOT NULL,
	Review TEXT,
	OffSite TEXT,
	FanSite TEXT,
	Country VARCHAR(60) NOT NULL,
	ImageURL TEXT,
	Approved BIT DEFAULT 0,
	Rating FLOAT,
	LiveRating FLOAT)
AS
	BEGIN
		IF (@Amount = 0)
		BEGIN
			IF (@Criteria = 0)
			BEGIN
				INSERT INTO @R SELECT *, dbo.GetBandRating(BandID) AS Rating, dbo.GetLiveRating(BandID) AS LiveRating FROM Band ORDER BY BandID
			END
			ELSE IF (@Criteria = 1)
			BEGIN
				INSERT INTO @R SELECT *, dbo.GetBandRating(BandID) AS Rating, dbo.GetLiveRating(BandID) AS LiveRating FROM Band ORDER BY Rating DESC
			END
			ELSE
			BEGIN
				INSERT INTO @R SELECT *, dbo.GetBandRating(BandID) AS Rating, dbo.GetLiveRating(BandID) AS LiveRating FROM Band ORDER BY LiveRating DESC
			END
		END
		ELSE IF (@Amount > 0)
		BEGIN
			IF (@Criteria = 0)
			BEGIN
				INSERT INTO @R SELECT TOP(@Amount) *, dbo.GetBandRating(BandID) AS Rating, dbo.GetLiveRating(BandID) AS LiveRating FROM Band ORDER BY BandID
			END
			ELSE IF (@Criteria = 1)
			BEGIN
				INSERT INTO @R SELECT TOP(@Amount) *, dbo.GetBandRating(BandID) AS Rating, dbo.GetLiveRating(BandID) AS LiveRating FROM Band ORDER BY Rating DESC
			END
			ELSE
			BEGIN
				INSERT INTO @R SELECT TOP(@Amount) *, dbo.GetBandRating(BandID) AS Rating, dbo.GetLiveRating(BandID) AS LiveRating FROM Band ORDER BY LiveRating DESC
			END
		END
		RETURN
	END

GO

--Criteria: 0 - No, 1 - Rating--
CREATE FUNCTION GetNPlaces
	(@Amount INT, @Criteria INT)
RETURNS @R TABLE (
	PlaceID INT NOT NULL,
	Name VARCHAR(60) NOT NULL,
	Address TEXT,
	Phone VARCHAR(25),
	OffSite TEXT,
	Email VARCHAR(45),
	Handler VARCHAR(45),
	Review TEXT,
	ImageURL TEXT,
	Approved BIT DEFAULT 0,
	Rating FLOAT)
AS
	BEGIN
		IF (@Amount = 0)
		BEGIN
			IF (@Criteria = 0)
			BEGIN
				INSERT INTO @R SELECT *, dbo.GetPlaceRating(PlaceID) AS Rating FROM Place ORDER BY PlaceID
			END
			ELSE
			BEGIN
				INSERT INTO @R SELECT *, dbo.GetPlaceRating(PlaceID) AS Rating FROM Place ORDER BY Rating DESC
			END
		END
		ELSE IF (@Amount > 0)
		BEGIN
			IF (@Criteria = 0)
			BEGIN
				INSERT INTO @R SELECT TOP(@Amount) *, dbo.GetPlaceRating(PlaceID) AS Rating FROM Place ORDER BY PlaceID
			END
			ELSE
			BEGIN
				INSERT INTO @R SELECT TOP(@Amount) *, dbo.GetPlaceRating(PlaceID) AS Rating FROM Place ORDER BY Rating DESC
			END
		END
		RETURN
	END

GO

--Criteria: 0 - No, 1 - Rating--, 2 - Date and Time
--Amount: 0 - all
CREATE FUNCTION GetNConcerts
	(@Amount INT, @Criteria INT)
RETURNS @R TABLE (
	Name VARCHAR(60) NOT NULL,
	PlaceID INT NOT NULL,
	Date DATETIME NOT NULL,
	Censor INT,
	Review TEXT,
	ImageURL TEXT,
	ConcertID INT NOT NULL,
	Approved BIT DEFAULT 0,
	Rating FLOAT)
AS
	BEGIN
		IF (@Amount = 0)
		BEGIN
			IF (@Criteria = 0)
			BEGIN
				INSERT INTO @R SELECT *, dbo.GetConcertRating(ConcertID) AS Rating FROM Concert ORDER BY ConcertID
			END
			ELSE IF (@Criteria = 1)
			BEGIN
				INSERT INTO @R SELECT *, dbo.GetConcertRating(ConcertID) AS Rating FROM Concert ORDER BY Rating DESC
			END
			ELSE
			BEGIN
				INSERT INTO @R SELECT *, dbo.GetConcertRating(ConcertID) AS Rating FROM Concert ORDER BY Concert.Date 
			END				
		END
		ELSE IF (@Amount > 0)
		BEGIN
			IF (@Criteria = 0)
			BEGIN
				INSERT INTO @R SELECT TOP(@Amount) *, dbo.GetConcertRating(ConcertID) AS Rating FROM Concert ORDER BY ConcertID
			END
			ELSE IF (@Criteria = 1)
			BEGIN
				INSERT INTO @R SELECT TOP(@Amount) *, dbo.GetConcertRating(ConcertID) AS Rating FROM Concert ORDER BY Rating DESC
			END
			ELSE
			BEGIN
				INSERT INTO @R SELECT TOP(@Amount) *, dbo.GetConcertRating(ConcertID) AS Rating FROM Concert ORDER BY Concert.Date
			END
		END
		RETURN
	END

GO

--Amount: 0 - all
CREATE FUNCTION GetNUpcomingConcerts
	(@Amount INT, @Date DATETIME)
RETURNS @R TABLE (
	Name VARCHAR(60) NOT NULL,
	PlaceID INT NOT NULL,
	Date DATETIME NOT NULL,
	Censor INT,
	Review TEXT,
	ImageURL TEXT,
	ConcertID INT NOT NULL,
	Approved BIT DEFAULT 0,
	Rating FLOAT)
AS
	BEGIN
		IF (@Amount = 0)
		BEGIN
			INSERT INTO @R SELECT *, dbo.GetConcertRating(ConcertID) AS Rating FROM Concert WHERE Concert.Date > @Date ORDER BY Concert.Date
		END		
		ELSE IF (@Amount > 0)
		BEGIN
			INSERT INTO @R SELECT TOP(@Amount) *, dbo.GetConcertRating(ConcertID) AS Rating FROM Concert WHERE Concert.Date > @Date ORDER BY Concert.Date
		END
		RETURN
	END
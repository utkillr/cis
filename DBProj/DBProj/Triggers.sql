USE CIS;

GO

--DeleteBand trigger--

CREATE TRIGGER DeleteBand
ON Band
FOR DELETE
AS
	DECLARE @ID INT
	SELECT @ID = BandID FROM deleted
	DELETE FROM BandFeedback WHERE BandID = @ID

	DELETE FROM BandConcertMap WHERE BandID = @ID

	DELETE FROM BandGenreMap WHERE BandID = @ID

--DeleteGenre trigger--

GO

CREATE TRIGGER DeleteGenre
ON Genre
FOR DELETE
AS
	DECLARE @ID INT
	SELECT @ID = GenreID FROM deleted

	DELETE FROM BandGenreMap WHERE GenreID = @ID

--DeleteConcert trigger--

GO

CREATE TRIGGER DeleteConcert
ON Concert
FOR DELETE
AS
	DECLARE @ID INT
	SELECT @ID = ConcertID FROM deleted
	DELETE FROM ConcertFeedback WHERE ConcertID = @ID

	DELETE FROM BandConcertMap WHERE ConcertID = @ID

--DeletePlace trigger--

GO

CREATE TRIGGER DeletePlace
ON Place
FOR DELETE
AS
	DECLARE @ID INT
	SELECT @ID = PlaceID FROM deleted
	DELETE FROM PlaceFeedback WHERE PlaceID = @ID

	DELETE FROM BandPlaceMap WHERE PlaceID = @ID

--DeleteBandGenreMap trigger--

GO

/*
CREATE TRIGGER DeleteBandGenreMap
ON BandGenreMap
INSTEAD OF DELETE
AS
	RAISERROR('No permission to delete from map', 16, 1)
	*/
/*
CREATE TRIGGER DeleteBandGenreMap
ON BandGenreMap
INSTEAD OF DELETE
AS
	DECLARE @BID INT
	DECLARE @GID INT
	SELECT @BID = BandID, @GID = GenreID FROM deleted

	DECLARE @Counter INT

	SELECT @Counter = COUNT(BandID) FROM BandGenreMap WHERE GenreID = @GID

	IF (@Counter = 1)
	BEGIN
		DELETE FROM Band WHERE BandID = @BID
	END

	DELETE FROM BandGenreMap WHERE BandID = @BID AND GenreID = @GID
	--if that's the only genre - delete from band--
	*/

--DeleteBandConcertMap trigger--
/*
GO

CREATE TRIGGER DeleteBandConcertMap
ON BandConcertMap
INSTEAD OF DELETE
AS
	RAISERROR('No permission to delete from map', 16, 1)
*/	
--NotNecessary trigger--

GO

CREATE TRIGGER NotNecessary
ON Admin
FOR DELETE, UPDATE
AS
	IF EXISTS(SELECT * FROM DELETED)
	BEGIN
		SELECT 'Deleted' AS 'Action', Email, Name, PasswordHash, Salt FROM DELETED
	END
	ELSE
	BEGIN
		SELECT 'Inserted' AS 'Action', Email, Name, PasswordHash, Salt FROM DELETED
	END
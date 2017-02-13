USE CIS

GO

CREATE VIEW CutBand
AS
	SELECT BandID, Name, Country, ImageURL, Rating = dbo.GetBandRating(BandID), LiveRating = dbo.GetLiveRating(BandID) FROM Band

GO

CREATE VIEW CutConcert
AS
	SELECT Concert.ConcertID, Concert.Name as ConcertName, Concert.Date, Place.Name as PlaceName, Concert.ImageURL, Rating = dbo.GetConcertRating(ConcertID) FROM Concert
	INNER JOIN Place ON Concert.PlaceID = Place.PlaceID

GO

CREATE VIEW CutPlace
AS
	SELECT PlaceID, Name, Address, ImageURL, Rating = dbo.GetPlaceRating(PlaceID) FROM Place

GO

CREATE VIEW ApprovedGenreIDs 
AS
	SELECT GenreID FROM Genre WHERE Approved = 1

GO

CREATE VIEW ApprovedBandIDs 
AS
	SELECT BandID FROM Band WHERE Approved = 1

GO

CREATE VIEW ApprovedPlaceIDs 
AS
	SELECT PlaceID FROM Place WHERE Approved = 1
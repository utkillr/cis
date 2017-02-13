USE CIS
/*
CREATE CLUSTERED INDEX IX_Band_BandID
ON Band(BandID)

GO

CREATE CLUSTERED INDEX IX_Place_PlaceID
ON Place(PlaceID)

GO

CREATE CLUSTERED INDEX IX_Concert_ConcertID
ON Concert(ConcertID)

GO

CREATE CLUSTERED INDEX IX_Genre_GenreID
ON Genre(GenreID)

GO

CREATE CLUSTERED INDEX IX_Admin_Email
ON Admin(Email)
------
*/ ---Already done in CREATE
GO

CREATE NONCLUSTERED INDEX IX_BandGenreMap_BandGenre
ON BandGenreMap(BandID, GenreID)

GO

CREATE NONCLUSTERED INDEX IX_BandConcertMap_BandConcert
ON BandConcertMap(BandID, ConcertID)
------

GO

CREATE UNIQUE INDEX IX_BandFeedback_BandIDEmail
ON BandFeedback(BandID, Email)

GO

CREATE UNIQUE INDEX IX_ConcertFeedback_ConcertIDEmail
ON ConcertFeedback(ConcertID, Email)

GO

CREATE UNIQUE INDEX IX_PlaceFeedback_PlaceIDEmail
ON PlaceFeedback(PlaceID, Email)
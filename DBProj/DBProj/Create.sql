CREATE DATABASE CIS

GO

USE CIS;

GO

--Admin table--

CREATE TABLE Admin (
	Email VARCHAR(45) NOT NULL,
	Name VARCHAR(45) NOT NULL,
	PasswordHash VARCHAR(32) NOT NULL,
	Salt VARCHAR(32),
	CONSTRAINT AdminPK
		PRIMARY KEY (Email)
);

--genre table--

CREATE TABLE Genre (
	GenreID INT NOT NULL IDENTITY(1, 1),
	Name VARCHAR(45) NOT NULL,
	Approved BIT DEFAULT 0, 
	CONSTRAINT GenrePK
		PRIMARY KEY (GenreID)
);

--band table--

CREATE TABLE Band (
	BandID INT NOT NULL IDENTITY(1, 1),
	Name VARCHAR(60) NOT NULL,
	Review TEXT,
	OffSite TEXT,
	FanSite TEXT,
	Country VARCHAR(60) NOT NULL,
	ImageURL TEXT,
	Approved BIT DEFAULT 0, 
	CONSTRAINT BandPK
		PRIMARY KEY (BandID)
);

--bandgenremap--

CREATE TABLE BandGenreMap (
	GenreID INT NOT NULL,
	BandID INT NOT NULL,
	CONSTRAINT BandGenreMapPK
		PRIMARY KEY (GenreID, BandID),
	CONSTRAINT BandGenreMap_GenreFK
		FOREIGN KEY (GenreID)
		REFERENCES Genre(GenreID),
	CONSTRAINT BandGenreMap_BandFK
		FOREIGN KEY (BandID)
		REFERENCES Band(BandID)
)

ALTER TABLE BandGenreMap
NOCHECK CONSTRAINT BandGenreMap_GenreFK

ALTER TABLE BandGenreMap
NOCHECK CONSTRAINT BandGenreMap_BandFK

--place table--

CREATE TABLE Place (
	PlaceID INT NOT NULL IDENTITY(1, 1),
	Name VARCHAR(60) NOT NULL,
	Address TEXT,
	Phone VARCHAR(25),
	OffSite TEXT,
	Email VARCHAR(45),
	Handler VARCHAR(45),
	Review TEXT,
	ImageURL TEXT,
	Approved BIT DEFAULT 0, 
	CONSTRAINT PlacePK
		PRIMARY KEY (PlaceID)
);

--concert table--

CREATE TABLE Concert (
	Name VARCHAR(60) NOT NULL,
	PlaceID INT NOT NULL,
	Date DATETIME NOT NULL,
	Censor INT,
	Review TEXT,
	ImageURL TEXT,
	ConcertID INT NOT NULL IDENTITY(1, 1),
	Approved BIT DEFAULT 0, 
	CONSTRAINT ConcertPK
		PRIMARY KEY (ConcertID),
	CONSTRAINT Concert_PlaceFK
		FOREIGN KEY (PlaceID)
		REFERENCES Place(PlaceID)
);

ALTER TABLE CONCERT
NOCHECK CONSTRAINT Concert_PlaceFK

--bandconcertmap--

CREATE TABLE BandConcertMap (
	BandID INT NOT NULL,
	ConcertID INT NOT NULL,
	CONSTRAINT BandConcertMapPK
		PRIMARY KEY (BandID, ConcertID),
	CONSTRAINT BandConcertMap_BandFK
		FOREIGN KEY (BandID)
		REFERENCES Band(BandID),
	CONSTRAINT BandConcertMap_ConcertFK
		FOREIGN KEY (ConcertID)
		REFERENCES Concert(ConcertID)
)

ALTER TABLE BandConcertMap
NOCHECK CONSTRAINT BandConcertMap_BandFK

ALTER TABLE BandConcertMap
NOCHECK CONSTRAINT BandConcertMap_ConcertFK

--Feedback tables--

CREATE TABLE BandFeedback (
	BandID INT NOT NULL,
	Email VARCHAR(45) NOT NULL,
	Comment TEXT,
	Name VARCHAR(45) NOT NULL,
	Vote INT,
	CONSTRAINT BandFeedbackPK
		PRIMARY KEY (BandID, Email),
	CONSTRAINT BandFeedback_BandPK
		FOREIGN KEY (BandID)
		REFERENCES Band(BandID)
)

CREATE TABLE ConcertFeedback (
	ConcertID INT NOT NULL,
	Email VARCHAR(45) NOT NULL,
	Comment TEXT,
	Name VARCHAR(45) NOT NULL,
	Vote INT,
	CONSTRAINT ConcertFeedbackPK
		PRIMARY KEY (ConcertID, Email),
	CONSTRAINT ConcertFeedback_ConcertPK
		FOREIGN KEY (ConcertID)
		REFERENCES Concert(ConcertID)
)

CREATE TABLE PlaceFeedback (
	PlaceID INT NOT NULL,
	Email VARCHAR(45) NOT NULL,
	Comment TEXT,
	Name VARCHAR(45) NOT NULL,
	Vote INT,
	CONSTRAINT PlaceFeedbackPK
		PRIMARY KEY (PlaceID, Email),
	CONSTRAINT PlaceFeedback_PlacePK
		FOREIGN KEY (PlaceID)
		REFERENCES Place(PlaceID)
)
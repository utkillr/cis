﻿USE CIS

DECLARE BandCursor SCROLL CURSOR
FOR SELECT * FROM Band

GO

DECLARE PlaceCursor SCROLL CURSOR
FOR SELECT * FROM Place

GO

DECLARE ConcertCursor SCROLL CURSOR
FOR SELECT * FROM Concert
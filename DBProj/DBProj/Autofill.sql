USE CIS

--Admin--

EXEC InsertAdmin @AdminEmail = 'admin@admin.com', @AdminName = 'Admin', @AdminHash = '3a4ebf16a4795ad258e5408bae7be341', @AdminSalt = '12345678'
EXEC InsertAdmin @AdminEmail = 'moderator@admin.com', @AdminName = 'Moderator', @AdminHash = '5d53e322bcd0f28c4816f732f2359d0f', @AdminSalt = '12345678'

--Genre--

EXEC InsertGenre @GenreName = 'Rock'
EXEC InsertGenre @GenreName = 'Pop'
EXEC InsertGenre @GenreName = 'Punk'
EXEC InsertGenre @GenreName = 'Hip-Hop'
EXEC InsertGenre @GenreName = 'Alternative'
EXEC InsertGenre @GenreName = 'Jazz'
EXEC InsertGenre @GenreName = 'Blues'
EXEC InsertGenre @GenreName = 'Electronic'

--Band + BandGenreMap--

DECLARE @BID INT

EXEC InsertBand @BandName = 'Muse', @BandCountry = 'Great Britain', @BandID = @BID OUT
EXEC InsertBandGenreMap @BandID = @BID, @GenreID = 1
EXEC InsertBandGenreMap @BandID = @BID, @GenreID = 5
UPDATE Band SET ImageURL='http://cs629520.vk.me/v629520272/385f3/FBh2sQgCg_M.jpg' WHERE BandID = @BID

EXEC InsertBand @BandName = 'Billy Talent', @BandCountry = 'Canada', @BandID = @BID OUT
EXEC InsertBandGenreMap @BandID = @BID, @GenreID = 1
EXEC InsertBandGenreMap @BandID = @BID, @GenreID = 3
UPDATE Band SET ImageURL='http://cs629505.vk.me/v629505474/409f3/jXFvI_bwFyU.jpg' WHERE BandID = @BID

EXEC InsertBand @BandName = 'Arctic Monkeys', @BandCountry = 'Great Britain', @BandID = @BID OUT
EXEC InsertBandGenreMap @BandID = @BID, @GenreID = 1
EXEC InsertBandGenreMap @BandID = @BID, @GenreID = 5
UPDATE Band SET ImageURL='https://pbs.twimg.com/profile_images/378800000127408567/94910b35ff706ad56b897f1d05d3d40e_400x400.jpeg' WHERE BandID = @BID

EXEC InsertBand @BandName = 'Radiohead', @BandCountry = 'Great Britain', @BandID = @BID OUT
EXEC InsertBandGenreMap @BandID = @BID, @GenreID = 1
EXEC InsertBandGenreMap @BandID = @BID, @GenreID = 5
EXEC InsertBandGenreMap @BandID = @BID, @GenreID = 8
UPDATE Band SET ImageURL='http://wannabemagazine.com/wp-content/uploads/2012/01/Cover-logo-Radiohead1.jpg' WHERE BandID = @BID

EXEC InsertBand @BandName = 'Metallica', @BandCountry = 'USA', @BandID = @BID OUT
EXEC InsertBandGenreMap @BandID = @BID, @GenreID = 1
UPDATE Band SET ImageURL='http://images.all-free-download.com/images/graphiclarge/metallica_0_68341.jpg' WHERE BandID = @BID

EXEC InsertBand @BandName = 'Joe Bonamassa', @BandCountry = 'USA', @BandID = @BID OUT
EXEC InsertBandGenreMap @BandID = @BID, @GenreID = 1
EXEC InsertBandGenreMap @BandID = @BID, @GenreID = 7
UPDATE Band SET ImageURL='http://2.bp.blogspot.com/-CI1mRrDfSJA/VWIxoO208-I/AAAAAAAAGHY/dNRENZGsGXo/s1600/jb-blk.png' WHERE BandID = @BID

EXEC InsertBand @BandName = 'Splean', @BandCountry = 'Russia', @BandID = @BID OUT
EXEC InsertBandGenreMap @BandID = @BID, @GenreID = 1
EXEC InsertBandGenreMap @BandID = @BID, @GenreID = 5
UPDATE Band SET ImageURL='http://rocker-store.com/upload/content/0/2/66/27/27626_250_1.jpg' WHERE BandID = @BID

EXEC InsertBand @BandName = 'Poets of the Fall', @BandCountry = 'Finland', @BandID = @BID OUT
EXEC InsertBandGenreMap @BandID = @BID, @GenreID = 1
UPDATE Band SET ImageURL='http://www.poetsofthefall.com/banners/potf_banner_www_2008_300x250_2.jpg' WHERE BandID = @BID

EXEC InsertBand @BandName = 'Green Day', @BandCountry = 'Great Britain', @BandID = @BID OUT
EXEC InsertBandGenreMap @BandID = @BID, @GenreID = 1
EXEC InsertBandGenreMap @BandID = @BID, @GenreID = 3
UPDATE Band SET ImageURL='https://maniacjoe.com/products/greenday_grenade_b2639.jpg' WHERE BandID = @BID

--Place--

EXEC InsertPlace @PlaceName = 'Ледовый дворец'
EXEC InsertPlace @PlaceName = 'A2'
EXEC InsertPlace @PlaceName = 'Cosmonaut'
EXEC InsertPlace @PlaceName = 'Petrovsky Stadium'
UPDATE Place SET Address = 'Petrovsky Island, d.2', Phone = '8 (812) 232-16-22', OffSite = 'http://petrovsky.spb.ru/', Email = 'petrovsky@stad.ru', Handler = 'Zenith', Review = 'Stadium on the island, nice and big, owned by Zenith FB', ImageURL = 'https://upload.wikimedia.org/wikipedia/commons/thumb/b/ba/Petrovsky_Stadium_in_Saint_Petersburg%2C_Russia._View_at_the_sectors_during_the_match_Zenit_SPb-Bayern_Munchen.JPG/300px-Petrovsky_Stadium_in_Saint_Petersburg%2C_Russia._View_at_the_sectors_during_the_match_Zenit_SPb-Bayern_Munchen.JPG'  WHERE Name = 'Petrovsky Stadium'
EXEC InsertPlace @PlaceName = 'Kubrik'
EXEC InsertPlace @PlaceName = 'SIBUR Arena'
UPDATE Place SET Address = 'Krestovsky Island, Futbolnaya alleya, 8', Phone = '+7 (812) 456-08-00', OffSite = 'http://siburarena.com/', Email = 'sibur@arena.ru', Handler = 'Uknown', Review = ':))))0))0)00)', ImageURL = 'https://pp.vk.me/c618429/v618429408/1d66/F1YLIlqk_tU.jpg' WHERE Name = 'SIBUR Arena'



--Concert + BandConcertMap--

DECLARE @CID INT

EXEC InsertConcert @ConcertName = 'GreenFest', @PlaceID = 4, @Date = '2015-07-23 17:00', @ConcertID = @CID OUT
EXEC InsertBandConcert @BandID = 1, @ConcertID = @CID
EXEC InsertBandConcert @BandID = 8, @ConcertID = @CID
UPDATE Concert SET ImageURL='http://dolphingroup.by/wp-content/uploads/2014/12/grinfest_myuz.jpg' WHERE ConcertID = @CID

EXEC InsertConcert @ConcertName = 'GreenDay Live', @PlaceID = 4, @Date = '2016-10-31 19:00', @ConcertID = @CID OUT
EXEC InsertBandConcert @BandID = 9, @ConcertID = @CID
UPDATE Concert SET ImageURL='http://images4.fanpop.com/image/photos/23400000/Green-Day-Live-green-day-23407538-365-280.jpg' WHERE ConcertID = @CID

EXEC InsertConcert @ConcertName = 'How deep this river runs', @PlaceID = 4, @Date = '2008-08-08 20:00', @ConcertID = @CID OUT
EXEC InsertBandConcert @BandID = 6, @ConcertID = @CID
EXEC InsertBandConcert @BandID = 7, @ConcertID = @CID
UPDATE Concert SET ImageURL='http://muzmania.co/images/album_cover/11942_l.jpg' WHERE ConcertID = @CID

EXEC InsertConcert @ConcertName = 'OK Computer', @PlaceID = 4, @Date = '2012-04-19 18:00', @ConcertID = @CID OUT
EXEC InsertBandConcert @BandID = 4, @ConcertID = @CID
EXEC InsertBandConcert @BandID = 8, @ConcertID = @CID
UPDATE Concert SET ImageURL='http://ecx.images-amazon.com/images/I/61SYxGXYCkL.jpg' WHERE ConcertID = @CID

EXEC InsertConcert @ConcertName = 'Billy Talent', @PlaceID = 3, @Date = '2016-05-30 20:00', @ConcertID = @CID OUT
EXEC InsertBandConcert @BandID = 2, @ConcertID = @CID
UPDATE Concert SET ImageURL='https://upload.wikimedia.org/wikipedia/commons/e/ec/Billy_Talent_at_Rock_Am_See_2007.jpg' WHERE ConcertID = @CID

--a little bit of feedback--

DECLARE @MSG VARCHAR(45)

EXEC InsertBandFeedback @BandID = 1, @Email = '123@emc.com', @Name = 'kek', @Comment = 'nice', @Vote = 5, @Message = @MSG OUT
EXEC InsertBandFeedback @BandID = 2, @Email = '12123@emc.com', @Name = 'kekkek', @Comment = 'ni13123ce', @Vote = 3, @Message = @MSG OUT
EXEC InsertBandFeedback @BandID = 1, @Email = '121233@emc.com', @Name = 'lalldd', @Comment = 'n12ice', @Vote = 4, @Message = @MSG OUT
EXEC InsertBandFeedback @BandID = 3, @Email = '12233@emc.com', @Name = 'eefdv', @Comment = 'ni123ce', @Vote = 4, @Message = @MSG OUT

EXEC InsertPlaceFeedback @PlaceID = 1, @Email = '123@emc.com', @Name = 'kek', @Comment = 'nice', @Vote = 5, @Message = @MSG OUT
EXEC InsertPlaceFeedback @PlaceID = 2, @Email = '12123@emc.com', @Name = 'kekkek', @Comment = 'ni13123ce', @Vote = 3, @Message = @MSG OUT
EXEC InsertPlaceFeedback @PlaceID = 1, @Email = '121233@emc.com', @Name = 'lalldd', @Comment = 'n12ice', @Vote = 4, @Message = @MSG OUT
EXEC InsertPlaceFeedback @PlaceID = 3, @Email = '12233@emc.com', @Name = 'eefdv', @Comment = 'ni123ce', @Vote = 4, @Message = @MSG OUT

EXEC InsertConcertFeedback @ConcertID = 1, @Email = '123@emc.com', @Name = 'kek', @Comment = 'nice', @Vote = 5, @Message = @MSG OUT
EXEC InsertConcertFeedback @ConcertID = 2, @Email = '12123@emc.com', @Name = 'kekkek', @Comment = 'ni13123ce', @Vote = 3, @Message = @MSG OUT
EXEC InsertConcertFeedback @ConcertID = 1, @Email = '121233@emc.com', @Name = 'lalldd', @Comment = 'n12ice', @Vote = 4, @Message = @MSG OUT
EXEC InsertConcertFeedback @ConcertID = 3, @Email = '12233@emc.com', @Name = 'eefdv', @Comment = 'ni123ce', @Vote = 4, @Message = @MSG OUT

UPDATE Band SET Approved = 1
UPDATE Concert SET Approved = 1
UPDATE Place SET Approved = 1
UPDATE Genre SET Approved = 1
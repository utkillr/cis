using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace CIS
{
    /* Constructor creates new instance.
     * Suggest sets fields and saves new record to DB (INSERT)
     * Approve just sets Approved to true in instance
     * Decline deletes all the fields and deletes from DB (DELETE)
     * UploadFromDB gets values from DB to instance
     * SaveToDB updates record in DB (UPDATE)
     */

    class Entity
    {
        protected string name;
        protected string review;
        protected bool approved;
        protected string imageURL;
        double rating;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Review
        {
            get
            {
                return review;
            }
            set
            {
                review = value;
            }
        }

        public bool Approved
        {
            get
            {
                return approved;
            }
            set
            {
                approved = value;
            }
        }

        public string ImageURL
        {
            get
            {
                return imageURL;
            }
            set
            {
                imageURL = value;
            }
        }

        public double Rating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value;
            }
        }
    }

    class Genre : Entity, IManage
    {
        int genreID;

        public int GenreID
        {
            get
            {
                return genreID;
            }
            set
            {
                genreID = value;
            }
        }

        public Genre() {
            GenreID = -1;
            Name = "";
            Review = "";
            Approved = false;
            ImageURL = "";
        }

        public Genre(int GenreID, string Name)
        {
            this.GenreID = GenreID;
            this.Name = Name;
        }

        public void UploadFromDB(int EntityID)
        {
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Name, Approved from Genre WHERE GenreID = " + EntityID, myConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    GenreID = EntityID; 
                    
                    reader.Read();
                    
                    if (!reader.IsDBNull(0))
                        Name = reader.GetString(0);
                    if (!reader.IsDBNull(1))
                        Approved = reader.GetBoolean(1);
                    
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SaveToDB()
        {
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Genre SET Name = \'" + Name + "\' WHERE GenreID = " + GenreID, myConnection);
                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int Suggest(Dictionary<string, object> Info)
        {
            if (Info.ContainsKey("name"))
                Name = (string)Info["name"];
            else return -1;

            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("EXEC InsertGenre @GenreName = \'" + Name + "\'", myConnection);
                    cmd.ExecuteReader();
                    cmd = new SqlCommand("SELECT GenreID FROM Genre WHERE Name = \'" + Name + "\'", myConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    GenreID = int.Parse(reader.GetString(0));
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return GenreID;
        }

        public void Approve()
        {
            Approved = true;
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Genre SET Approved = 1 WHERE GenreID = " + GenreID, myConnection);
                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Decline()
        {
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Genre WHERE GenreID = " + GenreID, myConnection);
                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Name = "";
            GenreID = -1;
            Approved = false;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    class Band : Entity, IManage
    {
        int bandID;
        string offSite;
	    string fanSite;
	    string country;
        double liveRating; 
        List<int> genres;

        public int BandID
        {
            get
            {
                return bandID;
            }
            set
            {
                bandID = value;
            }
        }

        public string OffSite
        {
            get
            {
                return offSite;
            }
            set
            {
                offSite = value;
            }
        }

        public string FanSite
        {
            get
            {
                return fanSite;
            }
            set
            {
                fanSite = value;
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }

        public double LiveRating
        {
            get
            {
                return liveRating;
            }
            set
            {
                liveRating = value;
            }
        }

        public List<int> Genres
        {
            get
            {
                return genres;
            }
            set
            {
                genres = value;
            }
        }

        public Band()
        {
            BandID = -1;
            Name = "";
            Review = "";
            Approved = false;
            ImageURL = "";
            OffSite = "";
            FanSite = "";
            Country = "";
            Genres = null;
            Rating = 0;
            LiveRating = 0;

            Genres = new List<int>();
        }

        public Band(int BandID, string Name, string Review, bool Approved, string ImageURL, string OffSite, string FanSite, string Country, double Rating, double LiveRating)
        {
            this.BandID = BandID;
            this.Name = Name;
            this.Review = Review;
            this.Approved = Approved;
            this.ImageURL = ImageURL;
            this.OffSite = OffSite;
            this.FanSite = FanSite;
            this.Country = Country;
            this.Rating = Rating;
            this.LiveRating = LiveRating;

            Genres = new List<int>();

            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("SELECT GenreID FROM BandGenreMap WHERE BandID = " + BandID, myConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Genres.Add(reader.GetInt32(0));
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void UploadFromDB(int EntityID)
        {
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Name, Review, OffSite, FanSite, Country, ImageURL, Approved, Rating = dbo.GetBandRating(BandID), LiveRating = dbo.GetLiveRating(BandID) from Band WHERE BandID = " + EntityID, myConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    BandID = EntityID; 
                    
                    reader.Read();
                    
                    if (!reader.IsDBNull(0))
                        Name = reader.GetString(0);
                    if (!reader.IsDBNull(1)) 
                        Review = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                        OffSite = reader.GetString(2);
                    if (!reader.IsDBNull(3)) 
                        FanSite = reader.GetString(3);
                    if (!reader.IsDBNull(4)) 
                        Country = reader.GetString(4);
                    if (!reader.IsDBNull(5)) 
                        ImageURL = reader.GetString(5);
                    if (!reader.IsDBNull(6)) 
                        Approved = reader.GetBoolean(6);
                    if (!reader.IsDBNull(7))
                        Rating = reader.GetDouble(7);
                    if (!reader.IsDBNull(8))
                        LiveRating = reader.GetDouble(8);

                    reader.Close();

                    cmd = new SqlCommand("SELECT GenreID FROM BandGenreMap WHERE BandID = " + EntityID, myConnection);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Genres.Add(reader.GetInt32(0));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SaveToDB()
        {
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Band SET Name = \'" + Name +
                                                    "\', Review = \'" + Review +
                                                    "\', OffSite = \'" + OffSite +
                                                    "\', FanSite = \'" + FanSite +
                                                    "\', Country = \'" + Country +
                                                    "\', ImageURL = \'" + ImageURL +
                                                    "\', Approved = " + Approved + 
                                                    " WHERE BandID = " + BandID, myConnection);
                    cmd.ExecuteReader();
                    for (int i = 0; i < Genres.Count; i++)
                    {
                        cmd = new SqlCommand("INSERT INTO BandGenreMap (BandID, GenreID) VALUES (" + BandID + ", " + Genres[i] + ")", myConnection);
                        cmd.ExecuteReader();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int Suggest(Dictionary<string, object> Info)
        {
            if (Info.ContainsKey("name"))
                Name = (string)Info["name"];
            else return -1;

            if (Info.ContainsKey("country"))
                Country = (string)Info["country"];
            else return -1;

            if (Info.ContainsKey("review"))
                Review = (string)Info["review"];

            if (Info.ContainsKey("offsite"))
                OffSite = (string)Info["offsite"];

            if (Info.ContainsKey("fansite"))
                FanSite = (string)Info["fansite"];

            if (Info.ContainsKey("imageurl"))
                ImageURL = (string)Info["imageurl"];

            if (Info.ContainsKey("genres"))
                Genres = (List<int>)Info["genres"];

            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("EXEC InsertBand @BandName = \'" + Name + "\', @BandCountry = \'" + Country + "\'", myConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    cmd = new SqlCommand("SELECT BandID FROM Band WHERE Name = \'" + Name + "\'", myConnection);
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    BandID = reader.GetInt32(0);
                    reader.Close();
                    cmd = new SqlCommand("UPDATE Band SET Review = \'" + Review +
                                        "\', OffSite = \'" + OffSite +
                                        "\', FanSite = \'" + FanSite +
                                        "\', ImageURL = \'" + ImageURL + "\' WHERE BandID = \'" + BandID + "\'", myConnection);
                    reader = cmd.ExecuteReader();
                    reader.Close();
                    for (int i = 0; i < Genres.Count; i++)
                    {
                        cmd = new SqlCommand("INSERT INTO BandGenreMap (GenreID, BandID) VALUES (" + Genres[i] + ", " + BandID + ")", myConnection);
                        reader = cmd.ExecuteReader();
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return BandID;
        }

        public void Approve()
        {
            Approved = true;
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Band SET Approved = 1 WHERE BandID = " + BandID, myConnection);
                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Decline()
        {
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Band WHERE BandID = " + BandID, myConnection);
                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Name = "";
            BandID = -1;
            OffSite = "";
            FanSite = "";
            Country = "";
            Genres = null;
            ImageURL = "";
            Approved = false;
            Review = "";
        }
    }

    class Place : Entity, IManage
    {
        int placeID;
        string address;
	    string phone;
	    string offSite;
        string email;
        string handler;

        public int PlaceID
        {
            get
            {
                return placeID;
            }
            set
            {
                placeID = value;
            }
        }

        public string Address 
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }

        public string OffSite
        {
            get
            {
                return offSite;
            }
            set
            {
                offSite = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Handler
        {
            get
            {
                return handler;
            }
            set
            {
                handler = value;
            }
        }

        public Place()
        {
            PlaceID = -1;
            Name = "";
            Review = "";
            Approved = false;
            ImageURL = "";
            OffSite = "";
            Phone = "";
            Address = "";
            Email = "";
            Handler = "";
            Rating = 0;
        }

        public Place(int PlaceID, string Name, string Review, bool Approved, string ImageURL, string Address, string Phone, string OffSite, string Email, string Handler, double Rating)
        {
            this.PlaceID = PlaceID;
            this.Name = Name;
            this.Review = Review;
            this.Approved = Approved;
            this.ImageURL = ImageURL;
            this.Address = Address;
            this.Phone = Phone;
            this.OffSite = OffSite;
            this.Email = Email;
            this.Handler = Handler;
            this.Rating = Rating;
        }

        public void UploadFromDB(int EntityID)
        {
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Name, Review, OffSite, Address, Phone, Email, Handler, ImageURL, Approved, Rating = dbo.GetPlaceRating(PlaceID) from Place WHERE PlaceID = " + EntityID, myConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    PlaceID = EntityID; 
                    
                    reader.Read();

                    if (!reader.IsDBNull(0)) 
                        Name = reader.GetString(0);
                    if (!reader.IsDBNull(1)) 
                        Review = reader.GetString(1);
                    if (!reader.IsDBNull(2)) 
                        OffSite = reader.GetString(2);
                    if (!reader.IsDBNull(3)) 
                        Address = reader.GetString(3);
                    if (!reader.IsDBNull(4)) 
                        Phone = reader.GetString(4);
                    if (!reader.IsDBNull(5)) 
                        Email = reader.GetString(5);
                    if (!reader.IsDBNull(6)) 
                        Handler = reader.GetString(6);
                    if (!reader.IsDBNull(7)) 
                        ImageURL = reader.GetString(7);
                    if (!reader.IsDBNull(8)) 
                        Approved = reader.GetBoolean(8);
                    if (!reader.IsDBNull(9))
                        Rating = reader.GetDouble(9);

                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SaveToDB()
        {
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Place SET Name = \'" + Name +
                                                    "\', Review = \'" + Review +
                                                    "\', OffSite = \'" + OffSite +
                                                    "\', Address = \'" + Address +
                                                    "\', Phone = \'" + Phone +
                                                    "\', Email = \'" + Email +
                                                    "\', Handler = \'" + Handler +
                                                    "\', ImageURL = \'" + ImageURL +
                                                    "\', Approved = " + Approved + 
                                                    " WHERE BandID = " + PlaceID, myConnection);
                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int Suggest(Dictionary<string, object> Info)
        {
            if (Info.ContainsKey("name"))
                Name = (string)Info["name"];
            else return -1;

            if (Info.ContainsKey("review"))
                Review = (string)Info["review"];

            if (Info.ContainsKey("offsite"))
                OffSite = (string)Info["offsite"];

            if (Info.ContainsKey("address"))
                Address = (string)Info["address"];

            if (Info.ContainsKey("phone"))
                Phone = (string)Info["phone"];

            if (Info.ContainsKey("email"))
                Email = (string)Info["email"];

            if (Info.ContainsKey("handler"))
                Handler = (string)Info["handler"];

            if (Info.ContainsKey("imageurl"))
                ImageURL = (string)Info["imageurl"];

            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("EXEC InsertPlace @PlaceName = \'" + Name + "\'", myConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    cmd = new SqlCommand("SELECT PlaceID FROM Place WHERE Name = \'" + Name + "\'", myConnection);
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    PlaceID = reader.GetInt32(0);
                    reader.Close();
                    cmd = new SqlCommand("UPDATE Place SET Review = \'" + Review +
                                        "\', OffSite = \'" + OffSite +
                                        "\', Address = \'" + Address +
                                        "\', Phone = \'" + Phone +
                                        "\', Email = \'" + Email +
                                        "\', Handler = \'" + Handler +
                                        "\', ImageURL = \'" + ImageURL + "\'", myConnection);
                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return PlaceID;
        }

        public void Approve()
        {
            Approved = true;
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Place SET Approved = 1 WHERE PlaceID = " + PlaceID, myConnection);
                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Decline()
        {
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Place WHERE PlaceID = " + PlaceID, myConnection);
                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Name = "";
            PlaceID = -1;
            OffSite = "";
            Address = "";
            Phone = "";
            Handler = "";
            Email = "";
            ImageURL = "";
            Approved = false;
            Review = "";
        }
    }

    class Concert : Entity, IManage
    {
        int concertID;
        int placeID;
        DateTime date;
        int censor;
        List<int> bands;

        public int ConcertID
        {
            get
            {
                return concertID;
            }
            set
            {
                concertID = value;
            }
        }

        public int PlaceID
        {
            get
            {
                return placeID;
            }
            set
            {
                placeID = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        public int Censor
        {
            get
            {
                return censor;
            }
            set
            {
                censor = value;
            }
        }

        public List<int> Bands
        {
            get
            {
                return bands;
            }
            set {
                bands = value;
            }
        }

        public Concert()
        {
            ConcertID = -1;
            Name = "";
            Review = "";
            Approved = false;
            ImageURL = "";
            Date = DateTime.MinValue;
            Censor = 0;
            PlaceID = -1;
            Bands = null;
            Rating = 0;

            this.Bands = new List<int>();
        }

        public Concert(int ConcertID, string Name, string Review, bool Approved, string ImageURL, int PlaceID, DateTime Date, int Censor, double Rating)
        {
            this.ConcertID = ConcertID;
            this.Name = Name;
            this.Review = Review;
            this.Approved = Approved;
            this.ImageURL = ImageURL;
            this.Date = Date;
            this.Censor = Censor;
            this.Rating = Rating;
            this.PlaceID = PlaceID;

            this.Bands = new List<int>();

            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("SELECT BandID FROM BandConcertMap WHERE ConcertID = " + ConcertID, myConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Bands.Add(reader.GetInt32(0));
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void UploadFromDB(int EntityID)
        {
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Name, Review, Date, Censor, PlaceID, ImageURL, Approved, Rating = dbo.GetConcertRating(ConcertID) from Concert WHERE ConcertID = " + EntityID, myConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    ConcertID = EntityID; 
                    
                    reader.Read();
                    
                    if (!reader.IsDBNull(0))
                        Name = reader.GetString(0);
                    if (!reader.IsDBNull(1)) 
                        Review = reader.GetString(1);
                    if (!reader.IsDBNull(2)) 
                        Date = reader.GetDateTime(2);
                    if (!reader.IsDBNull(3)) 
                        Censor = reader.GetInt32(3);
                    if (!reader.IsDBNull(4))
                        PlaceID = reader.GetInt32(4);
                    if (!reader.IsDBNull(5)) 
                        ImageURL = reader.GetString(5);
                    if (!reader.IsDBNull(6)) 
                        Approved = reader.GetBoolean(6);
                    if (!reader.IsDBNull(7))
                        Rating = reader.GetDouble(7);

                    reader.Close();

                    cmd = new SqlCommand("SELECT BandID FROM BandConcertMap WHERE ConcertID = " + EntityID, myConnection);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Bands.Add(reader.GetInt32(0));
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SaveToDB()
        {
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Band SET Name = \'" + Name +
                                                    "\', Review = \'" + Review +
                                                    "\', Date = \'" + Date.ToString("yyyy-MM-dd HH:mm") +
                                                    "\', Censor = " + Censor +
                                                    ", PlaceID = " + PlaceID +
                                                    ", ImageURL = \'" + ImageURL +
                                                    "\', Approved = " + Approved +
                                                    " WHERE ConcertID = " + ConcertID, myConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    for (int i = 0; i < Bands.Count; i++)
                    {
                        cmd = new SqlCommand("INSERT INTO BandConcertMap (ConcertID, BandID) VALUES (" + ConcertID + ", " + Bands[i] + ")", myConnection);
                        reader = cmd.ExecuteReader();
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int Suggest(Dictionary<string, object> Info)
        {
            if (Info.ContainsKey("name"))
                Name = (string)Info["name"];
            else return -1;

            if (Info.ContainsKey("date"))
                Date = (DateTime)Info["date"];
            else return -1;

            if (Info.ContainsKey("placeid"))
                PlaceID = (int)Info["placeid"];
            else return -1;

            if (Info.ContainsKey("review"))
                Review = (string)Info["review"];

            if (Info.ContainsKey("censor"))
                Censor = (int)Info["censor"];

            if (Info.ContainsKey("imageurl"))
                ImageURL = (string)Info["imageurl"];

            if (Info.ContainsKey("bands"))
                Bands = (List<int>)Info["bands"];

            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("EXEC InsertConcert @ConcertName = \'" + Name + "\', @PlaceID = " + PlaceID + ", @Date = \'" + Date.ToString("yyyy-MM-dd HH:mm") + "\'", myConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    cmd = new SqlCommand("SELECT ConcertID FROM Concert WHERE Name = \'" + Name + "\'", myConnection);
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    ConcertID = reader.GetInt32(0);
                    reader.Close();
                    cmd = new SqlCommand("UPDATE Concert SET Review = \'" + Review +
                                        "\', Censor = " + Censor +
                                        ", ImageURL = \'" + ImageURL + "\' WHERE ConcertID = " + ConcertID, myConnection);
                    reader = cmd.ExecuteReader();
                    reader.Close();
                    for (int i = 0; i < Bands.Count; i++)
                    {
                        cmd = new SqlCommand("INSERT INTO BandConcertMap (BandID, ConcertID) VALUES (" + Bands[i] + ", " + ConcertID + ")", myConnection);
                        reader = cmd.ExecuteReader();
                        reader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ConcertID;
        }

        public void Approve()
        {
            Approved = true;
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Concert SET Approved = 1 WHERE ConcertID = " + ConcertID, myConnection);
                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Decline()
        {
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Concert WHERE ConcertID = " + ConcertID, myConnection);
                    cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Name = "";
            ConcertID = -1;
            PlaceID = -1;
            Date = DateTime.MinValue;
            Censor = -1;
            Bands = null;
            ImageURL = "";
            Approved = false;
            Review = "";
        }
    }
}
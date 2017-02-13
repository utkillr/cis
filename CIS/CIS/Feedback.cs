using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS
{
    class Feedback
    {
        protected string name;
        protected string email;
        protected string comment;
        protected int vote;

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

        public string Comment
        {
            get
            {
                return comment;
            }
            set {
                comment = value;
            }
        }

        public int Vote
        {
            get
            {
                return vote;
            }
            set {
                vote = value;
            }
        }
    }

    class BandFeedback : Feedback, IFeedback
    {
        int bandID;

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

        public BandFeedback(string Name, string Email, string Comment, int Vote, int BandID)
        {
            this.Name = Name;
            this.Email = Email;
            this.Comment = Comment;
            this.Vote = Vote;
            this.BandID = BandID;
        }

        public void Send()
        {
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();

                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("EXEC InsertBandFeedback" +
                                                    " @BandID = \'" + BandID +
                                                    "\' @Email = \'" + Email +
                                                    "\' @Name = \'" + Name +
                                                    "\' @Comment = \'" + Comment +
                                                    "\' @Vote = " + Vote, myConnection);

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    class ConcertFeedback : Feedback, IFeedback
    {
        int concertID;

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

        public ConcertFeedback(string Name, string Email, string Comment, int Vote, int ConcertID)
        {
            this.Name = Name;
            this.Email = Email;
            this.Comment = Comment;
            this.Vote = Vote;
            this.ConcertID = ConcertID;
        }

        public void Send()
        {
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();

                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("EXEC InsertConcertFeedback" +
                                                    " @ConcertID = \'" + ConcertID +
                                                    "\' @Email = \'" + Email +
                                                    "\' @Name = \'" + Name +
                                                    "\' @Comment = \'" + Comment +
                                                    "\' @Vote = " + Vote, myConnection);

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    class PlaceFeedback : Feedback, IFeedback
    {
        int placeID;

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

        public PlaceFeedback(string Name, string Email, string Comment, int Vote, int PlaceID)
        {
            this.Name = Name;
            this.Email = Email;
            this.Comment = Comment;
            this.Vote = Vote;
            this.PlaceID = PlaceID;
        }

        public void Send()
        {
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
            try
            {
                myConnection.Open();

                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("EXEC InsertPlaceFeedback" +
                                                    " @PlaceID = \'" + PlaceID +
                                                    "\' @Email = \'" + Email +
                                                    "\' @Name = \'" + Name +
                                                    "\' @Comment = \'" + Comment +
                                                    "\' @Vote = " + Vote, myConnection);

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

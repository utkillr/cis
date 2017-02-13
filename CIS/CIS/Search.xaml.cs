using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CIS
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window 
    {
        SuggestedVisualizer SV = new SuggestedVisualizer();
        ObservableCollection<Concert> C;
        ObservableCollection<Band> B;
        ObservableCollection<Place> P;

        SqlConnection myConnection;

        public Search(string Sub)
        {
            DataContext = this;

            InitializeComponent();

            myConnection = new SqlConnection(ConstClass.SqlCon);
            P = new ObservableCollection<Place>();
            B = new ObservableCollection<Band>();
            C = new ObservableCollection<Concert>();

            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    LoadSearchBands(Sub);
                    LoadSearchPlaces(Sub);
                    LoadSearchConcerts(Sub);
                }
                myConnection.Close();

                for (int i = 0; i < P.Count; i++)
                {
                    SV.News.Add(P[i]);
                }
                for (int i = 0; i < B.Count; i++)
                {
                    SV.News.Add(B[i]);
                }
                for (int i = 0; i < C.Count; i++)
                {
                    SV.News.Add(C[i]);
                }

                ObservableCollection<Entity> E = new ObservableCollection<Entity>();

                Random r = new Random();
                int randomIndex = 0;
                while (SV.News.Count > 0)
                {
                    randomIndex = r.Next(0, SV.News.Count);
                    E.Add(SV.News[randomIndex]);
                    SV.News.RemoveAt(randomIndex);
                }

                SV.News = E;

                NewsList.DataContext = SV;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void LoadSearchBands(string Sub)
        {
            SqlCommand cmd = new SqlCommand("SELECT BandID, Name, Review, OffSite, FanSite, Country, ImageURL, dbo.GetBandRating(BandID) AS Rating, dbo.GetLiveRating(BandID) AS LiveRating FROM Band WHERE Approved = 1", myConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string Name = "", Review = "", ImageURL = "", OffSite = "", FanSite = "", Country = "";
                int BandID = -1;
                double Rating = 0, LiveRating = 0;
                if (!reader.IsDBNull(0))
                    BandID = reader.GetInt32(0);
                if (!reader.IsDBNull(1))
                    Name = reader.GetString(1);
                if (!reader.IsDBNull(2))
                    Review = reader.GetString(2);
                if (!reader.IsDBNull(3))
                    OffSite = reader.GetString(3);
                if (!reader.IsDBNull(4))
                    FanSite = reader.GetString(4);
                if (!reader.IsDBNull(5))
                    Country = reader.GetString(5);
                if (!reader.IsDBNull(6))
                    ImageURL = reader.GetString(6);
                if (!reader.IsDBNull(7))
                    Rating = reader.GetDouble(7);
                if (!reader.IsDBNull(8))
                    LiveRating = reader.GetDouble(8);


                if (Name.Contains(Sub))
                {
                    Band band = new Band(BandID, Name, Review, true, ImageURL, OffSite, FanSite, Country, Rating, LiveRating);
                    B.Add(band);
                }
            }
            reader.Close();
        }

        void LoadSearchPlaces(string Sub)
        {
            SqlCommand cmd = new SqlCommand("SELECT PlaceID, Name, Review, OffSite, Address, Phone, Email, Handler, ImageURL, dbo.GetPlaceRating(PlaceID) AS Rating FROM Place WHERE Approved = 1", myConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string Name = "", Review = "", ImageURL = "", OffSite = "", Address = "", Email = "", Handler="", Phone="";
                int PlaceID = -1;
                double Rating = 0;
                if (!reader.IsDBNull(0))
                    PlaceID = reader.GetInt32(0);
                if (!reader.IsDBNull(1))
                    Name = reader.GetString(1);
                if (!reader.IsDBNull(2))
                    Review = reader.GetString(2);
                if (!reader.IsDBNull(3))
                    OffSite = reader.GetString(3);
                if (!reader.IsDBNull(4))
                    Address = reader.GetString(4);
                if (!reader.IsDBNull(5))
                    Phone = reader.GetString(5);
                if (!reader.IsDBNull(6))
                    Email = reader.GetString(6);
                if (!reader.IsDBNull(7))
                    Handler = reader.GetString(7);
                if (!reader.IsDBNull(8))
                    ImageURL = reader.GetString(8);
                if (!reader.IsDBNull(9))
                    Rating = reader.GetDouble(9);

                if (Name.Contains(Sub))
                {
                    Place place = new Place(PlaceID, Name, Review, true, ImageURL, Address, Phone, OffSite, Email, Handler, Rating);
                    P.Add(place);
                }
            }
            reader.Close();
        }

        void LoadSearchConcerts(string Sub)
        {
            SqlCommand cmd = new SqlCommand("SELECT ConcertID, Name, Review, Date, Censor, PlaceID, ImageURL, dbo.GetConcertRating(ConcertID) FROM Concert WHERE Approved = 1", myConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string Name = "", Review = "", ImageURL = "";
                int ConcertID = -1, PlaceID = -1, Censor = 0;
                double Rating = 0;
                DateTime Date = DateTime.MinValue;
                if (!reader.IsDBNull(0))
                    ConcertID = reader.GetInt32(0);
                if (!reader.IsDBNull(1))
                    Name = reader.GetString(1);
                if (!reader.IsDBNull(2))
                    Review = reader.GetString(2);
                if (!reader.IsDBNull(3))
                    Date = reader.GetDateTime(3);
                if (!reader.IsDBNull(4))
                    Censor = reader.GetInt32(4);
                if (!reader.IsDBNull(5))
                    PlaceID = reader.GetInt32(5);
                if (!reader.IsDBNull(6))
                    ImageURL = reader.GetString(6);
                if (!reader.IsDBNull(7))
                    Rating = reader.GetDouble(7);

                if (Name.Contains(Sub))
                {
                    Concert concert = new Concert(ConcertID, Name, Review, true, ImageURL, PlaceID, Date, Censor, Rating);
                    C.Add(concert);
                }
            }
            reader.Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wndw = new MainWindow();
            wndw.Show();
            this.Close();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            string Sub = SearchBox.Text;

            myConnection = new SqlConnection(ConstClass.SqlCon);
            P = new ObservableCollection<Place>();
            B = new ObservableCollection<Band>();
            C = new ObservableCollection<Concert>();

            SV = new SuggestedVisualizer();

            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    LoadSearchBands(Sub);
                    LoadSearchPlaces(Sub);
                    LoadSearchConcerts(Sub);
                }
                myConnection.Close();

                for (int i = 0; i < P.Count; i++)
                {
                    SV.News.Add(P[i]);
                }
                for (int i = 0; i < B.Count; i++)
                {
                    SV.News.Add(B[i]);
                }
                for (int i = 0; i < C.Count; i++)
                {
                    SV.News.Add(C[i]);
                }

                ObservableCollection<Entity> E = new ObservableCollection<Entity>();

                Random r = new Random();
                int randomIndex = 0;
                while (SV.News.Count > 0)
                {
                    randomIndex = r.Next(0, SV.News.Count);
                    E.Add(SV.News[randomIndex]);
                    SV.News.RemoveAt(randomIndex);
                }

                SV.News = E;

                NewsList.DataContext = SV;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private void Concert_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Control control = sender as Control;
            Concert concert = control.DataContext as Concert;

            ConcertView wndw = new ConcertView(concert.ConcertID);
            wndw.Show();
        }

        private void Band_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Control control = sender as Control;
            Band band = control.DataContext as Band;

            BandView wndw = new BandView(band.BandID);
            wndw.Show();
        }

        private void Place_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Control control = sender as Control;
            Place place = control.DataContext as Place;

            PlaceView wndw = new PlaceView(place.PlaceID);
            wndw.Show();
        }
    }
}

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
    /// Interaction logic for News.xaml
    /// </summary>
    public partial class News : Window
    {
        SuggestedVisualizer SV = new SuggestedVisualizer();
        ObservableCollection<Concert> C;
        ObservableCollection<Band> B;
        ObservableCollection<Place> P;
        ObservableCollection<Genre> G;

        SqlConnection myConnection;

        public News()
        {
            DataContext = this;

            InitializeComponent();

            myConnection = new SqlConnection(ConstClass.SqlCon);
            P = new ObservableCollection<Place>();
            B = new ObservableCollection<Band>();
            C = new ObservableCollection<Concert>();
            G = new ObservableCollection<Genre>();

            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    LoadSuggestedGenres();
                    LoadSuggestedBands();
                    LoadSuggestedPlaces();
                    LoadSuggestedConcerts();
                }
                myConnection.Close();

                for (int i = 0; i < G.Count; i++)
                {
                    SV.News.Add(G[i]);
                }
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

                NewsList.DataContext = SV;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void LoadSuggestedGenres()
        {
            SqlCommand cmd = new SqlCommand("SELECT GenreID, Name FROM Genre WHERE Approved = 0", myConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int GenreID = -1;
                string Name = "";
                if (!reader.IsDBNull(0))
                    GenreID = reader.GetInt32(0);
                if (!reader.IsDBNull(1))
                    Name = reader.GetString(1);

                Genre genre = new Genre(GenreID, Name);
                G.Add(genre);
            }
            reader.Close();
        }

        void LoadSuggestedBands()
        {
            SqlCommand cmd = new SqlCommand("SELECT BandID, Name, Review, OffSite, FanSite, Country, ImageURL FROM Band WHERE Approved = 0", myConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string Name = "", Review = "", ImageURL = "", OffSite = "", FanSite = "", Country = "";
                int BandID = -1;
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
                
                Band band = new Band(BandID, Name, Review, false, ImageURL, OffSite, FanSite, Country, 0, 0);
                B.Add(band);
            }
            reader.Close();
        }

        void LoadSuggestedPlaces()
        {
            SqlCommand cmd = new SqlCommand("SELECT PlaceID, Name, Review, OffSite, Address, Phone, Email, Handler, ImageURL FROM Place WHERE Approved = 0", myConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string Name = "", Review = "", ImageURL = "", OffSite = "", Address = "", Email = "", Handler="", Phone="";
                int PlaceID = -1;
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

                Place place = new Place(PlaceID, Name, Review, false, ImageURL, Address, Phone, OffSite, Email, Handler, 0);
                P.Add(place);
            }
            reader.Close();
        }

        void LoadSuggestedConcerts()
        {
            SqlCommand cmd = new SqlCommand("SELECT ConcertID, Name, Review, Date, Censor, PlaceID, ImageURL FROM Concert WHERE Approved = 0", myConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string Name = "", Review = "", ImageURL = "";
                int ConcertID = -1, PlaceID = -1, Censor = 0;
                DateTime Date = DateTime.MinValue;
                if (!reader.IsDBNull(0))
                    PlaceID = reader.GetInt32(0);
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

                Concert concert = new Concert(ConcertID, Name, Review, false, ImageURL, PlaceID, Date, Censor, 0);
                C.Add(concert);
            }
            reader.Close();
        }

       private void ApproveBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Entity entity = btn.DataContext as Entity;
            if (entity.GetType() == typeof(Genre))
            {
                Genre genre = entity as Genre;
                genre.Approve();
            }
            else if (entity.GetType() == typeof(Place))
            {
                Place place = entity as Place;
                place.Approve();
            }
            else if (entity.GetType() == typeof(Band))
            {
                Band band = entity as Band;
                band.Approve();
            }
            else if (entity.GetType() == typeof(Concert))
            {
                Concert concert = entity as Concert;
                concert.Approve();
            }
            SV.News.Remove(entity);
        }

        private void DeclineBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Entity entity = btn.DataContext as Entity;
            if (entity.GetType() == typeof(Genre))
            {
                Genre genre = entity as Genre;
                genre.Decline();
            }
            else if (entity.GetType() == typeof(Place))
            {
                Place place = entity as Place;
                place.Decline();
            }
            else if (entity.GetType() == typeof(Band))
            {
                Band band = entity as Band;
                band.Decline();
            }
            else if (entity.GetType() == typeof(Concert))
            {
                Concert concert = entity as Concert;
                concert.Decline();
            }
            SV.News.Remove(entity);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wndw = new MainWindow();
            wndw.Show();
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace CIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainVisualizer MV = new MainVisualizer();
        ObservableCollection<Concert> UC, C;
        ObservableCollection<Band> B;

        SqlConnection myConnection;

        public MainWindow()
        {
            this.Topmost = false;

            DataContext = this;

            InitializeComponent();

            myConnection = new SqlConnection(ConstClass.SqlCon);
            UC = new ObservableCollection<Concert>();
            B = new ObservableCollection<Band>();
            C = new ObservableCollection<Concert>();

            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    LoadUpcomingConcerts();
                    LoadBands();
                    LoadConcerts();
                }
                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void LoadUpcomingConcerts()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.GetNUpcomingConcerts(5, \'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "\')", myConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string Name = "", Review = "", ImageURL = "";
                DateTime Date = DateTime.MinValue;
                int ConcertID = -1, PlaceID = -1, Censor = -1;
                double Rating = 0;
                bool Approved = false;
                if (!reader.IsDBNull(0))
                    Name = reader.GetString(0);
                if (!reader.IsDBNull(1))
                    PlaceID = reader.GetInt32(1);
                if (!reader.IsDBNull(2))
                    Date = reader.GetDateTime(2);
                if (!reader.IsDBNull(3))
                    Censor = reader.GetInt32(3);
                if (!reader.IsDBNull(4))
                    Review = reader.GetString(4);
                if (!reader.IsDBNull(5))
                    ImageURL = reader.GetString(5);
                if (!reader.IsDBNull(6))
                    ConcertID = reader.GetInt32(6);
                if (!reader.IsDBNull(7))
                    Approved = reader.GetBoolean(7);
                if (!reader.IsDBNull(8))
                    Rating = reader.GetDouble(8);
                if (Approved)
                {
                    Concert concert = new Concert(ConcertID, Name, Review, Approved, ImageURL, PlaceID, Date, Censor, Rating);
                    UC.Add(concert);
                }
            }
            reader.Close();

            MV.UpcomingConcerts = UC;

            UpcomingConcertsList.DataContext = MV;
        }

        void LoadBands()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.GetNBands(5, 1)", myConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string Name = "", Review = "", ImageURL = "", OffSite = "", FanSite = "", Country = "";
                int BandID = -1;
                bool Approved = false;
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
                    Approved = reader.GetBoolean(7);
                if (!reader.IsDBNull(8))
                    Rating = reader.GetDouble(8);
                if (!reader.IsDBNull(9))
                    LiveRating = reader.GetDouble(9);
                if (Approved)
                {
                    Band band = new Band(BandID, Name, Review, Approved, ImageURL, OffSite, FanSite, Country, Rating, LiveRating);
                    B.Add(band);
                }
            }
            reader.Close();

            MV.Bands = B;

            BandsList.DataContext = MV;
        }

        void LoadConcerts()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.GetNConcerts(5, 1)", myConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string Name = "", Review = "", ImageURL = "";
                DateTime Date = DateTime.MinValue;
                int ConcertID = -1, PlaceID = -1, Censor = -1;
                double Rating = 0;
                bool Approved = false;
                if (!reader.IsDBNull(0))
                    Name = reader.GetString(0);
                if (!reader.IsDBNull(1))
                    PlaceID = reader.GetInt32(1);
                if (!reader.IsDBNull(2))
                    Date = reader.GetDateTime(2);
                if (!reader.IsDBNull(3))
                    Censor = reader.GetInt32(3);
                if (!reader.IsDBNull(4))
                    Review = reader.GetString(4);
                if (!reader.IsDBNull(5))
                    ImageURL = reader.GetString(5);
                if (!reader.IsDBNull(6))
                    ConcertID = reader.GetInt32(6);
                if (!reader.IsDBNull(7))
                    Approved = reader.GetBoolean(7);
                if (!reader.IsDBNull(8))
                    Rating = reader.GetDouble(8);
                if (Approved)
                {
                    Concert concert = new Concert(ConcertID, Name, Review, Approved, ImageURL, PlaceID, Date, Censor, Rating);
                    C.Add(concert);
                }
            }
            reader.Close();

            MV.Concerts = C;

            ConcertsList.DataContext = MV;
        }

        private void GenreButton_Click(object sender, RoutedEventArgs e)
        {
            SuggestGenre wndw = new SuggestGenre();
            wndw.Show();
            this.Close();
        }

        private void BandButton_Click(object sender, RoutedEventArgs e)
        {
            SuggestBand wndw = new SuggestBand();
            wndw.Show();
            this.Close();
        }

        private void PlaceButton_Click(object sender, RoutedEventArgs e)
        {
            SuggestPlace wndw = new SuggestPlace();
            wndw.Show();
            this.Close();
        }

        private void ConcertButton_Click(object sender, RoutedEventArgs e)
        {
            SuggestConcert wndw = new SuggestConcert();
            wndw.Show();
            this.Close();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Login wndw = new Login();
            wndw.Show();
            this.Close();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            Register wndw = new Register();
            wndw.Show();
            this.Close();
        }

        private void UpcomingConcert_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Control control = sender as Control;
            Concert concert = control.DataContext as Concert;

            ConcertView wndw = new ConcertView(concert.ConcertID);
            wndw.Show();
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

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            Search wndw = new Search(SearchBox.Text);
            wndw.Show();
            this.Close();
        }
    }
}

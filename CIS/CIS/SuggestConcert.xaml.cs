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
using System.Windows.Shapes;

using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace CIS
{
    /// <summary>
    /// Interaction logic for SuggestConcert.xaml
    /// </summary>
    public partial class SuggestConcert : Window
    {
        BandsVisualizer BV = new BandsVisualizer();
        PlacesVisualizer PV = new PlacesVisualizer();

        SqlConnection myConnection;

        public SuggestConcert()
        {
            InitializeComponent();

            BV.NotSelectedBands = new ObservableCollection<Band>();
            BV.SelectedBands = new ObservableCollection<Band>();
            PV.Places = new ObservableCollection<Place>();

            myConnection = new SqlConnection(ConstClass.SqlCon);

            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.ApprovedBandIDs", myConnection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Band band = new Band();
                        band.UploadFromDB(reader.GetInt32(0));
                        BV.NotSelectedBands.Add(band);
                    }

                    reader.Close();

                    cmd = new SqlCommand("SELECT * FROM dbo.ApprovedPlaceIDs", myConnection);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Place place = new Place();
                        place.UploadFromDB(reader.GetInt32(0));
                        PV.Places.Add(place);
                    }

                    AllBandsList.DataContext = BV;
                    Place.DataContext = PV;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void SuggestConcertBtn_Click(object sender, RoutedEventArgs e)
        {
            Concert concert = new Concert();
            Dictionary<string, object> info = new Dictionary<string, object>();
            info.Add("name", ConcertName.Text);
            info.Add("review", ConcertReview.Text);
            info.Add("imageurl", ConcertImageURL.Text);
            info.Add("censor", int.Parse(ConcertCensor.Text));
            if (Place.SelectedIndex != -1)
                info.Add("placeid", (Place.SelectedItem as Place).PlaceID);

            DateTime Date = new DateTime();
            Date = (DateTime)ConcertDate.SelectedDate;
            
            if (int.Parse(ConcertHours.Text) < 24 && int.Parse(ConcertHours.Text) > -1 && int.Parse(ConcertMinutes.Text) < 60 && int.Parse(ConcertMinutes.Text) > -1)
                Date = new DateTime(Date.Year, Date.Month, Date.Day, int.Parse(ConcertHours.Text), int.Parse(ConcertMinutes.Text), 0);

            info.Add("date", Date);

            List<int> bands = new List<int>();
            for (int i = 0; i < BV.SelectedBands.Count; i++)
            {
                bands.Add(BV.SelectedBands[i].BandID);
            }

            info.Add("bands", bands);

            concert.Suggest(info);

            MainWindow wndw = new MainWindow();
            wndw.Show();
            this.Close();
        }

        private void ImageURL_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                ConcertImage.Source = new BitmapImage(new Uri(ConcertImageURL.Text));
            }
            catch (Exception err) {
                Console.WriteLine(err.Message);
            }
        }

        private void AllBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == -1) return;
            for (int i = 0; i < BV.NotSelectedBands.Count; i++)
            {
                if (BV.NotSelectedBands[i].BandID == ((sender as ComboBox).SelectedItem as Band).BandID)
                {
                    BV.SelectedBands.Add(BV.NotSelectedBands[i]);
                    (sender as ComboBox).SelectedIndex = -1;
                    BV.NotSelectedBands.RemoveAt(i);
                    i = BV.NotSelectedBands.Count;
                }
            }

            AllBandsList.DataContext = BV;
            ChosenBandsList.DataContext = BV;
        }

        private void SelectedBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedIndex == -1) return;
            for (int i = 0; i < BV.SelectedBands.Count; i++)
            {
                if (BV.SelectedBands[i].BandID == ((sender as ListBox).SelectedItem as Band).BandID)
                {
                    BV.NotSelectedBands.Add(BV.SelectedBands[i]);
                    (sender as ListBox).SelectedIndex = -1;
                    BV.SelectedBands.RemoveAt(i);
                    i = BV.SelectedBands.Count;
                }
            }

            AllBandsList.DataContext = BV;
            ChosenBandsList.DataContext = BV;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wndw = new MainWindow();
            wndw.Show();
            this.Close();
        }
    }
}

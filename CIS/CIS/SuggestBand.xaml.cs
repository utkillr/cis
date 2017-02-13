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
    /// Interaction logic for SuggestBand.xaml
    /// </summary>
    public partial class SuggestBand : Window
    {
        GenresVisualizer GV = new GenresVisualizer();

        SqlConnection myConnection;

        public SuggestBand()
        {
            InitializeComponent();

            GV.NotSelectedGenres = new ObservableCollection<Genre>();
            GV.SelectedGenres = new ObservableCollection<Genre>();

            myConnection = new SqlConnection(ConstClass.SqlCon);

            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.ApprovedGenreIDs", myConnection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Genre genre = new Genre();
                        genre.UploadFromDB(reader.GetInt32(0));
                        GV.NotSelectedGenres.Add(genre);
                    }

                    AllGenresList.DataContext = GV;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void SuggestBandBtn_Click(object sender, RoutedEventArgs e)
        {
            Band band = new Band();
            Dictionary<string, object> info = new Dictionary<string, object>();
            info.Add("name", BandName.Text);
            info.Add("country", BandCountry.Text);
            info.Add("review", BandReview.Text);
            info.Add("offsite", BandOffSite.Text);
            info.Add("fansite", BandFanSite.Text);
            info.Add("imageurl", BandImageURL.Text);

            List<int> genres = new List<int>();
            for (int i = 0; i < GV.SelectedGenres.Count; i++)
            {
                genres.Add(GV.SelectedGenres[i].GenreID);
            }

            info.Add("genres", genres);

            band.Suggest(info);

            MainWindow wndw = new MainWindow();
            wndw.Show();
            this.Close();
        }

        private void ImageURL_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                BandImage.Source = new BitmapImage(new Uri(BandImageURL.Text));
            }
            catch (Exception err) {
                Console.WriteLine(err.Message);
            }
        }

        private void AllGenres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == -1) return;
            for (int i = 0; i < GV.NotSelectedGenres.Count; i++)
            {
                if (GV.NotSelectedGenres[i].GenreID == ((sender as ComboBox).SelectedItem as Genre).GenreID)
                {
                    GV.SelectedGenres.Add(GV.NotSelectedGenres[i]);
                    (sender as ComboBox).SelectedIndex = -1;
                    GV.NotSelectedGenres.RemoveAt(i);
                    i = GV.NotSelectedGenres.Count;
                }
            }

            AllGenresList.DataContext = GV;
            ChosenGenresList.DataContext = GV;
        }

        private void SelectedGenres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedIndex == -1) return;
            for (int i = 0; i < GV.SelectedGenres.Count; i++)
            {
                if (GV.SelectedGenres[i].GenreID == ((sender as ListBox).SelectedItem as Genre).GenreID)
                {
                    GV.NotSelectedGenres.Add(GV.SelectedGenres[i]);
                    (sender as ListBox).SelectedIndex = -1;
                    GV.SelectedGenres.RemoveAt(i);
                    i = GV.SelectedGenres.Count;
                }
            }

            AllGenresList.DataContext = GV;
            ChosenGenresList.DataContext = GV;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wndw = new MainWindow();
            wndw.Show();
            this.Close();
        }
    }
}

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

namespace CIS
{
    /// <summary>
    /// Interaction logic for SuggestPlace.xaml
    /// </summary>
    public partial class SuggestPlace : Window
    {
        SqlConnection myConnection;

        public SuggestPlace()
        {
            InitializeComponent();
        }

        private void SuggestPlaceBtn_Click(object sender, RoutedEventArgs e)
        {
            Place place = new Place();
            Dictionary<string, object> info = new Dictionary<string, object>();
            info.Add("name", PlaceName.Text);
            info.Add("address", PlaceAddress.Text);
            info.Add("email", PlaceEmail.Text);
            info.Add("handler", PlaceHandler.Text);
            info.Add("imageurl", PlaceImageURL.Text);
            info.Add("offsite", PlaceOffSite.Text);
            info.Add("phone", PlacePhone.Text);
            info.Add("review", PlaceReview.Text);
            
            place.Suggest(info);

            MainWindow wndw = new MainWindow();
            wndw.Show();
            this.Close();
        }

        private void ImageURL_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                PlaceImage.Source = new BitmapImage(new Uri(PlaceImageURL.Text));
            }
            catch (Exception err) {
                Console.WriteLine(err.Message);
            }
        }
        
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wndw = new MainWindow();
            wndw.Show();
            this.Close();
        }
    }
}

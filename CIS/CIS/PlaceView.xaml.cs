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
    /// Interaction logic for ConcertView.xaml
    /// </summary>
    public partial class PlaceView : Window
    {
        FeedbackVisualizer FV = new FeedbackVisualizer();
        ObservableCollection<PlaceFeedback> PF;

        public PlaceView(int PlaceID)
        {
            this.Top = 0;

            InitializeComponent();

            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);

            PF = new ObservableCollection<PlaceFeedback>();

            Place place = new Place();
            place.UploadFromDB(PlaceID);

            PlaceNameBox.Text = place.Name;
            PlaceRatingBox.Text = place.Rating.ToString("0.00");
            PlaceAddressBox.Text = place.Address;
            PlaceEmailBox.Text = place.Email;
            PlaceHandlerBox.Text = place.Handler;
            PlacePhoneBox.Text = place.Phone;
            PlaceOffSiteBox.Text = place.OffSite;
            PlaceReviewBox.Text = place.Review;

            try
            {
                PlaceImage.Source = new BitmapImage(new Uri(place.ImageURL));
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

            try
            {
                myConnection.Open();
                using (myConnection)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Name, Email, Comment, Vote FROM PlaceFeedback WHERE PlaceID = " + PlaceID, myConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string Name = "", Email = "", Comment = "";
                        int Vote = -1;

                        if (!reader.IsDBNull(0))
                            Name = reader.GetString(0);
                        if (!reader.IsDBNull(1))
                            Email = reader.GetString(1);
                        if (!reader.IsDBNull(2))
                            Comment = reader.GetString(2);
                        if (!reader.IsDBNull(3))
                            Vote = reader.GetInt32(3);

                        PlaceFeedback pf = new PlaceFeedback(Name, Email, Comment, Vote, PlaceID);

                        PF.Add(pf);
                    }
                }
                myConnection.Close();

                FV.PlaceFeedbackList = PF;

                PlaceFeedbackList.DataContext = FV;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

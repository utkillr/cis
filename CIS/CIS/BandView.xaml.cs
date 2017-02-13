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
    /// Interaction logic for BandView.xaml
    /// </summary>
    public partial class BandView : Window
    {
        FeedbackVisualizer FV = new FeedbackVisualizer();
        ObservableCollection<BandFeedback> BF;

        public BandView(int BandID)
        {
            this.Top = 0;

            InitializeComponent();

            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);

            BF = new ObservableCollection<BandFeedback>();

            Band band = new Band();
            band.UploadFromDB(BandID);

            BandNameBox.Text = band.Name;
            BandCountryBox.Text = band.Country;
            BandFanSiteBox.Text = band.FanSite;
            BandOffSiteBox.Text = band.OffSite;
            BandRatingBox.Text = band.Rating.ToString("0.00");
            BandLiveRatingBox.Text = band.LiveRating.ToString("0.00");
            GenresConverter converter = new GenresConverter();
            BandGenres.Text = converter.Convert(band.Genres, null, null, null) as string;
            BandReviewBox.Text = band.Review;
            try
            {
                BandImage.Source = new BitmapImage(new Uri(band.ImageURL));
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
                    SqlCommand cmd = new SqlCommand("SELECT Name, Email, Comment, Vote FROM BandFeedback WHERE BandID = " + BandID, myConnection);
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

                        BandFeedback bf = new BandFeedback(Name, Email, Comment, Vote, BandID);

                        BF.Add(bf);
                    }
                }
                myConnection.Close();

                FV.BandFeedbackList = BF;

                BandFeedbackList.DataContext = FV;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

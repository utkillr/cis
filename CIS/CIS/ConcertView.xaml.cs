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
    public partial class ConcertView : Window
    {
        FeedbackVisualizer FV = new FeedbackVisualizer();
        ObservableCollection<ConcertFeedback> CF;

        public ConcertView(int ConcertID)
        {
            this.Top = 0;

            InitializeComponent();

            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);

            CF = new ObservableCollection<ConcertFeedback>();

            Concert concert = new Concert();
            concert.UploadFromDB(ConcertID);

            ConcertNameBox.Text = concert.Name;
            ConcertDateBox.Text = concert.Date.ToString("yyyy.MM.dd HH:mm");
            ConcertCensorBox.Text = concert.Censor + "+";
            PlaceConverter placeConverter = new PlaceConverter();
            ConcertPlaceBox.Text = placeConverter.Convert(concert.PlaceID, null, null, null) as string;
            ConcertRatingBox.Text = concert.Rating.ToString("0.00");
            BandsConverter bandsConverter = new BandsConverter();
            ConcertBandsBox.Text = bandsConverter.Convert(concert.Bands, null, null, null) as string;
            ConcertReviewBox.Text = concert.Review;

            try
            {
                ConcertImage.Source = new BitmapImage(new Uri(concert.ImageURL));
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
                    SqlCommand cmd = new SqlCommand("SELECT Name, Email, Comment, Vote FROM ConcertFeedback WHERE ConcertID = " + ConcertID, myConnection);
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

                        ConcertFeedback cf = new ConcertFeedback(Name, Email, Comment, Vote, ConcertID);

                        CF.Add(cf);
                    }
                }
                myConnection.Close();

                FV.ConcertFeedbackList = CF;

                ConcertFeedbackList.DataContext = FV;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

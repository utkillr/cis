using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CIS
{
    public class BandsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string res = "";
            List<int> Bands = (List<int>)value;
            if (Bands != null && Bands.Count > 0)
            {
                string QueryCond = "BandID = " + Bands[0];
                for (int i = 1; i < Bands.Count; i++)
                {
                    QueryCond += " OR BandID = " + Bands[i];
                }

                SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
                try
                {
                    myConnection.Open();
                    using (myConnection)
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Name FROM Band WHERE " + QueryCond, myConnection);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                                res += reader.GetString(0) + ", ";
                        }
                        reader.Close();

                        if (res != "")
                        {
                            res = res.Remove(res.Length - 2);
                        }
                    }
                    return res;
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else
            {
                return res;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class GenresConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string res = "";
            List<int> Genres = (List<int>)value;
            if (Genres != null && Genres.Count > 0)
            {
                string QueryCond = "GenreID = " + Genres[0];
                for (int i = 1; i < Genres.Count; i++)
                {
                    QueryCond += " OR GenreID = " + Genres[i];
                }

                SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
                try
                {
                    myConnection.Open();
                    using (myConnection)
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Name FROM Genre WHERE " + QueryCond, myConnection);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                                res += reader.GetString(0) + ", ";
                        }
                        reader.Close();

                        if (res != "")
                        {
                            res = res.Remove(res.Length - 2);
                        }
                    }
                    return res;
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else
            {
                return res;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PlaceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int PlaceID = (int)value;
            SqlConnection myConnection = new SqlConnection(ConstClass.SqlCon);
                try
                {
                    myConnection.Open();
                    using (myConnection)
                    {
                        SqlCommand cmd = new SqlCommand("SELECT Name FROM Place WHERE PlaceID = " + PlaceID, myConnection);
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        if (!reader.IsDBNull(0))
                            return reader.GetString(0);
                        else return "";
                    }
                }
                catch (Exception e)
                {
                    return e.Message;
                }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class RatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                double rating = (double)value;
                return "Rating: " + rating.ToString("0.00");
            }
            else
            {
                return "Rating: unknown";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class LiveRatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                double rating = (double)value;
                return "Live Rating: " + rating.ToString("0.00");
            }
            else
            {
                return "Live Rating: unknown";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class EntityTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement elemnt = container as FrameworkElement;
            if (item.GetType() == typeof(Place))
            {
                return elemnt.FindResource("PlaceTemplate") as DataTemplate;
            }
            else if (item.GetType() == typeof(Band))
            {
                return elemnt.FindResource("BandTemplate") as DataTemplate;
            }
            else if (item.GetType() == typeof(Concert))
            {
                return elemnt.FindResource("ConcertTemplate") as DataTemplate;
            }
            else if (item.GetType() == typeof(Genre))
            {
                return elemnt.FindResource("GenreTemplate") as DataTemplate;
            }
            else {
                return null;
            }
        }
    }
}

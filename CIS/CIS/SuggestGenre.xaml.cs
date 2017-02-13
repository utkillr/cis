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

namespace CIS
{
    /// <summary>
    /// Interaction logic for SuggestGenre.xaml
    /// </summary>
    public partial class SuggestGenre : Window
    {
        public SuggestGenre()
        {
            InitializeComponent();
        }

        private void SuggestGenreBtn_Click(object sender, RoutedEventArgs e)
        {
            Genre genre = new Genre();
            Dictionary<string, object> info = new Dictionary<string,object>();
            info.Add("name", GenreNameBox.Text);
            genre.Suggest(info);
            MainWindow wndw = new MainWindow();
            wndw.Show();
            this.Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wndw = new MainWindow();
            wndw.Show();
            this.Close();
        }
    }
}

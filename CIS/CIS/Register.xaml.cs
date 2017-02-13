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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            string Email = EmailBox.Text;
            string Password = PasswordBox.Text;
            string Name = NameBox.Text;

            if (!String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(Password) && !String.IsNullOrEmpty(Name))
            {
                User user = new User();

                if (user.Register(Name, Email, Password))
                {
                    MainWindow wndw = new MainWindow();
                    wndw.Show();
                    this.Close();
                }
                else
                {
                    InfoLabel.Content = "Error, already registered :(";
                }
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

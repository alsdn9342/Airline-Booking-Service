using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Midterm_MinWooPark
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
     
        private Dictionary<string, Logins> userList = new Dictionary<string, Logins>();
        
        public LoginWindow()
        {
            InitializeComponent();

            Logins apple =  new Logins(0, "apple", "apple", 0);
            Logins banana = new Logins(1, "banana", "banana", 1);
            Logins orange = new Logins(2, "orange", "orange", 0);
            Logins mango = new Logins(3, "mango", "mango", 1);
            Logins kiwi = new Logins(4, "kiwi", "kiwi", 0);

            userList.Add("apple", apple);
            userList.Add("banana", banana);
            userList.Add("orange", orange);
            userList.Add("mango", mango);
            userList.Add("kiwi", kiwi);
        }

        public void createMainWindow()
        {
            MainWindow m = new MainWindow();
            m.Background = Brushes.Azure;
            m.Title = "Welcome";
            m.ShowDialog();

        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            

            if ((userList["apple"].UserName == textBox.Text) && (userList["apple"].Password == passwordBox.Password)){
                
                createMainWindow();

            } else if ((userList["banana"].UserName == textBox.Text) && (userList["banana"].Password == passwordBox.Password))
            {
                createMainWindow();
            }
            else if ((userList["orange"].UserName == textBox.Text) && (userList["orange"].Password == passwordBox.Password))
            {
                createMainWindow();
            }
            else if ((userList["mango"].UserName == textBox.Text) && (userList["mango"].Password == passwordBox.Password))
            {
                createMainWindow();
            }
            else if ((userList["kiwi"].UserName == textBox.Text) && (userList["kiwi"].Password == passwordBox.Password))
            {
                createMainWindow();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password", "Login Failed",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

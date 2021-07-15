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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Midterm_MinWooPark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
        }

        private void viewCustomers_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow customer = new CustomerWindow();
            customer.Background = Brushes.Azure;
            customer.Title = "Welcome";
            customer.ShowDialog();
        }

        private void viewFlight_Click(object sender, RoutedEventArgs e)
        {
            FlightWindow flight = new FlightWindow();
            flight.Background = Brushes.Azure;
            flight.Title = "Welcome";
            flight.ShowDialog();

        }

        private void viewAirlines_Click(object sender, RoutedEventArgs e)
        {
            AirlineWindow airline = new AirlineWindow();
            airline.Background = Brushes.Azure;
            airline.Title = "Welcome";
            airline.ShowDialog();
        }

        private void viewPassengers_Click(object sender, RoutedEventArgs e)
        {
            PassengerWindow passenger = new PassengerWindow();
            passenger.Background = Brushes.Azure;
            passenger.Title = "Welcome";
            passenger.ShowDialog();

        }
    }
}

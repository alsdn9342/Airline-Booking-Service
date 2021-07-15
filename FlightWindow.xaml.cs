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
    /// Interaction logic for FlightWindow.xaml
    /// </summary>
    public partial class FlightWindow : Window
    {
        List<Flights> flights = new List<Flights>();
        private List<Airlines> airlines = new List < Airlines >();
        public FlightWindow()
        {
            InitializeComponent();

            airlines.Add(new Airlines(0, "Canada Air", "Boeing777", 0, "Salad"));
            airlines.Add(new Airlines(1, "Korea Air", "Boeing888", 1, "Beef"));
            airlines.Add(new Airlines(2, "United Air", "Boeing999", 0, "Chicken"));
            airlines.Add(new Airlines(3, "Toronto Air", "Airbus777", 1, "Pork"));
            airlines.Add(new Airlines(0, "Canada Air", "Airbus888", 0, "Beef"));

            flights.Add(new Flights(0, airlines[0].ID, "Toronto", "British Columbia", "2021-03-10", 1400));
            flights.Add(new Flights(1, airlines[1].ID, "British Columbia", "Alberta", "2021-03-11", 1500));
            flights.Add(new Flights(2, airlines[2].ID, "Quebec", "Manitoba", "2021-03-12", 1600));
            flights.Add(new Flights(3, airlines[3].ID, "New York", "Chicago", "2021-03-13", 1700));
            flights.Add(new Flights(4, airlines[4].ID, "LA", "Toronto", "2021-03-14", 1800));

            var names = from flight in flights
                        select flight.DepartureCity;

            lstFlight.DataContext = names;
        }

        public void showListbox()
        {
            var names = from flight in flights
                        select flight.DepartureCity;

            lstFlight.DataContext = names;
        }

        public void addFlight()
        {
            if (tbDepartureCity.Text == "" || tbDestinationCity.Text == "" ||
                tbDepartureDate.Text == "" || tbFlightTimee.Text == "")
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                flights.Add(new Flights(flights.Count, pickAirline(), tbDepartureCity.Text, tbDestinationCity.Text,
                    tbDepartureDate.Text, pickFlightTime()));

                showListbox();
            }
        }

        public void updateFlight()
        {
            if (MessageBox.Show("Do you want to update this flight ?", "Question",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Flights f = new Flights(lstFlight.SelectedIndex, pickAirline(), tbDepartureCity.Text, tbDestinationCity.Text,
                   tbDepartureDate.Text, pickFlightTime());

                flights[lstFlight.SelectedIndex] = f;

                showListbox();
            }
        }

        public void deleteFlight()
        {
            if (MessageBox.Show("Do you want to delete this flight ?", "Question",
               MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                flights.RemoveAt(lstFlight.SelectedIndex);

                // reorder ID's - not good practise but needed to avoid breaking this app
                for (int i = 0; i < flights.Count; i++)
                    flights[i].ID = i;

                showListbox();
            }
        }

        public int pickAirline()
        {
            var airlineID = 0;
            if (canadaAir.IsChecked == true)
            {
                airlineID = 0;

            }
            else if (koreaAir.IsChecked == true)
            {
                airlineID = 1;
            }
            else if (unitedAir.IsChecked == true)
            {
                airlineID = 2;
            }
            else if (torontoAir.IsChecked == true)
            {
                airlineID = 3;
            }

            return airlineID;
        }

        public double pickFlightTime()
        {
            double flightTime = double.Parse(tbFlightTimee.Text);
            
            return flightTime;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            addFlight();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            updateFlight();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            deleteFlight();   
        }

        private void lstFlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = lstFlight.SelectedIndex;
            var selectedCustomer = from flight in flights
                                   where flight.ID == i
                                   select flight;

            foreach (var s in selectedCustomer)
            {
                tbDepartureCity.Text = s.DepartureCity;
                tbDestinationCity.Text = s.DestinationCity;
                tbDepartureDate.Text = s.DepartureDate;
                tbFlightTimee.Text = s.FlightTime.ToString();

                if(s.AirlineID == 0)
                {
                    tbAirline.Text = "Canada air";
                } else if (s.AirlineID == 1)
                {
                    tbAirline.Text = "Korea air";
                }
                else if (s.AirlineID == 2)
                {
                    tbAirline.Text = "United air";
                }
                else if (s.AirlineID == 3)
                {
                    tbAirline.Text = "Toronto air";
                }
            }
        }

        private void addContext_Click(object sender, RoutedEventArgs e)
        {
            addFlight();
        }

        private void updateContext_Click(object sender, RoutedEventArgs e)
        {
            updateFlight();
        }

        private void deleteContext_Click(object sender, RoutedEventArgs e)
        {
            deleteFlight();
        }

        private void quit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to quit this window ?", "Warning",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void insertMenuBar_Click(object sender, RoutedEventArgs e)
        {
            addFlight();
        }

        private void updateMenuBar_Click(object sender, RoutedEventArgs e)
        {
            updateFlight();
        }

        private void deleteMenuBar_Click(object sender, RoutedEventArgs e)
        {
            deleteFlight();
        }

        private void helpMenuBar_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow h = new HelpWindow();
            h.Background = Brushes.Azure;
            h.Title = "Help";
            h.Show();
        }
    }
}

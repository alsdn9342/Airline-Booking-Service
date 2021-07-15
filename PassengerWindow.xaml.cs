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
    /// Interaction logic for PassengerWindow.xaml
    /// </summary>
    public partial class PassengerWindow : Window
    {
        List<Customer> customers = new List<Customer>();
        List<Flights> flights = new List<Flights>();
        List<Airlines> airlines = new List<Airlines>();
        List<Passenger> passengers = new List<Passenger>();
        public PassengerWindow()
        {

            InitializeComponent();
            customers.Add(new Customer(0, "Min Woo", "Mississauga", "parkminw@sheridancollege.ca", "111-111-111"));
            customers.Add(new Customer(1, "Bill", "Toront", "bill@sheridancollege.ca", "222-222-222"));
            customers.Add(new Customer(2, "Jana", "Oakvile", "jana@sheridancollege.ca", "333-333-333"));
            customers.Add(new Customer(3, "Dave", "Brampton", "dave@sheridancollege.ca", "444-444-444"));
            customers.Add(new Customer(4, "Angelina", "Millton", "angelina@sheridancollege.ca", "555-555-555"));

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

            passengers.Add(new Passenger(0, customers[0].ID, flights[0].ID));
            passengers.Add(new Passenger(1, customers[1].ID, flights[1].ID));
            passengers.Add(new Passenger(2, customers[2].ID, flights[2].ID));
            passengers.Add(new Passenger(3, customers[3].ID, flights[3].ID));
            passengers.Add(new Passenger(4, customers[4].ID, flights[4].ID));


            var customerNames = from customer in customers
                        select customer.Name;

            lstCustomer.DataContext = customerNames;

            var flightNames = from flight in flights
                                select flight.DepartureCity;

            lstFlight.DataContext = flightNames;

            var passengerID = from passenger in passengers
                              select passenger.ID;

            lstPassenger.DataContext = passengerID;
        }

        public void showListbox()
        {
            var passengerID = from passenger in passengers
                              select passenger.ID;

            lstPassenger.DataContext = passengerID;
        }

        public void addPassenger()
        {
            passengers.Add(new Passenger(passengers.Count, lstCustomer.SelectedIndex, lstFlight.SelectedIndex));

            showListbox();
        }

        public void updatePassenser()
        {
            if (MessageBox.Show("Do you want to update this passenger ?", "Question",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Passenger p = new Passenger(lstPassenger.SelectedIndex, customers[lstCustomer.SelectedIndex].ID, flights[lstFlight.SelectedIndex].ID);

                passengers[lstPassenger.SelectedIndex] = p;

                showListbox();
            }
        }

        public void deletePassenger()
        {
            if (MessageBox.Show("Do you want to delete this passenger ?", "Question",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                passengers.RemoveAt(lstPassenger.SelectedIndex);

                // reorder ID's - not good practise but needed to avoid breaking this app
                for (int i = 0; i < passengers.Count; i++)
                    passengers[i].ID = i;

                showListbox();
            }
        }

        private void lstPassenger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int i = lstPassenger.SelectedIndex;
            var selectedPassenger = from passenger in passengers
                                   where passenger.ID == i
                                   select passenger;

            foreach (var s in selectedPassenger)
            {
                tbName.Text = customers[s.CustomerID].Name;
                tbEmail.Text = customers[s.CustomerID].Email;
                tbAddress.Text = customers[s.CustomerID].Address;
                tbPhone.Text = customers[s.CustomerID].Phone;

                tbDepartureCity.Text = flights[s.FlightID].DepartureCity;
                tbDestinationCity.Text = flights[s.FlightID].DestinationCity;
                tbDepartureDate.Text = flights[s.FlightID].DepartureDate;
                tbFlightTimee.Text = flights[s.FlightID].FlightTime.ToString();

                if (flights[s.FlightID].ID == 0)
                {
                    tbAirline.Text = "Canada air";
                }
                else if (flights[s.FlightID].ID == 1)
                {
                    tbAirline.Text = "Korea air";
                }
                else if (flights[s.FlightID].ID == 2)
                {
                    tbAirline.Text = "United air";
                }
                else if (flights[s.FlightID].ID == 3)
                {
                    tbAirline.Text = "Toronto air";
                }


                tbPassengerName.Text = customers[s.CustomerID].Name;
                tbDepartureCityOfPassenger.Text = flights[s.FlightID].DepartureCity;

            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            addPassenger();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            updatePassenser();  
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            deletePassenger();  
        }

        private void addContext_Click(object sender, RoutedEventArgs e)
        {
            addPassenger();
        }

        private void updateContext_Click(object sender, RoutedEventArgs e)
        {
            updatePassenser();
        }

        private void deleteContext_Click(object sender, RoutedEventArgs e)
        {
            deletePassenger();
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
            addPassenger();
        }

        private void updateMenuBar_Click(object sender, RoutedEventArgs e)
        {
            updatePassenser();
        }

        private void deleteMenuBar_Click(object sender, RoutedEventArgs e)
        {
            deletePassenger();
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

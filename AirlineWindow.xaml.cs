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
    /// Interaction logic for AirlineWindow.xaml
    /// </summary>
    public partial class AirlineWindow : Window
    {
        List<Airlines> airlines = new List<Airlines>();
        public AirlineWindow()
        {
            InitializeComponent();
            
            airlines.Add(new Airlines(0, "Canada Air", "Boeing777", 0, "Salad"));
            airlines.Add(new Airlines(1, "Korea Air", "Boeing888", 1, "Beef"));
            airlines.Add(new Airlines(2, "United Air", "Boeing777", 0, "Chicken"));
            airlines.Add(new Airlines(3, "Toronto Air", "Airbus777", 1, "Pork"));
            airlines.Add(new Airlines(4, "Canada Air", "Airbus999", 0, "Beef"));

            var names = from airline in airlines
                        select airline.Name;

            lstAirline.DataContext = names;

        }

        public void showListbox()
        {
            var names = from airline in airlines
                        select airline.Name;

            lstAirline.DataContext = names;
        }

        public void addAirline()
        {
            if (tbSeatAvailable.Text == "")
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int seatAvailable = int.Parse(tbSeatAvailable.Text);
                airlines.Add(new Airlines(airlines.Count, pickName(), pichAirplane(), seatAvailable, pickMeal()));

                showListbox();
            }
        }
        public void updateAirline()
        {
            if (MessageBox.Show("Do you want to update this airline ?", "Question",
                  MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                int seatAvailable = int.Parse(tbSeatAvailable.Text);
                Airlines a = new Airlines(lstAirline.SelectedIndex, pickName(), pichAirplane(), seatAvailable, pickMeal());

                airlines[lstAirline.SelectedIndex] = a;

                showListbox();
            }
        }

        public void deleteAirline()
        {
            if (MessageBox.Show("Do you want to delete this airline ?", "Question",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                airlines.RemoveAt(lstAirline.SelectedIndex);

                // reorder ID's - not good practise but needed to avoid breaking this app
                for (int i = 0; i < airlines.Count; i++)
                    airlines[i].ID = i;

                showListbox();
            }
        }

        public string pickName()
        {
            var name = "";

            if(canadaAir.IsChecked == true)
            {
                name = "Canada Air";
                
            }
            else if(unitedAir.IsChecked == true)
            {
                name = "United Air";
                
            }
            else if (koreaAir.IsChecked == true)
            {
                name = "Korea Air";
                
            }
            else if (torontoAir.IsChecked == true)
            {
                name = "Toronto Air";
            }

            return name;
        }

        public string pichAirplane()
        {
            var airplane = "";
            if(boeing777.IsChecked == true)
            {
                airplane = "Boeing777";
            }
            else if(boeing888.IsChecked == true)
            {
                airplane = "Boeing888";
            }
            else if (airbus777.IsChecked == true)
            {
                airplane = "Airbus777";
            }
            else if (airbus999.IsChecked == true)
            {
                airplane = "Airbus999";
            }

            return airplane;
        }

        public string pickMeal()
        {
            var meal = "";
            if (beef.IsChecked == true)
            {
                meal = "Beef";
            }
            else if (pork.IsChecked == true)
            {
                meal = "Pork";
            }
            else if (salad.IsChecked == true)
            {
                meal = "Salad";
            }
            else if (chicken.IsChecked == true)
            {
                meal = "Chicken";
            }

            return meal;
        }

        private void lstAirline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = lstAirline.SelectedIndex;
            var selectedCustomer = from ailine in airlines
                                   where ailine.ID == i
                                   select ailine;

            foreach (var s in selectedCustomer)
            {
                if (s.Name == "Canada Air")
                {
                    canadaAir.IsChecked = true;
                } else if (s.Name == "United Air")
                {

                    unitedAir.IsChecked = true;
                }
                else if (s.Name == "Korea Air")
                {

                    koreaAir.IsChecked = true;
                }
                else if (s.Name == "Toronto Air")
                {

                    torontoAir.IsChecked = true;
                }

                if (s.Airplane == "Boeing777")
                {
                    boeing777.IsChecked = true;
                }
                else if (s.Airplane == "Airbus777")
                {
                    airbus777.IsChecked = true;
                }
                else if (s.Airplane == "Airbus999")
                {
                    airbus999.IsChecked = true;
                }

                string seatAvailable = s.SeatsAvailable.ToString();
                tbSeatAvailable.Text = seatAvailable;

                if (s.MealAvailable == "Chicken")
                {
                    chicken.IsChecked = true;
                }
                else if (s.MealAvailable == "Pork")
                {
                    pork.IsChecked = true;
                }
                else if (s.MealAvailable == "Beef")
                {
                    beef.IsChecked = true;
                }
                else if (s.MealAvailable == "Salad")
                {
                    salad.IsChecked = true;
                }

            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            addAirline();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            updateAirline();   
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            deleteAirline();
            
        }

        private void addContext_Click(object sender, RoutedEventArgs e)
        {
            addAirline();
        }

        private void updateContext_Click(object sender, RoutedEventArgs e)
        {
            updateAirline();
        }

        private void deleteContext_Click(object sender, RoutedEventArgs e)
        {
            deleteAirline();
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
            addAirline();
        }

        private void updateMenuBar_Click(object sender, RoutedEventArgs e)
        {
            updateAirline();
        }

        private void deleteMenuBar_Click(object sender, RoutedEventArgs e)
        {
            deleteAirline();
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

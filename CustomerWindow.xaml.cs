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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
       List<Customer> customers { get; set; } = new List<Customer>();

        public CustomerWindow()
        {
            
            InitializeComponent();

            customers.Add(new Customer(0, "Min Woo", "Mississauga", "parkminw@sheridancollege.ca", "111-111-111"));
            customers.Add(new Customer(1, "Bill", "Toront", "bill@sheridancollege.ca", "222-222-222"));
            customers.Add(new Customer(2, "Jana", "Oakvile", "jana@sheridancollege.ca", "333-333-333"));
            customers.Add(new Customer(3, "Dave", "Brampton", "dave@sheridancollege.ca", "444-444-444"));
            customers.Add(new Customer(4, "Angelina", "Millton", "angelina@sheridancollege.ca", "555-555-555"));

            var names = from customer in customers
                        select customer.Name;

            lstCustomer.DataContext = names;
        }

        public void showListbox()
        {

            var names = from customer in customers
                        select customer.Name;

            lstCustomer.DataContext = names;
        }

        public void addCustomer()
        {
            if (tbName.Text == "" || tbAddress.Text == "" ||
                tbEmail.Text == "" || tbPhone.Text == "")
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                customers.Add(new Customer(customers.Count, tbName.Text, tbAddress.Text, tbEmail.Text, tbPhone.Text));

                showListbox();
            }
        }

        public void updateCustomer()
        {
            if (MessageBox.Show("Do you want to update this customer ?", "Question",
                 MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Customer c = new Customer(lstCustomer.SelectedIndex, tbName.Text, tbAddress.Text, tbEmail.Text, tbPhone.Text);

                customers[lstCustomer.SelectedIndex] = c;

                showListbox();

            }
        }

        public void deleteCustomer()
        {
            if (MessageBox.Show("Do you want to delete this customer ?", "Question",
                 MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                customers.RemoveAt(lstCustomer.SelectedIndex);

                // reorder ID's - not good practise but needed to avoid breaking this app
                for (int i = 0; i < customers.Count; i++)
                    customers[i].ID = i;

                showListbox();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            addCustomer();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            updateCustomer();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            deleteCustomer();
            
        }

        private void lstCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = lstCustomer.SelectedIndex;
            var selectedCustomer = from customer in customers
                               where customer.ID == i
                               select customer;

            foreach (var s in selectedCustomer)
            {
                tbName.Text = s.Name;
                tbAddress.Text = s.Address;
                tbEmail.Text = s.Email;
                tbPhone.Text = s.Phone;
            }

        }

        private void addContext_Click(object sender, RoutedEventArgs e)
        {
            addCustomer();
        }

        private void updateContext_Click(object sender, RoutedEventArgs e)
        {
            updateCustomer();
        }

        private void deleteContext_Click(object sender, RoutedEventArgs e)
        {
            deleteCustomer();
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
            addCustomer();

        }

        private void updateMenuBar_Click(object sender, RoutedEventArgs e)
        {
            updateCustomer();
        }

        private void deleteMenuBar_Click(object sender, RoutedEventArgs e)
        {
            deleteCustomer();
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

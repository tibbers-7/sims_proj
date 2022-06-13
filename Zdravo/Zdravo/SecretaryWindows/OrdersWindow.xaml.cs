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
using ViewModel;
using System.Collections.ObjectModel;
using Model;
using Service;
using System.ComponentModel;
using Repository;
using System.Text.RegularExpressions;

namespace Zdravo.SecretaryWindows
{
    /// <summary>
    /// Interaction logic for OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        private OrderService orderService;
        private OrderViewModel viewModel;
        public OrdersWindow()
        {
            InitializeComponent();
            viewModel=new OrderViewModel(this);
            this.DataContext = viewModel;
        }

        private void SubmitOrderClick(object sender, RoutedEventArgs e)
        {
            orderService=new OrderService();
            string name = nameTextBox.Text;
            int quantity = int.Parse(quantityTextBox.Text);
            string note = noteTextBox.Text;
            DateTime orderDateTime= DateTime.Now;
            Order newOrder = new Order(name, quantity, orderDateTime, note);
            orderService.addNewOrder(newOrder);
            viewModel.Refresh();
            nameTextBox.Text = "";
            noteTextBox.Text = "";
            quantityTextBox.Text = "";
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            SecretaryHome secretaryHomeWindow=new SecretaryHome();
            secretaryHomeWindow.Show();
            this.Close();
        }

        private void NoteClick(object sender, RoutedEventArgs e)
        {
            Order selected = (Order)table.SelectedValue;
            DateTime orderDateTime=selected.OrderDateTime;
            DateTime now=DateTime.Now;
            var difference = now - orderDateTime;
            if (difference.TotalHours < 72) noteTextBox.Text = "manje";
            else noteTextBox.Text = "vise"; 
            MessageBox.Show(selected.Note);
        }

        private void AllClick(object sender, RoutedEventArgs e)
        {
            viewModel.Refresh();
        }

        private void ActiveClick(object sender, RoutedEventArgs e)
        {
            viewModel = new OrderViewModel(this,true);
            this.DataContext = null;
            this.DataContext = viewModel;
        }
        private bool validateName(string s)
        {
            Regex regex = new Regex("^[A-Z][a-zA-Z]*$");
            return regex.IsMatch(s);
        }
        private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool result = validateName(nameTextBox.Text);
            if (!result)
            {
                nameError.Text = "not valid name!";
            }
            if (result)
            {
                nameError.Text = "";
            }
        }
        private bool validateNumbers(string s)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(s);
        }
        private void quantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool result = validateNumbers(quantityTextBox.Text);
            if (!result)
            {
                quantityError.Text = "not valid quantity!";
            }
            if (result)
            {
                quantityError.Text = "";
            }
        }
    }
}

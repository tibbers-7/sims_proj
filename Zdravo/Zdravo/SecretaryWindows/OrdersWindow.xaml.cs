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
using Model;
using Service;
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
    }
}

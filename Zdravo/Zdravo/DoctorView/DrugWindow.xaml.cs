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
using Zdravo.ViewModel;

namespace Zdravo.DoctorView
{
    /// <summary>
    /// Interaction logic for DrugWindow.xaml
    /// </summary>
    public partial class DrugWindow : Window
    {
        private DrugViewModel viewModel;
        private DoctorHomeViewModel callerWindow;
        public DrugWindow(DoctorHomeViewModel callerWindow,int drugId)
        {
            this.callerWindow = callerWindow;
            viewModel = new DrugViewModel(callerWindow,drugId);
            this.DataContext = viewModel;
            InitializeComponent();
            if (callerWindow==null)
            {
                acceptButton.IsEnabled = false;
                denyButton.IsEnabled = false;
            }
            if (viewModel.Status.Equals("ODOBRENO"))
            {
                acceptButton.IsEnabled = false;
            }
            
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {

            if (callerWindow != null)
            {
                viewModel.AcceptDrug();
                callerWindow.RefreshDrugs();
            }
            else { }
            this.Close();
            
        }

        private void DenyButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.DenyDrug();
            if (callerWindow != null) callerWindow.RefreshDrugs();
            this.Close();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

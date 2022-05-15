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
            viewModel = new DrugViewModel(drugId);
            this.DataContext = viewModel;
            InitializeComponent();
            if (!viewModel.Status.Equals("NA ČEKANJU"))
            {
                acceptButton.IsEnabled = false;
                denyButton.IsEnabled = false;
            }
            
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AcceptDrug();
            callerWindow.RefreshDrugs();
            this.Close();
            
        }

        private void DenyButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.DenyDrug();
            callerWindow.RefreshDrugs();
            this.Close();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

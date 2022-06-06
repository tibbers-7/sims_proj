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
using Zdravo.Controller;
using Model;
namespace Zdravo.SecretaryWindows
{
    /// <summary>
    /// Interaction logic for VacationsWindow.xaml
    /// </summary>
    public partial class VacationsWindow : Window
    {
        VacationsViewModel vacationsViewModel;
        VacationController vacationController;
        Notification notificationWindow;
        public VacationsWindow()
        {
            InitializeComponent();
            vacationsViewModel= new VacationsViewModel();
            this.DataContext = vacationsViewModel;
            var app = Application.Current as App;
            vacationController = app.vacationController;
        }

        private void ReasonClick(object sender, RoutedEventArgs e)
        {

        }

        private void approveVacationClick(object sender, RoutedEventArgs e)
        {
            VacationRecord selectedRecord =(VacationRecord)table.SelectedValue;
            if (selectedRecord != null)
            {
                vacationController.processVacation(selectedRecord.Id, 1);
                errorLabel.Content = "";
                successLabel.Content = "Vacation approved.";
            }
            else {
                successLabel.Content = "";
                errorLabel.Content = "No vacation selected."; 
            }
            notificationWindow = new Notification();
            notificationWindow.Show();
        }

        private void denyVacationClick(object sender, RoutedEventArgs e)
        {
            VacationRecord selectedRecord = (VacationRecord)table.SelectedValue;
            if (selectedRecord != null)
            {
                vacationController.processVacation(selectedRecord.Id, 2);
                errorLabel.Content = "";
                successLabel.Content = "Vacation denied.";
            }
            else
            {
                successLabel.Content = "";
                errorLabel.Content = "No vacation selected.";
            }
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            if(notificationWindow!=null) notificationWindow.Close();
            this.Close();
        }
    }
}

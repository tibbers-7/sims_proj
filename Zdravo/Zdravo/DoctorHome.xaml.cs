using System;
using System.Windows;
using System.Windows.Controls;
using Zdravo.ViewModel;
using System.Windows.Threading;

namespace Zdravo
{
    public partial class DoctorHome : Window
    {

        private DoctorHomeViewModel viewModel;
        private int errorCode;

        public DoctorHome(int doctorId)
        {
            InitializeComponent();
            viewModel = new DoctorHomeViewModel(doctorId);
            DataContext = viewModel;
            
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, (object s, EventArgs ev) =>
            {
                this.myDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            }, this.Dispatcher);
            timer.Start();
        }



        private void UpcomingRow_DoubleClick(object sender, RoutedEventArgs e)
        {
            object item = UpcomingTable.SelectedItem;
            viewModel.AppointmentShow(int.Parse((UpcomingTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
        }

        private void PassedRow_DoubleClick(object sender, RoutedEventArgs e)
        {
            object item = PassedTable.SelectedItem;
            viewModel.AppointmentShow(int.Parse((PassedTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
        }
        private void DrugRow_DoubleClick(object sender, RoutedEventArgs e)
        {
            object item = DrugsTable.SelectedItem;
            viewModel.DrugShow(int.Parse((DrugsTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
        }

        private void VacationRow_DoubleClick(object sender, RoutedEventArgs e)
        {
            object item = VacationTable.SelectedItem;
            viewModel.VacationShow(int.Parse((VacationTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            
           this.Close();
            
        }

        private void Referral_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ShowReferral();
        }

        private void VacationButton_Click(object sender, RoutedEventArgs e)
        {
            if (vacationRadio.IsChecked == false && sickLeaveRadio.IsChecked == false) MessageBox.Show("Niste uneli sve potrebne podatke.", "Greška");
            else if (startDate_tb.Text.Equals("") | endDate_tb.Text.Equals("") | reason_tb.Text.Equals("")) MessageBox.Show("Niste uneli sve potrebne podatke.", "Greška");
            else viewModel.ScheduleVacation((bool)emergency_Check.IsChecked);
            

        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.RefreshAppointments();
        }


        private void NewAppointment_Click(object sender, RoutedEventArgs e)
        {
            viewModel.NewAppointment();
            
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object item = UpcomingTable.SelectedItem;
            if (item != null)
            {
                int id = int.Parse((UpcomingTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                viewModel.UpdateAppointment(id);
                
            }
            else MessageBox.Show("Niste odabrali pregled!");
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            object item = PassedTable.SelectedItem;
            if (item!=null)
            {
                int id = int.Parse((PassedTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                viewModel.ReportShow(id);
            }
            else MessageBox.Show("Niste odabrali pregled!");
        }

        private void Prescription_Click(object sender, RoutedEventArgs e)
        {
            object item = PassedTable.SelectedItem;
            if (item != null)
            {
                int id = int.Parse((PassedTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                viewModel.PrescriptionShow(id);
               
            }
            else MessageBox.Show("Niste odabrali pregled!");
        }

        private void RejectDrug_Click(object sender, RoutedEventArgs e)
        {
            object item = DrugsTable.SelectedItem;
            if (item != null)
            {
                int id = int.Parse((DrugsTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                viewModel.ReportDrug(id);
            }
            else MessageBox.Show("Niste odabrali pregled!");
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object item = UpcomingTable.SelectedItem;
            if (item != null)
            {
                int id = int.Parse((UpcomingTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                viewModel.DeleteAppt(id);
            }
            else MessageBox.Show("Niste odabrali pregled!");
        }

    }
}

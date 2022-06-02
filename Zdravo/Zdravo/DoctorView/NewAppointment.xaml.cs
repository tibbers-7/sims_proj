using System.Windows;
using Zdravo.ViewModel;

namespace Zdravo
{
    public partial class NewAppointment: Window { 
        private NewAppointmentViewModel viewModel;
        private DoctorHomeViewModel callerWindow;
        private int apptId;

        public NewAppointment(DoctorHomeViewModel callerWindow, int apptId,int doctorId,bool isEditable)
        {
            
            InitializeComponent();
            if (apptId == 0) patientButton.Content = "Izaberi pacijenta";
            else patientId_tb.IsReadOnly = true;
            
            if (!isEditable)
            {
                patientId_tb.IsReadOnly = true;
                date_tb.IsReadOnly=true;
                hour_tb.IsReadOnly = true;
                minutes_tb.IsReadOnly = true;
                rooms_cb.IsReadOnly = true;
                duration_tb.IsReadOnly = true;
            }

            this.callerWindow = callerWindow;
            this.apptId = apptId;
            viewModel = new NewAppointmentViewModel(apptId, doctorId);
            DataContext = viewModel;   
        }
        
        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            if (rooms_cb.SelectedIndex==-1 | duration_tb.Text.Equals("0") | date_tb.Text.Equals(""))
            {
                MessageBox.Show("Nisu unete svi potrebne informacije.", "Greška");
                return;
            } 
            int errorCode=viewModel.CreateAppointment();
            switch (errorCode)
            {
                case 0:
                    callerWindow.RefreshAppointments();
                    this.Close();
                    break;
                case 1:
                    MessageBox.Show("Pacijent sa tim JMBG ne postoji.", "Greška");
                    break;
                case 2:
                    MessageBox.Show("Vreme koje ste odabrali za zakazivanje termina je prošlo.", "Greška");
                    break;
            }

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Patient_Click(object sender, RoutedEventArgs e)
        {
            if (apptId == 0) viewModel.ChoosePatient();
            else viewModel.ShowChart(apptId);
        }
    }
}

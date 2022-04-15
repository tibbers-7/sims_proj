using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Zdravo
{
    /// <summary>
    /// Interaction logic for DoctorHome.xaml
    /// </summary>
    public partial class DoctorHome : Window, INotifyPropertyChanged
    {
        AppointmentController apController;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Appointment> appointments { get; set; }

        public DoctorHome()
        {
            InitializeComponent();
            this.DataContext = this;
            apController = new AppointmentController();
            appointments = apController.GetAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewAppointment newAppointment=new NewAppointment(0);
            newAppointment.Show();
        }

        public void refreshAppointments()
        {
            AppointmentTable.Items.Refresh();
            appointments = apController.GetAll();
        }

        private void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            object item = AppointmentTable.SelectedItem;
            string ID = (AppointmentTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            AppointmentMenu menu = new AppointmentMenu();
            menu.Show();
        }
    }
}

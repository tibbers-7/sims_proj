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
using Repository;
using System.Collections.ObjectModel;
using Model;
using System.ComponentModel;
using FileHandler;
namespace Zdravo.SecretaryWindows
{
    /// <summary>
    /// Interaction logic for AddParticipantWindow.xaml
    /// </summary>
    public partial class AddParticipantWindow : Window
    {
        private int meetingId;
        public AddParticipantWindow(int id)
        {
            InitializeComponent();
            this.meetingId = id;
            this.DataContext = this;
            DoctorRepository doctorRepository=new DoctorRepository();
            ObservableCollection<Doctor> doctors = doctorRepository.getAll();
            ObservableCollection<Participant> users = new ObservableCollection<Participant>();
            foreach(Doctor doctor in doctors)
            {
                users.Add(new Participant(doctor.Name + " " + doctor.LastName, doctor.Specialization));
            }
            table.ItemsSource = users;
        }
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;


        private void BackClick(object sender, RoutedEventArgs e)
        {
            MeetingsWindow meetingsWindow = new MeetingsWindow();
            meetingsWindow.Show();
            this.Close();
        }

        private void AddParticipant(object sender, RoutedEventArgs e)
        {
            MeetingsFileHandler meetingsFileHandler = new MeetingsFileHandler();
            Participant participant = (Participant)table.SelectedValue;
            if (participant != null)
            {
                meetingsFileHandler.addParticipant(participant, meetingId);
                successLabel.Content=participant.Name+ " successfully added to meeting";
                errorLabel.Content = "";
            }
            else
            {
                successLabel.Content = "";
                errorLabel.Content = "No user selected";
            }
        }
    }
}

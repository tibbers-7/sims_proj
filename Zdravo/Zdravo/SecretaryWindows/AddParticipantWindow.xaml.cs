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
using System.Text.RegularExpressions;

namespace Zdravo.SecretaryWindows
{
    /// <summary>
    /// Interaction logic for AddParticipantWindow.xaml
    /// </summary>
    public partial class AddParticipantWindow : Window
    {
        public AddParticipantWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            DoctorRepository doctorRepository=new DoctorRepository();
            ObservableCollection<Doctor> doctors = doctorRepository.getAll();
            ObservableCollection<Participant> users = new ObservableCollection<Participant>();
            foreach(Doctor doctor in doctors)
            {
                users.Add(new Participant(doctor.Name + " " + doctor.LastName, doctor.Specialization));
            }
            users.Add(new Participant("Darko Filipovic", "Sekretar"));
            users.Add(new Participant("Branka Kljajic", "Upravnik"));
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
                meetingsFileHandler.addParticipant(participant, 7);
                successLabel.Content=participant.Name+ " successfully added to meeting";
                errorLabel.Content = "";
            }
            else
            {
                successLabel.Content = "";
                errorLabel.Content = "No user selected";
            }
        }

        private void CreateMeetingClick(object sender, RoutedEventArgs e)
        {
            int id = 7; ;
            string desc = tbDesc.Text;
            string time = tbTime.Text;
            string date = datePicker.SelectedDate.ToString();
            Meeting newMeeting = new Meeting(id, desc, date.Split(" ")[0], time, null);
            MeetingsFileHandler fileHandler = new MeetingsFileHandler();
            fileHandler.addNewMeeting(newMeeting);
        }
    }
}

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
using FileHandler;
namespace Zdravo.SecretaryWindows
{
    /// <summary>
    /// Interaction logic for MeetingsWindow.xaml
    /// </summary>
    public partial class MeetingsWindow : Window
    {
        public MeetingsWindow()
        {
            InitializeComponent();
            MeetingsViewModel viewModel=new MeetingsViewModel();
            this.DataContext = viewModel;
        }

        private void MoreClick(object sender, RoutedEventArgs e)
        {
            Meeting selected = (Meeting)table.SelectedValue;
            AddParticipantWindow addParticipantWindow = new AddParticipantWindow();
            addParticipantWindow.Show();
            this.Close();
        }

        private void table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            participantsTextBox.Text = "";
            Meeting selected = (Meeting)table.SelectedValue;
            int i = 1;
            if (selected != null)
            {
                foreach (string user in selected.Users)
                {
                    if (user != "")
                    {
                        string newLine = Environment.NewLine;
                        participantsTextBox.Text = participantsTextBox.Text + i.ToString() + ". " + user + newLine;
                        i++;
                    }
                }
            }
        }

        private void CreateMeetingClick(object sender, RoutedEventArgs e)
        {
            AddParticipantWindow addParticipantWindow = new AddParticipantWindow();
            addParticipantWindow.Show();
            this.Close();
        }
        private void refreshTableData()
        {
            MeetingsViewModel viewModel = new MeetingsViewModel();
            this.DataContext = null; 
            this.DataContext = viewModel;
        }



        private void BackClick(object sender, RoutedEventArgs e)
        {
            SecretaryHome secretaryHome = new SecretaryHome();
            secretaryHome.Show();
            this.Close();
        }
    }
}

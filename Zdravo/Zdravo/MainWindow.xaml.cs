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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zdravo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string[] lines = System.IO.File.ReadAllLines("data/accounts.txt");
            foreach(string s in lines)
            {
                string[] parameters = s.Split(',');
                if (tbUsername.Text.Equals(parameters[0]) && tbPassword.Text.Equals(parameters[1]))
                {
                    if (parameters[2].Equals("S")){
                        //otvara se sekretar page
                       
                       SekretarHome sh = new SekretarHome();
                        sh.Show();
                        this.Close();
                    }
                    if (parameters[2].Equals("U")){
                        //otvara se upravnik page
                        ManagerHome mh = new ManagerHome();
                        mh.Show();
                        this.Close();
                    }
                    if (parameters[2].Equals("L")) {
                        DoctorHome dh=new DoctorHome();
                        dh.Show();
                        this.Close();
                        //otvara se lekar page
                    }
                }
            }
        }
    }
}

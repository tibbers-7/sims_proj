using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Repository;
using Model;
namespace Zdravo
{
    /// <summary>
    /// Interaction logic for SekretarHome.xaml
    /// </summary>
    public partial class SekretarHome : Window
    {
        public SekretarHome()
        {
            InitializeComponent();
            PatientRepository p = new PatientRepository();
            List<Patient> patients = p.GetAll();
            table.ItemsSource = patients;
        }
    }
}

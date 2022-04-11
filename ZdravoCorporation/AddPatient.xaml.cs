using Controller;
using Model;
using Repository;
using Service;
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

namespace ZdravoCorporation
{
    /// <summary>
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class AddPatient : Window
    {
        public AddPatient(string id)
        {
            InitializeComponent();
            PatientService service = new PatientService();
            tbId.Text = service.checkId();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PatientRepository repo = new PatientRepository();
            PatientController controller = new PatientController();
            repo.addPatient(controller.CreatePatient( tbIme,  tbPrezime,  Int16.Parse(tbId.Text),  tbUsername,  tbSifra,  tbTelefon,  tbDatum,  cbPol,  tbAdresa,  checkBoxGuest,  tbMail));
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

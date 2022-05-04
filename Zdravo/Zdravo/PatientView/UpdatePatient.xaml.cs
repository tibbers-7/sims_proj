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
using Model;
using Controller;
using Repository;
using Service;
using Zdravo.ViewModel;
namespace Zdravo.PatientView
{
    /// <summary>
    /// Interaction logic for UpdatePatient.xaml
    /// </summary>
    public partial class UpdatePatient : Window
    {
        private SekretarHome sekr = new SekretarHome();
        private PatientsViewModel viewModel=new PatientsViewModel();
        public UpdatePatient(string i, string p, int idd, string u, string sif, string tel, DateTime dat, Gender po, bool gu, string adr, string ema,SekretarHome s )
        {
            InitializeComponent();
            tbIme.Text = i;
            tbPrezime.Text = p;
            tbId.Text = idd.ToString();
            tbUsername.Text = u;
            tbSifra.Text = sif;
            tbTelefon.Text = tel;
            tbDatum.Text = dat.ToString();
            if (po == Gender.male) cbPol.SelectedIndex = 0;
            else cbPol.SelectedIndex = 1;
            checkBoxGuest.IsChecked = gu;
            tbAdresa.Text = adr;
            tbMail.Text = ema;
            this.sekr = s;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PatientController controller = new PatientController();
            Patient p = controller.CreatePatient(tbIme, tbPrezime, Int16.Parse(tbId.Text), tbUsername, tbSifra, tbTelefon, tbDatum, cbPol, tbAdresa, checkBoxGuest, tbMail);
            PatientRepository repo = new PatientRepository();
            repo.updatePatient(p);
            SekretarHome s = new SekretarHome();
            viewModel.Refresh();
            sekr.DataContext = null;
            sekr.DataContext = viewModel;
            this.Close();
        }
    }
}

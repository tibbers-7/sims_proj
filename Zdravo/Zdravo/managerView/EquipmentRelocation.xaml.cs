using Model;
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
using Zdravo.ViewModel;

namespace Zdravo.managerView
{
    /// <summary>
    /// Interaction logic for EquipmentRelocation.xaml
    /// </summary>
    public partial class EquipmentRelocation : Window
    {
        public EquipmentRelocationViewModel viewModel;
        public EquipmentRelocation()
        {
            InitializeComponent();
            viewModel = new EquipmentRelocationViewModel();
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StaticEquipment selectedEq = (StaticEquipment)dataGridEquipment.SelectedItem;
            Room selectedRoom = (Room)dataGridRooms.SelectedItem;
            int _errorCode = viewModel.Create(selectedEq, selectedRoom);

            switch (_errorCode)
            {
                case 0:
                    this.Close();
                    break;
                case 1:
                    MessageBox.Show("Datum koji ste izabrali je prosao.", "Greška");
                    break;
                case 2:
                    MessageBox.Show("Ne možete zakazati premeštanje u sobu u kojoj se oprema već nalazi.", "Greška");
                    break;
                default:
                    this.Close();
                    break;
            }
        }
    }
}

using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for EquipmentReview.xaml
    /// </summary>
    public partial class EquipmentReview : Window
    {
        private EquipmentReviewViewModel viewModel;
        public EquipmentReview()
        {
            InitializeComponent();
            this.viewModel = new EquipmentReviewViewModel();
            this.DataContext = viewModel;
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            if (!searchTb.Text.Equals(""))
            {
                viewModel = new EquipmentReviewViewModel();
                ObservableCollection<StaticEquipment> foundEquipment = new ObservableCollection<StaticEquipment>();
                foreach (StaticEquipment equipment in viewModel.Equipment)
                {
                    if (equipment.name.Equals(searchTb.Text)) foundEquipment.Add(equipment);
                }
                viewModel = new EquipmentReviewViewModel(foundEquipment);
                DataContext = null;
                DataContext = viewModel;
            }
            else
            {
                viewModel = new EquipmentReviewViewModel();
                DataContext = null;
                DataContext = viewModel;
            }
        }
    }
}

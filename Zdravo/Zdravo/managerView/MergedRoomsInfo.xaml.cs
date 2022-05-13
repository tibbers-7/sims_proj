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
    /// Interaction logic for MergedRoomsInfo.xaml
    /// </summary>
    public partial class MergedRoomsInfo : Window
    {
        MergingRoomsViewModel viewModel;
        public MergedRoomsInfo()
        {
            InitializeComponent();
            viewModel = new MergingRoomsViewModel();
            comboNewRoomType.ItemsSource = Enum.GetValues(typeof(RoomType));
            this.DataContext = viewModel;
        }

        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            int firstSelectedRoomId = (int)comboFirstRoomSelection.SelectedItem;
            int secondSelectedRoomId = (int)secondRoomSelection.SelectedItem;
            RoomType newRoomType = (RoomType)comboNewRoomType.SelectedItem;
            
            viewModel.Create(firstSelectedRoomId, secondSelectedRoomId, newRoomType);
            this.Close();
        }
    }
}

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
    /// Interaction logic for SplitedRoomsInfo.xaml
    /// </summary>
    public partial class SplitedRoomsInfo : Window
    {
        private SplitingRoomsViewModel viewModel;
        public SplitedRoomsInfo()
        {
            this.viewModel = new SplitingRoomsViewModel();
            InitializeComponent();
            comboFirstRoomType.ItemsSource = Enum.GetValues(typeof(RoomType));
            comboSecondRoomType.ItemsSource = Enum.GetValues(typeof(RoomType));
            this.DataContext = viewModel;
        }

        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            int selectedRoomId = (int)comboRoomSelection.SelectedItem;
            RoomType firstRoomType = (RoomType)comboFirstRoomType.SelectedItem;
            RoomType secondRoomType = (RoomType)comboSecondRoomType.SelectedItem;
            viewModel.Create(selectedRoomId, firstRoomType, secondRoomType);
            this.Close();
        }
    }
}

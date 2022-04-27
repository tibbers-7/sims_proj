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

namespace Zdravo.DoctorWindows
{
    /// <summary>
    /// Interaction logic for PatientApptHistory.xaml
    /// </summary>
    public partial class PatientApptHistory : Window
    {
        private HistoryViewModel viewModel;

        public PatientApptHistory(int id)
        {
            InitializeComponent();
            viewModel = new HistoryViewModel(id);
            this.DataContext=viewModel;
        }
        private void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            object item = reportTable.SelectedItem;
            viewModel.ShowReport(int.Parse((reportTable.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
        }
    }
}

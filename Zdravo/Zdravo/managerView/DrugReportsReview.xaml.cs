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
    /// Interaction logic for DrugReportsReview.xaml
    /// </summary>
    public partial class DrugReportsReview : Window
    {
        private DrugReportsReviewViewModel viewModel;
        public DrugReportsReview()
        {
            InitializeComponent();
            this.viewModel = new DrugReportsReviewViewModel();
            this.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

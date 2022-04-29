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
using Zdravo.Model;
namespace Zdravo.PatientView
{
    /// <summary>
    /// Interaction logic for AllergenDescription.xaml
    /// </summary>
    public partial class AllergenDescription : Window
    {
        public AllergenDescription(Allergen allergen)
        {
            InitializeComponent();
            tbID.Text=allergen.Id.ToString();
            tbName.Text = allergen.Name;
            tbDescription.Text = allergen.Description;
           
        }
    }
}

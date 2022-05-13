using System.Windows;
using Model;
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

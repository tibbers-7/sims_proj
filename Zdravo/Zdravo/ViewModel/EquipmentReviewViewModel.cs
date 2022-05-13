using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdravo.ViewModel
{
    public class EquipmentReviewViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<StaticEquipment> equipment;
        private EquipmentController equipmentController;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<StaticEquipment> Equipment
        {
            get
            {
                return equipment;
            }
            set
            {
                if (equipment == value)
                    return;
                equipment = equipmentController.GetAll();
                NotifyPropertyChanged("Equipment");
            }
        }

        public EquipmentReviewViewModel() { 
            this.equipmentController = new EquipmentController();
            this.equipment = equipmentController.GetAll();
        }

        public EquipmentReviewViewModel(ObservableCollection<StaticEquipment> equipment)
        {
            this.equipmentController = new EquipmentController();
            this.equipment = equipment;
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

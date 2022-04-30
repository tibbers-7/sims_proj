using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Service;

namespace Zdravo.Controller
{
    public class EquipmentController
    {
        private EquipmentService equipmentService;

        public EquipmentController() { 
            this.equipmentService = new EquipmentService();
        }

        public ObservableCollection<StaticEquipment> GetAll() {
            return equipmentService.GetAll();
        }
    }
}

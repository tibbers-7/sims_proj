using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Repository;

namespace Zdravo.Service
{
    public class EquipmentService
    {
        private EquipmentRepository equipmentRepository;

        public EquipmentService() { 
            this.equipmentRepository = new EquipmentRepository();
        }
        public ObservableCollection<StaticEquipment> GetAll()
        {
            return equipmentRepository.GetAll();
        }
    }
}

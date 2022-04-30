using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.FileHandler;

namespace Zdravo.Repository
{
    public class EquipmentRepository
    {
        private EquipmentFileHandler equipmentFileHandler;

        public EquipmentRepository()
        {
            this.equipmentFileHandler = new EquipmentFileHandler();
        }
        public ObservableCollection<StaticEquipment> GetAll()
        {
            return equipmentFileHandler.Read();
        }
    }
}

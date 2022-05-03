using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Model;
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

        public int AddRelocation(int _equipmentId, int _roomId, DateTime _date, int _amount) {
            Relocation relocation = new Relocation(_equipmentId, _roomId, _date, _amount);
            int _errorCode = equipmentService.AddRelocation(relocation);
            return _errorCode;
        }

        public void Create(string _name, int _amount, int _roomId)
        {
            StaticEquipment newEq = new StaticEquipment(_name, _amount, _roomId);
            equipmentService.Create(newEq);
        }
    }
}

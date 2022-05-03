using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdravo.Model;
using Zdravo.Repository;

namespace Zdravo.Service
{
    public class EquipmentService
    {
        private EquipmentRepository equipmentRepository;
        private RelocationRepository relocationRepository;
        private RoomRepository roomRepository;

        public EquipmentService() { 
            this.equipmentRepository = new EquipmentRepository();
            this.relocationRepository = new RelocationRepository();
            this.roomRepository = new RoomRepository();
        }
        public ObservableCollection<StaticEquipment> GetAll()
        {
            return equipmentRepository.GetAll();
        }
        public int AddRelocation(Relocation _relocation) {
            int _cmp = 0;
            int _errorCode = 0;
            _cmp = DateTime.Compare(_relocation.Date, DateTime.Now);
            if (_cmp < 0) { 
                _errorCode = 1;
            }

            if(_errorCode == 0)
            {
                relocationRepository.Create(_relocation);
            }
            return _errorCode;
        }

        public void Create(StaticEquipment newEq)
        {
            Room room = roomRepository.GetById(newEq.roomId);
            ObservableCollection<int> ids = room.equipmentIds;
            int _id = equipmentRepository.GenerateId();
            newEq.id = _id;
            ids.Add(_id);
            roomRepository.UpdateEquipment(room.id, ids);
            equipmentRepository.Create(newEq);
        }
    }
}

using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Zdravo.Repository;
using Zdravo.ViewModel;

namespace Service
{
    public class TimeService
    {
        private RelocationRepository relocationRepo = new RelocationRepository();
        private RoomRepository roomRepo = new RoomRepository();
        private EquipmentRepository eqRepo = new EquipmentRepository();
        private EquipmentRelocationViewModel viewModel = new EquipmentRelocationViewModel();

        public async void ThreadFunction()
        {
            while (true)
            {

                try
                {
                    foreach (Relocation relocation in relocationRepo.GetAll())
                    {
                        if (DateTime.Compare(relocation.Date, DateTime.Now) <= 0)
                        {
                            roomRepo.RelocateEquipment(relocation);
                            viewModel.Refresh();
                            relocationRepo.Delete(relocation);
                        }
                    }

                }
                catch (Exception e)
                {

                }

                await Task.Delay(TimeSpan.FromMilliseconds(1000));
                //Thread.Sleep(60 * 1000);
            }

        }
    }
}


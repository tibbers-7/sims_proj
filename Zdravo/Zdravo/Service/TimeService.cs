using Repository;
using System;
using System.Threading.Tasks;
using Model;
using Zdravo.ViewModel;
using System.Windows;

namespace Service
{
    public class TimeService
    {
        private RelocationRepository relocationRepo = new RelocationRepository();
        private RoomRepository roomRepo = new RoomRepository();
        private EquipmentRepository eqRepo = new EquipmentRepository();
        private EquipmentRelocationViewModel viewModel = new EquipmentRelocationViewModel();
        private OrderRepository orderRepo= new OrderRepository();
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
                    foreach(Order order in orderRepo.getAllOrders())
                    {
                        if ((DateTime.Now-order.OrderDateTime).TotalHours>=72)
                        {
                            //prebacivanje u magacin
                            StaticEquipment equipment = new StaticEquipment(order.Name, order.Quantity, 7);
                            eqRepo.Create(equipment);
                            Room r = roomRepo.GetById(7);
                            r.equipmentIds.Add(equipment.id);
                            roomRepo.UpdateEquipment(7, r.equipmentIds);
                            orderRepo.deleteOrder(order);
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


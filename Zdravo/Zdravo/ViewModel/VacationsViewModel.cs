using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Model;
using System.ComponentModel;
using Repository;
using Zdravo.SecretaryWindows;
using Controller;
using System.Windows;
using System.Windows.Controls;
using Zdravo.Controller;
using Zdravo.DoctorView;
using Zdravo.DoctorWindows;
namespace Zdravo.ViewModel
{
    public class VacationsViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<VacationRecord> vacationRecords;
        private VacationController vacationController;
        private OrdersWindow parentWindow;
        public ObservableCollection<VacationRecord> VacationRecords
        {
            get
            {
                return vacationRecords;
            }
            set
            {
                if (vacationRecords == value)
                    return;
                vacationRecords = vacationController.getPendingVacationRecords();
                NotifyPropertyChanged("VacationRecords");
            }
        }

        public VacationsViewModel()
        {
            var app = Application.Current as App;
            vacationController = app.vacationController;
            vacationRecords=vacationController.getPendingVacationRecords();
        }
        public void Refresh()
        {
        //    orderRepository = new OrderRepository();
           // orders = orderRepository.getAllOrders();
            parentWindow.DataContext = null;
            parentWindow.DataContext = this;
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

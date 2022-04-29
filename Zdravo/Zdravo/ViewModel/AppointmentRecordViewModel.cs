using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Zdravo.Model;
using System.ComponentModel;
using Repository;
namespace Zdravo.ViewModel
{
    public class AppointmentRecordViewModel
    {
        private ObservableCollection<AppointmentRecord> records;
        // private AllergenService service;
        //     private Patient patient;
        //    private AllergenRepository repo;
        private AppointmentRepository repo;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<AppointmentRecord> Records
        {
            get
            {
                return records;
            }
            set
            {
                if (records == value)
                    return;
                records = repo.GetAllRecords();
                NotifyPropertyChanged("Records");
            }
        }
        public AppointmentRecordViewModel()
        {
            //  service = new AllergenService();
            repo = new AppointmentRepository();
            //   repo=new AllergenRepository();
            records=repo.GetAllRecords();
        }
        public void Refresh()
        {
            records = repo.GetAllRecords();
        }
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

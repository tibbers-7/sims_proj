using System.Collections.ObjectModel;
using Model;
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
        public AppointmentRecordViewModel(ObservableCollection<AppointmentRecord> rec)
        {
            //  service = new AllergenService();

            //   repo=new AllergenRepository();
            repo = new AppointmentRepository();
            records = rec;
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

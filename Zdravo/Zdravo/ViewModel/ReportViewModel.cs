using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdravo.ViewModel
{
    internal class ReportViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DateTime date;
        public DateTime Date { get { return date; } set { date = value; } }
        private string diagnosis;
        public string Diagnosis { get { return diagnosis; } set { diagnosis = value; } }
        private string report;
        public string Report { get { return report; } set { report = value; } }

        public ReportViewModel()
        {
            this.date = DateTime.Now;
        }
    }
}

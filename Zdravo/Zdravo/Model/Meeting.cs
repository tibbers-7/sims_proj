using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Model
{
    public class Meeting
    {
        private int id;
        public int Id => id;

        private string description;

        public string Description=> description;

        private DateOnly date;
        public DateOnly Date => date;

        private string time;

        private string Time => time;

        private ObservableCollection<String> users;
        public ObservableCollection<String> Users => users;

        public Meeting(int id,string description,DateOnly date,string time, ObservableCollection<String> users)
        {
            this.id = id;
            this.date = date;
            this.time= time;
            //popunjavanje liste
        }
    }
}

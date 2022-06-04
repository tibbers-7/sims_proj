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

        private DateOnly date;
        public DateOnly Date => date;

        private TimeOnly time;
        public TimeOnly Time => time;

        private ObservableCollection<User> users;
        public ObservableCollection<User> Users => users;

        public Meeting(int id,DateOnly date,TimeOnly time,List<int> userIds)
        {
            this.id = id;
            this.date = date;
            this.time= time;
            //popunjavanje liste
        }
    }
}

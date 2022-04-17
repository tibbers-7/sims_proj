using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdravo.Model
{
    internal class Prescription
    {
        //TODO: change to class instead of ids
        private int drugId;
        public int DrugId { get { return drugId; } set { drugId = value; } }
        private DateOnly date;
        public DateOnly Date { get { return date; } set { date = value; } }
    }
}

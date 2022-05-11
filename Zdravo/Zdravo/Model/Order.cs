using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdravo.Model
{
    internal class Order
    {
        private int id;
        public int Id => id;

        private string name;
        public String Name => name;

        private int quantity;
        public int Quantity => quantity;

        private DateTime orderDateTime;
        public DateTime OrderDateTime => orderDateTime;

        private string note;
        public string Note => note;

        public Order(int id,string name,int quantity,DateTime orderDateTime,string note)
        {
            this.id = id;
            this.name = name;
            this.quantity = quantity;
            this.orderDateTime = orderDateTime;
            this.note = note;
        }
    }
}

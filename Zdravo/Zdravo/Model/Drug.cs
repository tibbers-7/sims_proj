using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Model
{
    public class Drug
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }
        private string name;
        public string Name { get { return name; } set { name = value; } }
        private string type;
        public string Type { get { return type; } set { type = value; } }
        private Zdravo.Status status;
        public Zdravo.Status Status { get { return status; } set { status = value;} }
        public string StatusString
        {
            get {
                string retVal;
                switch (status)
                {
                    case (Zdravo.Status.accepted):
                        retVal = "ODOBRENO";
                        break;
                    case (Zdravo.Status.denied):
                        retVal = "ODBIJENO";
                        break;
                    default:
                        retVal = "NA ČEKANJU";
                        break;

                }
                return retVal;
            
            }
        }
        private List<string> ingredients;
        public List<string> Ingredients { get { return ingredients; } set { ingredients = value; } }

        public Drug()
        {
            ingredients = new List<string>();
        }

        internal void FromCSV(GroupCollection csvValues)
        {
            id = int.Parse(csvValues[1].Value);
            name = csvValues[2].Value;
            type = csvValues[3].Value;
            switch (csvValues[4].Value)
            {
                case "A":
                    status = Zdravo.Status.accepted;
                    break;
                case "D":
                    status = Zdravo.Status.denied;
                    break;
                default:
                    status = Zdravo.Status.waiting;
                    break;
            }
            string ingredientsAll = csvValues[5].Value;
            string[] ingredientsStrings= ingredientsAll.Split(';');
            foreach(string ingredient in ingredientsStrings)
            {
                ingredients.Add(ingredient);
            }
        }

        internal string ToCSV()
        {
            char statusChar;
            switch (status)
            {
                case Zdravo.Status.accepted:
                    statusChar = 'A';
                    break;
                case Zdravo.Status.denied:
                    statusChar = 'D';
                    break;
                default:
                    statusChar = 'W';
                    break;

            }
            string res = "#" + id.ToString() + "#" + name+ "#" + type + "#" + statusChar + "#";
            foreach (string ingredient in ingredients)
            {
                res=res+ingredient+";";

            }
            return res;

        }


    }
}

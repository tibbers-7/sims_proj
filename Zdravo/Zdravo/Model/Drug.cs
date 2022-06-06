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
        private string description;
        public string Description { get { return description; } set { description = value; } }

        private int alternativeDrugId;
        public int AlternativeDrugId { get { return alternativeDrugId; } set { alternativeDrugId = value; } }
        private bool isAllergic;
        public bool IsAllergic { get { return isAllergic; } set { isAllergic = value; } }
        public List<string> AllergenConflicts;
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
                    case (Zdravo.Status.reported):
                        retVal = "PRIJAVLJENO";
                        break;
                    default:
                        retVal = "NA ČEKANJU";
                        break;

                }
                return retVal;
            
            }

            set { 
                switch (value)
                {
                    case ("ODOBRENO"):
                        status = Zdravo.Status.accepted;
                        break;
                    case ("ODBIJENO"):
                        status = Zdravo.Status.accepted;
                        break;
                    case ("PRIJEVLJENO"):
                        status = Zdravo.Status.reported;
                        break;
                    case ("NA ČEKANJU"):
                        status = Zdravo.Status.waiting;
                        break;
                    default:
                        status = Zdravo.Status.waiting;
                        break;
                } 
            }
        }
        private List<string> ingredients;
        public List<string> Ingredients { get { return ingredients; } set { ingredients = value; } }

        public Drug()
        {
            ingredients = new List<string>();
        }

        public Drug(int id, string name, Zdravo.Status status, string type, string description, List<string> ingredients, int alternativeDrugId)
        {
            this.id = id;
            this.name = name;
            this.status = status; 
            this.type = type;
            this.description = description;
            this.ingredients = ingredients;
            this.alternativeDrugId = alternativeDrugId;
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
                case "R":
                    status=Zdravo.Status.reported;
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
            description=csvValues[6].Value;
            alternativeDrugId= int.Parse(csvValues[7].Value);
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
                case Zdravo.Status.reported:
                    statusChar = 'R';
                    break;
                default:
                    statusChar = 'W';
                    break;

            }
            string ingredientsString = "";
            foreach (string ingredient in ingredients)
            {
                if (ingredient != null)
                {
                    ingredientsString = ingredientsString + ingredient + ";";
                }

            }
            string res = "#" + id.ToString() + "#" + name+ "#" + type + "#" + statusChar + "#"+ingredientsString+"#"+description+"#" + alternativeDrugId.ToString();
            
            return res;

        }


    }
}

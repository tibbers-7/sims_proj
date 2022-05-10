using System.Text.RegularExpressions;

namespace Model
{
    public class Drug
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }
        private string name;
        public string Name { get { return name; } set { name = value; } }
        private string[] ingredients;
        public string[] Ingredients { get { return ingredients; } set { ingredients = value; } }

        internal void FromCSV(GroupCollection csvValues)
        {
            id = int.Parse(csvValues[1].Value);
            name = csvValues[2].Value;
            string ingredientsString = csvValues[3].Value;
            ingredients=ingredientsString.Split(';');
        }

        internal string ToCSV()
        {
            string res = "#" + id.ToString() + "#" + name+ "#";
            foreach (string ingredient in ingredients)
            {
                res=res+ingredient+";";

            }
            return res;

        }


    }
}

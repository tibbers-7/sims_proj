using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Zdravo
{
    public class RequiredFieldValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            
            var s = value as string;
            if (s.Equals("")) { return new ValidationResult(false, "*"); }
            return new ValidationResult(true, null);

        }
    }
    public class NumericValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                double r;
                if (double.TryParse(s, out r) | s.Equals(""))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Polje mora sadrži samo cifre.");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }

    public class MinMaxValidation : ValidationRule
    {
        public double Min
        {
            get;
            set;
        }

        public double Max
        {
            get;
            set;
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value is int)
            {
                int num = (int)value;
                if (num < Min) return new ValidationResult(false, "Ukucajte veći broj.");
                if (num > Max) return new ValidationResult(false, "Ukucajte manji broj.");
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Unknown error occured.");
            }

            
        }
    }
}

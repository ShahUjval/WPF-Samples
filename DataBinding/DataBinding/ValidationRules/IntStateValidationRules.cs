using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataBinding.ValidationRules
{
    public class IntStateValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int _intValue;

            if(Int32.TryParse(value.ToString(),out _intValue))
            {
                if(_intValue > 10)
                { 
                    return new ValidationResult(true , "");
                }
                else
                {
                    return new ValidationResult(false,"Int value out-of-range");
                }
            }

            return new ValidationResult(false,"Not a Valid Number");
        }
    }
}



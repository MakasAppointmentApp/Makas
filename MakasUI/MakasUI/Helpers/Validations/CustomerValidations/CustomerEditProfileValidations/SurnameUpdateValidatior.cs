using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Helpers.Validations.CustomerValidations.CustomerEditProfileValidations
{
    public class SurnameUpdateValidatior : IValidator
    {
        public string Validate(string field)
        {
            if (field.Length <= 0 || field == "")
            {
                return "Güncelleme için Name ve Surname boş bıraklımaz.";
            }
            return null; 
        }
    }
}

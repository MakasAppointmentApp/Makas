using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MakasUI.Helpers.Validations.CustomerValidations.CustomerEditProfileValidations
{
    public class EmailUpdateValidator : IValidator
    {
        public string Validate(string field)
        {
            var emailPattern = @"^\s*[\w\-\+_']+(\.[\w\-\+_']+)*\@[A-Za-z0-9]([\w\.-]*[A-Za-z0-9])?\.[A-Za-z][A-Za-z\.]*[A-Za-z]$";

            if (field.Length<=0 || field == "")
            {
                return "Güncellemek için Email boş bırakılamaz.";
            }
            else if (Regex.IsMatch(field, emailPattern))
            {
                return null;
            }
            else
            {
                return "Güncellemek için Email'e özel karakterleri giriniz";
            }
        }
    }
}

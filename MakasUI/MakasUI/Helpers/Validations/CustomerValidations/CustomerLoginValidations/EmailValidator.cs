using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MakasUI.Helpers.Validations.CustomerValidations.CustomerLogin
{
    public class EmailValidator : IValidator
    {
        public string Validate(string field)
        {
            
            var emailPattern = @"^\s*[\w\-\+_']+(\.[\w\-\+_']+)*\@[A-Za-z0-9]([\w\.-]*[A-Za-z0-9])?\.[A-Za-z][A-Za-z\.]*[A-Za-z]$";

            if (field == null || field == "")
            {
                return "Giriş için Email boş bırakılamaz.";
            }
            else if (field.Length < 5)
            {
                return "Email en az 5 karaekterli olmadlıdır.";
            }
            else if (Regex.IsMatch(field, emailPattern))
            {
                return null;
            }
            else
            {
                return "Email için özel karakterleri giriniz";
            }

        }
    }
}

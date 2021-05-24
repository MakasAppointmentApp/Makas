using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MakasUI.Helpers.Validations.SaloonValidations.SaloonRegisterValidations
{
    public class EmailValidator : IValidator
    {
        public string Validate(string field)
        {
            var emailPattern = @"^\s*[\w\-\+_']+(\.[\w\-\+_']+)*\@[A-Za-z0-9]([\w\.-]*[A-Za-z0-9])?\.[A-Za-z][A-Za-z\.]*[A-Za-z]$";

            if (field == null)
            {
                return "Kayıt için Email boş bırakılamaz.";
            }
            else if (field.Length < 5)
            {
                return "Kayıt için Email en az 5 karaekterli olmadlıdır.";
            }
            else if (Regex.IsMatch(field, emailPattern))
            {
                return "";
            }
            else
            {
                return "Kayıt Email için özel karakterleri giriniz";
            }

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Helpers.Validations.SaloonValidations.SaloonRegisterValidations
{
    public class PasswordVerifyValidator : IValidator
    {
        public string Validate(string field)
        {
            if (field == null)
            {
                return "Kayıt için Girdiğiniz Password uyuşmamaktadır";
            }
            return null;
        }
    }
}

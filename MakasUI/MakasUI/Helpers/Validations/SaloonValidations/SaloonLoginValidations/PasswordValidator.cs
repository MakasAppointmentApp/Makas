using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Helpers.Validations.SaloonValidations.SaloonLoginValidations
{
    public class PasswordValidator : IValidator
    {
        public string Validate(string field)
        {
            if (field == null)
            {
                return "Giriş için Password boş bırakılamaz.";
            }
            return null;
        }
    }
}

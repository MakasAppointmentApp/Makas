using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Helpers.Validations.CustomerValidations.CustomerLogin
{
    public class PasswordValidator : IValidator
    {
        
        public string Validate(string field)
        {
            if (field == null || field == "")
            {
                return "Giriş için Password boş bıraklımaz.";
            }
            return null;
        }
    }
}

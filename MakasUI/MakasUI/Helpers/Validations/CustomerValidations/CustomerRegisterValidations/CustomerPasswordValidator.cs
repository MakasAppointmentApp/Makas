using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Helpers.Validations.CustomerValidations.CustomerRegisterValidations
{
    public class CustomerPasswordValidator : IValidator
    {
        public string Validate(string field)
        {
            if (field == null || field == "")
            {
                return "Kayıt için Password boş bıraklımaz.";
            }
            return null;
        }
    }
}

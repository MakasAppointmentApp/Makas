using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Helpers.Validations.CustomerValidations.CustomerRegisterValidations
{
    public class CustomerNameValidator : IValidator
    {
        public string Validate(string field)
        {
            if (field == null || field == "")
            {
                return "Kayıt için Kullanıcı Adı boş bıraklımaz.";
            }
          
            return null;
        }
    }
}

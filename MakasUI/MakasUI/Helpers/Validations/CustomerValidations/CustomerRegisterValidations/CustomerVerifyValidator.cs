using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Helpers.Validations.CustomerValidations.CustomerRegisterValidations
{
    public class CustomerVerifyValidator : IValidator
    {
        public string Validate(string field)
        {
            if (field == null || field == "")
            {
                return "Kayıt için Şifre Tekrarı boş bırakılamaz";
            }
            return null;
        }
    }
}

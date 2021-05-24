using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Helpers.Validations.CustomerValidations.CustomerEditProfileValidations
{
    public class OldPasswordValidatior : IValidator
    {
        public string Validate(string field)
        {
            if (field == null || field == "")
            {
                return "Güncelleme için Eski Şifre boş bırakılamaz";
            }    
                       
            return null;
        }
    }
}

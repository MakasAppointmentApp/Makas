using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Helpers.Validations.CustomerValidations.CustomerEditProfileValidations
{
    public class NewPasswordValidatior : IValidator
    {
        public string Validate(string field)
        {
            if (field == null || field == "")
            {
                return "Güncelleme için Yeni Şifre ve Şİfre Tekrarı Alanları girilmelidir";
            }
            return null;
        }
    }
}

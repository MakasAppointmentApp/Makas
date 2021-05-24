using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Helpers.Validations.CustomerValidations.CustomerEditProfileValidations
{
    public class VeriyfPasswordValidatior : IValidator
    {
        public string Validate(string field)
        {
            if (field == null || field == "")
            {
                return "Güncelleme için Yeni Şifre Tekrarı boş bırakılamaz.";
            }
            return null;
        }
    }
}

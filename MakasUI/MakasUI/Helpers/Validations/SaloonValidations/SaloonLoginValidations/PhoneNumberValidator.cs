using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Helpers.Validations.SaloonValidations.SaloonLoginValidations
{
    public class PhoneNumberValidator : IValidator
    {
        public string Validate(string field)
        {
            if (field == null)
            {
                return "Giriş için Telefon numarası boş bırakılamaz";
            }
            else if (field.Length<11)
            {
                return "Giriş için telefon numarası 11 rakamdan az olamaz!";
            }
          
            return null;
        }
    }
}

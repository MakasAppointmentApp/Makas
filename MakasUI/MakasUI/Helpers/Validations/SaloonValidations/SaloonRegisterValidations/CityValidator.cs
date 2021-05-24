using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Helpers.Validations.SaloonValidations.SaloonRegisterValidations
{
    public class CityValidator : IValidator
    {
        public string Validate(string field)
        {
            if (field == null)
            {
                return "Kayıt için Şehir alanı boş bırakılamaz.";
            }

            return null;
        }
    }
}

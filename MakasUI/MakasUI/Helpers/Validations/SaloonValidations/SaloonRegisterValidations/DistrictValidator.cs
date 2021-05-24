using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Helpers.Validations.SaloonValidations.SaloonRegisterValidations
{
    public class DistrictValidator : IValidator
    {
        public string Validate(string field)
        {
            if (field == null)
            {
                return "Kayıt için İlçe alanı boş bırakılamaz.";
            }

            return null;
        }
    }
}

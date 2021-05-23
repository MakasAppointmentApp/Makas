using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Helpers.Validations.SaloonValidations.SaloonRegisterValidations
{
    public class SaloonNameValidator : IValidator
    {
        public string Validate(string field)
        {
            if (field == null)
            {
                return "Kayıt için Salon ismi boş bırakılamaz.";
            }
            return null;
        }
    }
}

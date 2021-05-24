using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Helpers.Validations.SaloonValidations.SaloonRegisterValidations
{
    public class GenderValidator : IValidator
    {
        public string Validate(string field)
        {
            if (field == null)
            {
                return "Kayot için Cinsiyet alanı boş bırakılamaz.";
            }
            return null;
        }
    }
}

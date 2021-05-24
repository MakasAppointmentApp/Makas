using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Helpers.Validations.CustomerValidations.CustomerRateValidations
{
    public class CustomerRateValidator : IValidator
    {
        public string Validate(string field)
        {
            if (field == null || field == "")
            {
                return "Kuaföre puan verilmelidir!";
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Helpers.Validations.CustomerValidations.CustomerRateValidations
{
    public class CustomerCommentValidator : IValidator
    {
        public string Validate(string field)
        {
            if (field == null || field == "")
            {
                return "Kuaföre yorum yapılmalıdır!";          
            }
            return null;
        }
    }
}

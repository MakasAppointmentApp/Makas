using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Helpers.Validations
{
    public interface IValidator
    {
        string Validate(string field);
    
    }
}

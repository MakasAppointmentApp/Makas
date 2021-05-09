using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Models.DtosForCustomer
{
    class UpdateCustomerPasswordDto
    {
        public int Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}

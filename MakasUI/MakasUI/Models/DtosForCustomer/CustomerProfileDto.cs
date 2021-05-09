using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Models.DtosForCustomer
{
    class CustomerProfileDto
    {
        public string CustomerEmail { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPasswordSalt { get; set; }
        public string CustomerPasswordHash { get; set; }
    }
}

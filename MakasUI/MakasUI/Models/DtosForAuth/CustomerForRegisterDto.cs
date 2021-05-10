using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Models.DtosForAuth
{
    public class CustomerForRegisterDto
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPassword { get; set; }
    }
}

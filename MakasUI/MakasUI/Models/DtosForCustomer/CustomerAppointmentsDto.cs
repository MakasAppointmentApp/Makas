using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Models.DtosForCustomer
{
    public class CustomerAppointmentsDto
    {
        public int Id { get; set; }
        public string SaloonName { get; set; }
        public DateTime Date { get; set; }
        public double SaloonRate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Models.DtosForCustomer
{
    public class AddAppointmentDto
    {
        public int CustomerId { get; set; }
        public int SaloonId { get; set; }
        public int WorkerId { get; set; }
        public DateTime Date { get; set; }
    }
}

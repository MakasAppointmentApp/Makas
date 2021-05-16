using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Models.DtosForCustomer
{
    public class ReviewDto
    {
        public int CustomerId { get; set; }
        public int SaloonId { get; set; }
        public int WorkerId { get; set; }
        public int AppointmentId { get; set; }
        public string reviewControl { get; set; }
        public string SaloonName { get; set; }
        public string WorkerName { get; set; }
        public double SaloonRate { get; set; }
    }
}

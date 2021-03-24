using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Models
{
    public class Appointment
    {
        public string SaloonName { get; set; }
        public string WorkerName { get; set; }
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
        public string Review { get; set; }
        public double Rate { get; set; }
    }
}

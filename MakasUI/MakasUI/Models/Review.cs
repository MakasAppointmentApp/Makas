using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int SaloonId { get; set; }
        public int WorkerId { get; set; }
        public int AppointmentId { get; set; }
        public double Rate { get; set; }
        public string Comment { get; set; }

        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public Saloon Saloon { get; set; }
        public Worker Worker { get; set; }
        public Appointment Appointment { get; set; }
    }
}

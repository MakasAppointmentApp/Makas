using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Models.DtosForCustomer
{
    public class CustomerAppointmentsDto
    {
        public int Id { get; set; }
        public int SaloonId { get; set; }
        public int WorkerId { get; set; }
        public string ReviewControl { get; set; }
        public int AppointmentId { get; set; }
        public string SaloonName { get; set; }
        public string WorkerName { get; set; }
        public DateTime Date { get; set; }
        public double SaloonRate { get; set; }

        public string ButtonImage { get; set; }
    }
}

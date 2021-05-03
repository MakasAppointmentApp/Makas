using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Models
{
    public class Worker
    {
        public Worker()
        {
            //Reviews = new List<Review>();
            Appointments = new List<Appointment>();
        }
        public int Id { get; set; }
        public int SaloonId { get; set; }
        public string WorkerName { get; set; }
        public byte[] WorkerPhoto { get; set; }
        public double WorkerRate { get; set; }
        public Saloon Saloon { get; set; }

        //public List<Review> Reviews { get; set; }
        public string WorkerImage { get; set; }//Bu gereksiz statik veriler bozulmasın diye duruyors silinecek
        public List<Appointment> Appointments { get; set; }
    }
}

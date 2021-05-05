using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Models
{
    public class Saloon
    {
        public Saloon()
        {
            Workers = new List<Worker>();
            Reviews = new List<Review>();
            Prices = new List<Price>();
            Appointments = new List<Appointment>();
        }
        public int Id { get; set; }
        public string SaloonName { get; set; }
        public string SaloonEmail { get; set; }
        public string SaloonPhone { get; set; }
        public bool SaloonGender { get; set; }
        public string SaloonCity { get; set; }
        public string SaloonDistrict { get; set; }
        public byte[] SaloonPasswordHash { get; set; }
        public byte[] SaloonPasswordSalt { get; set; }
        public string SaloonLocation { get; set; }
        public byte[] SaloonImage { get; set; }
        public double SaloonRate { get; set; }

        public List<Worker> Workers { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Price> Prices { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}

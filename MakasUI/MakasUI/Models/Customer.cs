using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Models
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string Date { get; set; }
        public Customer()
        {
            Reviews = new List<Review>();
            Favorites = new List<Favorite>();
            Appointments = new List<Appointment>();
        }
        public int Id { get; set; }
        public string CustomerEmail { get; set; }

        public byte[] CustomerPasswordHash { get; set; }
        public byte[] CustomerPasswordSalt { get; set; }

        public List<Review> Reviews { get; set; }
        public List<Favorite> Favorites { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}

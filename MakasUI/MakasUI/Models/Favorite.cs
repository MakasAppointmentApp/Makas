using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int SaloonId { get; set; }

        public Customer Customer { get; set; }
        public Saloon Saloon { get; set; }
    }
}

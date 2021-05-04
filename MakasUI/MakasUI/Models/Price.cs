﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Models
{
    public class Price
    {
        public int Id { get; set; }
        public int SaloonId { get; set; }
        public string PriceName { get; set; }
        public double PriceAmount { get; set; }
        public Saloon Saloon { get; set; }
    }
}

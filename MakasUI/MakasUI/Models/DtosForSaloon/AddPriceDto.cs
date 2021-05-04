using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Models.DtosForSaloon
{
    public class AddPriceDto
    {
        public int SaloonId { get; set; }
        public string PriceName { get; set; }
        public double PriceAmount { get; set; }
    }
}

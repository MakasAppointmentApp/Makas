using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Models.DtosForCustomer
{
    public class CustomerFavoritesDto
    {
        public int Id { get; set; }
        public int SaloonId { get; set; }
        public string SaloonName { get; set; }
        public byte[] SaloonImage { get; set; }
        public double SaloonRate { get; set; }
    }
}

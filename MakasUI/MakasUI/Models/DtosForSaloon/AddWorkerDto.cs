using System;
using System.Collections.Generic;
using System.Text;

namespace MakasUI.Models.DtosForSaloon
{
    public class AddWorkerDto
    {
        public int SaloonId { get; set; }
        public string WorkerName { get; set; }
        public byte[] WorkerPhoto { get; set; }
    }
}

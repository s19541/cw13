using Cwiczenia13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia13.Requests
{
    public class OrderRequest
    {
        public DateTime DataPrzyjecia { get; set; }
        public string Uwagi { get; set; }
        public ICollection<WyrobRequest> Wyroby { get; set; }
    }
}

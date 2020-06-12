using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia13.Models
{
    public class WyrobCukierniczy
    {
        public int IdWyrobuCukierniczego { get; set; }
        public string Nazwa { get; set; }
        public float CenaZaSzt { get; set; }
        public string Typ { get; set; }
        public virtual ICollection<Zamowienie_WyrobCukierniczy> OrdersProducts { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia13.Models
{
    public class Zamowienie_WyrobCukierniczy
    {
        public int IdWyrobuCukierniczego { get; set; }
        public int IdZamowienia { get; set; }
        public int Ilosc { get; set; }
        public string Uwagi { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }
        public virtual WyrobCukierniczy WyrobCukierniczy { get; set; }
    }
}

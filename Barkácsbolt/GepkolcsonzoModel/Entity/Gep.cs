using System;
using System.Collections.Generic;
using System.Text;

namespace GepkolcsonzoModel.Entity
{
    public class Gep
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Modell { get; set; }
        public int Teljesitmeny { get; set; }
        public float Suly { get; set; }
        public int Mennyiseg { get; set; }
        public int Ar { get; set; }
        public string Kep { get; set; }

        public Gep() { }

        public Gep(int id,string marka,string modell,int teljesitmeny,float suly,int mennyiseg,int ar,string kep)
        {
            Id = id;
            Marka = marka;
            Modell = modell;
            Teljesitmeny = teljesitmeny;
            Suly = suly;
            Mennyiseg = mennyiseg;
            Ar = ar;
            Kep = kep;
        }

        public Gep(Gep gep)
        {
            Id = gep.Id;
            Marka = gep.Marka;
            Modell = gep.Modell;
            Teljesitmeny = gep.Teljesitmeny;
            Suly = gep.Suly;
            Mennyiseg = gep.Mennyiseg;
            Ar = gep.Ar;
            Kep = gep.Kep;
        }
    }
}

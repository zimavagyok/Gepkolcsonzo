using System;
using System.Collections.Generic;
using System.Text;

namespace GepkolcsonzoModel.Entity
{
    public class Osszekotes
    {
        public int ID { get; set; }
        public int UgyfelID { get; set; }
        public int GepID { get; set; }
        public DateTime Datum { get; set; }
        public DateTime Meddig { get; set; }
        public int Darab { get; set; }
        public int TeljesAr { get; set; }

        public Osszekotes() { }

        public Osszekotes(int id,int ugyfelid, int gepid, DateTime datum, int darab, DateTime meddig,int teljesar)
        {
            ID = id;
            UgyfelID = ugyfelid;
            GepID = gepid;
            Datum = datum;
            Darab = darab;
            Meddig = meddig;
            TeljesAr = teljesar;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS_Sistemi
{
    abstract class Ogrenci
    {
        private int ogrid;
        private string ogradi;
        private string ogrsoyadi;
        private string ogrbolumu;

        public int OgrID
        {
            get { return ogrid; }
            set { ogrid = value; }
        }
        public string OgrAd
        {
            get { return ogradi; }
            set { ogradi = value; }
        }
        public string OgrSoyad
        {
            get { return ogrsoyadi; }
            set { ogrsoyadi = value; }
        }
        public string OgrBolum
        {
            get { return ogrbolumu; }
            set { ogrbolumu = value; }
        }


        public Ogrenci(int ID,string ad,string soyad,string bolum)
        {
            ogrid = ID;
            ogradi = ad;
            ogrsoyadi = soyad;
            ogrbolumu = bolum;
        }
    }
}

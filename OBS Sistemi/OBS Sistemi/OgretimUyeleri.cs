using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS_Sistemi
{
    class OgretimUyeleri
    {
        private int ouid;
        private string ouad;
        private string ousoyad;

        public int OuID
        {
            get { return ouid; }
            set { ouid = value; }
        }
        public string OuAd
        {
            get { return ouad; }
            set { ouad = value; }
        }
        public string OuSoyad
        {
            get { return ousoyad; }
            set { ousoyad = value; }
        }

        public OgretimUyeleri(int ID,string Ad,string Soyad)
        {
            ouid = ID;
            ouad = Ad;
            ousoyad = Soyad;

        }

       

    }
}

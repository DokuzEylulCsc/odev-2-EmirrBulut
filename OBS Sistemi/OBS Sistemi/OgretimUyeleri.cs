using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS_Sistemi
{
    class OgretimUyeleri
    {
        public Dictionary<int, Ders> OgretimGorevlisininDersleri = new Dictionary<int, Ders>();
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

        public void OgretimGorevlisineDersEkle(int DersID,string DersAdi)
        {
            try
            {
                OgretimGorevlisininDersleri.Add(DersID, new Ders(DersID, DersAdi));
            }
            catch (ArgumentException)
            {

                throw new ArgumentException("Bu ders bu ogretim gorevlisine zaten eklenmis !!");
            }
        }


        public void OgretimGorevlisindenDersSil(int DersID)
        {
            try
            {
                OgretimGorevlisininDersleri.Remove(DersID);
            }
            catch (ArgumentException)
            {

                throw new ArgumentException("Silmek istediginiz ders bulunamadi");
            }
        }
       

    }
}

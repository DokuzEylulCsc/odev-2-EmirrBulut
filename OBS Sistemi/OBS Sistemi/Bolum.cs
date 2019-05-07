using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS_Sistemi
{
    class Bolum
    {
        public Dictionary<int, Ogrenci> BolumeKayitliOgrenciler = new Dictionary<int, Ogrenci>();
        public Dictionary<int, OgretimUyeleri> KayitliOgretimUyeleri = new Dictionary<int, OgretimUyeleri>();
        public Dictionary<int, Ders> KayıtlıDersler = new Dictionary<int, Ders>();

        private int bolumid;
        private string bolumadi;

        public int BolumID
        {
            get { return bolumid; }
            set { bolumid = value; }
        }
        public string BolumAdi
        {
            get { return bolumadi; }
            set { bolumadi = value; }
        }

        public Bolum(int ID,string Ad)
        {
            bolumid = ID;
            bolumadi = Ad;
        }

        public void OgretimGorevlisiEkle(int ID,string Ad,string Soyad)
        {
            try
            {
                KayitliOgretimUyeleri.Add(ID, new OgretimUyeleri(ID, Ad, Soyad));
            }
            catch (ArgumentException)
            {

                throw new ArgumentException("Eklemek istediginiz ogretim gorevlisi zaten eklenmis !!");

            }
        }

        public void OgretimGorevlisiSil(int ID)
        {
            try
            {
                KayitliOgretimUyeleri.Remove(ID);
            }
            catch (ArgumentException)
            {

                throw new ArgumentException("Silmek istediginiz ogretim uyesi kayıtlı degil !!");
            }
        }

        public void DersEkle(int DersID,string DersAdi,string HocaAdi)
        {
            try
            {
                KayıtlıDersler.Add(DersID, new Ders(DersID, DersAdi));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

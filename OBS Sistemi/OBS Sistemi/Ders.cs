using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS_Sistemi
{
    class Ders
    {
        public Dictionary<int, Ogrenci> DerseKayitliOgrenciler = new Dictionary<int, Ogrenci>();

        private int dersid;
        private string dersadi;
        
        public int DersID
        {
            get { return dersid; }
            set { dersid = value; }
        }
        public string DersAdi
        {
            get { return dersadi; }
            set { dersadi = value; }
        }

        public Ders(int ID,string Ad)
        {
            dersid = ID;
            dersadi = Ad;
        }

        public void DerseOgrenciEkle(int OgrId,string OgrAd,string OgrSoyad,string OgrBolum,string belirtec)
        {
            try
            {
                if (belirtec == "Lisans")
                {
                    DerseKayitliOgrenciler.Add(OgrId, new LisansOgrencisi(OgrId, OgrAd, OgrSoyad, OgrBolum));
                }
                else if (belirtec == "Yuksek")
                {
                    DerseKayitliOgrenciler.Add(OgrId, new YuksekLisansOgrencisi(OgrId, OgrAd, OgrSoyad, OgrBolum));
                }
                else if (belirtec == "Doktora")
                {
                    DerseKayitliOgrenciler.Add(OgrId, new DoktoraOgrencisi(OgrId, OgrAd, OgrSoyad, OgrBolum));
                }
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Kaydetmek istediginiz ogrenci zaten mevcut");
            }
        }

        public void DerstenOgrenciSi(int OgrID)
        {
            try
            {
                DerseKayitliOgrenciler.Remove(OgrID);
            }
            catch (ArgumentException)
            {

                throw new ArgumentException("Silmek istediginiz ogrenci mevcut degil :(");
            }
        }

    }
}

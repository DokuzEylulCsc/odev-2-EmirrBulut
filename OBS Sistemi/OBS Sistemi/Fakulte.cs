using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS_Sistemi
{
    class Fakulte
    {
        public Dictionary<int, Bolum> Bolumler = new Dictionary<int, Bolum>();
        private int fakulteid;
        private string fakultead;

        public int FakulteId
        {
            get { return fakulteid; }
            set { fakulteid = value; }
        }
        public string FakulteAd
        {
            get { return fakultead; }
            set { fakultead = value; }
        }

        public Fakulte(int ID, string Ad)
        {
            fakulteid = ID;
            fakultead = Ad;
        }

        public void BolumEkle(int BolumID,string BolumAd)
        {
            try
            {
                Bolumler.Add(BolumID, new Bolum(BolumID, BolumAd));
            }
            catch (ArgumentException)
            {

                throw new ArgumentException("Eklemek istediginiz bolum mevcut !!");
            }
        }

        public void BolumSil(int BolumID)
        {
            try
            {
                Bolumler.Remove(BolumID);
            }
            catch (ArgumentException)
            {

                throw new ArgumentException("Silmek istediginiz bolum mecvut degil !!");
            }
        }
    }
}

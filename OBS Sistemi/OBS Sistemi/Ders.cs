using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS_Sistemi
{
    class Ders
    {
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

    }
}

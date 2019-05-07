using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS_Sistemi
{
    class Universite
    {
        public static Dictionary<int, Fakulte> Fakulteler = new Dictionary<int, Fakulte>();

        private Universite()
        {
            // Singleton kullanımında new keywordunu saf dısı bırakabılmek ıcın private const. tanımladım
        }
        private static Universite instance;

        public static Universite Instance
        {           
            get
            {
                if (instance == null)
                {
                    instance = new Universite();
                }
                return instance;
            }
        }

        public void FakulteEkle(int FakulteId,string FakulteAd)// Fakulte Ekleme metodu.
        {
            try
            {
                Fakulteler.Add(FakulteId,new Fakulte(FakulteId,FakulteAd)); 
            }
            catch (ArgumentException)
            {

                throw new ArgumentException("Eklemek istenen fakulte mevcut");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBS_Sistemi
{
    public partial class BilgilendirmeFormu : Form
    {
        public BilgilendirmeFormu()
        {
            InitializeComponent();
        }
        public int BFakulteID, BBolum;
        

        private void Txt_BilgilendirmeFakulteID_TextChanged(object sender, EventArgs e)
        {
            groupBox4.Enabled = true;
        }

        private void Btn_Fakultelerigetir_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Fakulte item in Universite.Fakulteler.Values)
                {
                    Lst_BilgilendirmeFakulteler.Items.Add("Fakulte Adi :" + "  " + item.FakulteId + " ---- " + "Fakulte ID : " + item.FakulteAd);

                }
            }
            catch (ArgumentException)
            {

                throw new ArgumentException("Kayıtlı Fakulte Yok !!");
            }
        }

        private void Btn_BilgilendirmeBolumler_Click(object sender, EventArgs e)
        {
            Lst_BilgilendirmeBolumler.Items.Clear();
            BFakulteID = Convert.ToInt16(Txt_BilgilendirmeFakulteID.Text);
            try
            {
                foreach (Bolum item in Universite.Fakulteler[BFakulteID].Bolumler.Values)
                {
                    Lst_BilgilendirmeBolumler.Items.Add(" Bolum :" + " " + item.BolumAdi + " " + "ID : " + " " + item.BolumID);
                }
            }
            catch (ArgumentException)
            {

                throw new ArgumentException("Kayıtlı Bolum Yok !!");
            }
        }

        private void Btn_OgrencileriGoster_Click(object sender, EventArgs e)
        {
            Lst_BolumunOgr.Items.Clear();
            BFakulteID = Convert.ToInt16(Txt_BilgilendirmeFakulteID.Text);
            try
            {
                foreach (Ogrenci item in Universite.Fakulteler[BFakulteID].Bolumler[BBolum].BolumeKayitliOgrenciler.Values)
                {
                    Lst_BolumunOgr.Items.Add("Ogrenci :" + " " + item.OgrAd + " " + item.OgrSoyad + " --- " + "ID :" + " " + item.OgrID);
                }
            }
            catch (ArgumentException)
            {

                throw new ArgumentException("Kayıtlı ogrenci yok !!");
            }
        }

        private void Btn_BilgilendirmeDersOgrencileri_Click(object sender, EventArgs e)
        {
            BFakulteID = Convert.ToInt16(Txt_BilgilendirmeFakulteID.Text);
            BBolum = Convert.ToInt16(Txt_BilgilendirmeBolumID.Text);
            foreach (Ogrenci item in Universite.Fakulteler[BFakulteID].Bolumler[BBolum].)
            {

            }
        }

        private void Btn_HocalarıGoster_Click(object sender, EventArgs e)
        {          
            Lst_BolumunOG.Items.Clear();
            BFakulteID = Convert.ToInt16(Txt_BilgilendirmeFakulteID.Text);
            try
            {
                foreach (OgretimUyeleri item in Universite.Fakulteler[BFakulteID].Bolumler[BBolum].KayitliOgretimUyeleri.Values)
                {
                    Lst_BolumunOG.Items.Add("Ogretim Gorevlisi :" + " " + item.OuAd + " " + item.OuSoyad + " " + "ID :" + " " + item.OuID);
                }
            }
            catch (ArgumentException)
            {

                throw new ArgumentException("Kayıtlı ogretim gorevlisi yok !!");
            }
        }


    }
}

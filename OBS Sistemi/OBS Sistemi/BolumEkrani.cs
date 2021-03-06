﻿using System;
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
    public partial class BolumEkrani : Form
    {
        public BolumEkrani()
        {
            InitializeComponent();
        }

        public static int BolumIslemID; // Ders ekleme, ogretim uyesi ekleme,ogrenci ekleme islemlerini yapmak ıstedıgımız bolumun ıdsini static tutuyoruz cunku
        // diger formlardan sabit olarak ıslem yapmak ıstedıgımız bolume ulasabilmemiz gerekiyor. Dolayısıyla bu bolumu statıc tutarak hep bu bolume ulasabılıyoruz.

        private void Btn_BolumEkle_Click(object sender, EventArgs e) // Bolum ekleme butonu
        {
            if (Txt_BolumID.Text != "" && Txt_BolumAdi.Text != "")
            {
                Universite.Fakulteler[FakulteEkrani.FakulteIslemID].BolumEkle(Convert.ToInt16(Txt_BolumID.Text), Txt_BolumAdi.Text);
            }
            else
            {
                MessageBox.Show("Once bir sey girmeniz gerekiyor", "Hata", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }    
        }

        private void Btn_TekrarBolumEkle_Click(object sender, EventArgs e)
        {
            Txt_BolumID.Text = "";
            Txt_BolumAdi.Text = "";
            Txt_BolumID.Focus();
        }

        private void Btn_BolumleriGoster_Click(object sender, EventArgs e) // Kayıtlı bolumlerı gosterebılme butonu
        {
            Lst_KayitliBolumler.Items.Clear();
            try
            {
                foreach (Bolum item in Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler.Values)
                {
                    Lst_KayitliBolumler.Items.Add( " Bolum :" + " " + item.BolumAdi + " " + "ID : " + " " + item.BolumID);
                }
            }
            catch (ArgumentException)
            {

                throw new ArgumentException("Kayıtlı Bolum Yok !!");
            }
        }

        private void Btn_BolumSil_Click(object sender, EventArgs e) // Bolum sılebilmek icin basılması gereken buton
        {
            try
            {
                if (Txt_BolumSil.Text != "")
                {
                    Universite.Fakulteler[FakulteEkrani.FakulteIslemID].BolumSil(Convert.ToInt16(Txt_BolumSil.Text));
                    
                }
            }
            catch (Exception)
            {

                throw new Exception("Silmek istediginiz bolum mevcut degil !!");
            }
        }

        private void Btn_TekrarBolumSil_Click(object sender, EventArgs e) // Tekrar bolum sılme islemi 
        {
            Txt_BolumSil.Text = "";
            Txt_BolumSil.Focus();
        }

        private void Btn_Cıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void Btn_Ileri_Click(object sender, EventArgs e) // Ogretim uyeleri ekranına gecebilme butonu
        {
            if (Txt_Bolumİslem.Text != "")
            {
                BolumIslemID = Convert.ToInt16(Txt_Bolumİslem.Text);
                Bolum gereksiz;                               
                if (Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler.TryGetValue(BolumIslemID,out gereksiz))
                  {
                    this.Hide();
                    OgretimUyeleriEkrani o = new OgretimUyeleriEkrani();
                    o.Show();
                }
                else
                {
                    MessageBox.Show("Sectiginiz ID'ye sahip bolum bulunmamaktadır. Lutfen Tekrar Deneyin !!");
                }
            }
            else
            {
                MessageBox.Show("Once Islem yapılacak Bolumu secmelisiniz", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }

        private void Btn_Bilgilendirme_Click(object sender, EventArgs e)
        {
            BilgilendirmeFormu b = new BilgilendirmeFormu();
            b.Show();
        }
    }
}

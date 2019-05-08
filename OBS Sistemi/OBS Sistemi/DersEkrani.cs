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
    public partial class DersEkrani : Form
    {
        public DersEkrani()
        {
            InitializeComponent();
        }

        private void Btn_DersEkle_Click(object sender, EventArgs e)
        {
            if (Txt_DersAdi.Text != "" && Txt_DersId.Text != "")
            {
                Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler[BolumEkrani.BolumIslemID].KayitliOgretimUyeleri[OgretimUyeleriEkrani.HocaIslemID].OgretimGorevlisineDersEkle(Convert.ToInt16(Txt_DersId.Text), Txt_DersAdi.Text);
                Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler[BolumEkrani.BolumIslemID].DersEkle(Convert.ToInt16(Txt_DersId.Text), Txt_DersAdi.Text); // Bolume Ders Ekleme
            }
            else
            {
                MessageBox.Show("Once ders girmeniz gerekiyor", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }

        private void Btn_TekrarDersEkle_Click(object sender, EventArgs e)
        {
            Txt_DersAdi.Text = "";
            Txt_DersId.Text = "";
            Txt_DersId.Focus();
        }

        private void Btn_DersSil_Click(object sender, EventArgs e)
        {
            if (Txt_DersSilID.Text != "") 
            {
                if (Chk_Bolumden.Checked == true && Chk_HocadanSil.Checked == true)
                {
                    Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler[BolumEkrani.BolumIslemID].DersSil(Convert.ToInt16(Txt_DersSilID));
                    Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler[BolumEkrani.BolumIslemID].KayitliOgretimUyeleri[OgretimUyeleriEkrani.HocaIslemID].OgretimGorevlisindenDersSil(Convert.ToInt16(Txt_DersSilID.Text));
                }
                else if (Chk_Bolumden.Checked == true)
                {
                    Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler[BolumEkrani.BolumIslemID].DersSil(Convert.ToInt16(Txt_DersSilID.Text));
                }
                else if (Chk_HocadanSil.Checked == true)
                {
                    Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler[BolumEkrani.BolumIslemID].KayitliOgretimUyeleri[OgretimUyeleriEkrani.HocaIslemID].OgretimGorevlisindenDersSil(Convert.ToInt16(Txt_DersSilID.Text));
                }
                
            }
        }

        private void Btn_TekrarDersSil_Click(object sender, EventArgs e)
        {
            Chk_Bolumden.Checked = false;
            Chk_HocadanSil.Checked = false;
            Txt_DersSilID.Text = "";
            Txt_DersSilID.Focus();
        }

        private void Btn_Getir_Click(object sender, EventArgs e)
        {
            string item = Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler[BolumEkrani.BolumIslemID].KayitliOgretimUyeleri[OgretimUyeleriEkrani.HocaIslemID].OuAd;
            string item2 = Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler[BolumEkrani.BolumIslemID].KayitliOgretimUyeleri[OgretimUyeleriEkrani.HocaIslemID].OuSoyad;
            int item3 = Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler[BolumEkrani.BolumIslemID].KayitliOgretimUyeleri[OgretimUyeleriEkrani.HocaIslemID].OuID;
            listBox2.Items.Add("Adı :" + " " + item + " " + item2 + " -- " + "ID :" + " " + item3);

        }

        private void Btn_Cıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_KayıtlıDersleriGoster_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                foreach (Ders item in Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler[BolumEkrani.BolumIslemID].KayıtlıDersler.Values)
                {
                    listBox1.Items.Add("Ders Adi : " + " " + item.DersAdi + "---" + "Ders ID :" + " " + item.DersID);
                }
            }
            catch (ArgumentException)
            {

                throw new ArgumentException("Gosterilecek Ders Yok !!");
            }
        }
    }
}

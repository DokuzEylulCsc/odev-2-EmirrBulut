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
    public partial class OgretimUyeleriEkrani : Form
    {
        public OgretimUyeleriEkrani()
        {
            InitializeComponent();
        }

        public static int HocaIslemID;

        private void Btn_HocaEkle_Click(object sender, EventArgs e)
        {
            if (Txt_HocaID.Text != "" && Txt_HocaAdi.Text != "" && Txt_HocaSoyadi.Text != "")
            {
                Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler[BolumEkrani.BolumIslemID].OgretimGorevlisiEkle(Convert.ToInt16(Txt_HocaID.Text), Txt_HocaAdi.Text, Txt_HocaSoyadi.Text);
            }
            else
            {
                MessageBox.Show("Eksik biraktiginiz bilgiler mi var ? Kontrol Edin !!", "Hata", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
;
            }
            
        }

        private void Btn_TekrarHocaEkle_Click(object sender, EventArgs e)
        {
            Txt_HocaID.Text = "";
            Txt_HocaAdi.Text = "";
            Txt_HocaSoyadi.Text = "";
            Txt_HocaID.Focus();
        }

        private void Btn_OGSil_Click(object sender, EventArgs e)
        {
            if (Txt_HocaIDSil.Text != "")
            {
                Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler[BolumEkrani.BolumIslemID].OgretimGorevlisiSil(Convert.ToInt16(Txt_HocaIDSil.Text));
            }
            else
            {
                MessageBox.Show("Kimi sileceginizi soylemeyi unuttunuz :)", "Hata", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }

        private void Btn_TekrarHocaSil_Click(object sender, EventArgs e)
        {
            Txt_HocaIDSil.Text = "";
            Txt_HocaIDSil.Focus();
        }

        private void Btn_Cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_HocalariGoster_Click(object sender, EventArgs e)
        {
            KayıtliOgetimGorevlileri.Items.Clear();
            try
            {
                foreach (OgretimUyeleri item in Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler[BolumEkrani.BolumIslemID].KayitliOgretimUyeleri.Values)
                {
                    KayıtliOgetimGorevlileri.Items.Add("Ogretim Gorevlisi :" + " " + item.OuAd + " " + item.OuSoyad + " " + "ID :" + " " + item.OuID);
                }
            }
            catch (ArgumentException)
            {

                throw new ArgumentException("Kayıtlı ogreitm uyesi yok !!");
            }
        }

        private void Btn_Ileri_Click(object sender, EventArgs e)
        {
            if (Txt_HocaIslemID.Text != "")
            {
                HocaIslemID = Convert.ToInt16(Txt_HocaIslemID.Text);
                OgretimUyeleri gereksiz;
                if (Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler[BolumEkrani.BolumIslemID].KayitliOgretimUyeleri.TryGetValue(HocaIslemID,out gereksiz))
                {
                    this.Hide();
                    DersEkrani d = new DersEkrani();
                    d.Show();
                }
            }
            else
            {
                MessageBox.Show("İslem yapmak istediginiz ogretim gorevlisini girin lutfen", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }

        private void Btn_Bilgilendirme_Click(object sender, EventArgs e)
        {
            BilgilendirmeFormu b = new BilgilendirmeFormu();
            b.Show();
        }
    }
}

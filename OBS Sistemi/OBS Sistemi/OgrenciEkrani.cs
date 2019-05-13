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
    public partial class OgrenciEkrani : Form
    {
        public OgrenciEkrani()
        {
            InitializeComponent();
        }

        private void Btn_Cıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_OgrenciEkle_Click(object sender, EventArgs e)
        {
            if ((Txt_OgrenciAdi.Text != "" && Txt_OgrenciBolumu.Text != "" && Txt_OgrenciID.Text != "" && Txt_OgrenciSoyadi.Text != "") && (Rd_Doktora.Checked == true || Rd_Lisans.Checked == true || Rd_Yuksek.Checked == true)) 
            {
                if (Rd_Lisans.Checked == true)
                {
                    label6.Text = Rd_Lisans.Text;
                    Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler[BolumEkrani.BolumIslemID].KayıtlıDersler[DersEkrani.DersIslemID].DerseOgrenciEkle(Convert.ToInt16(Txt_OgrenciID.Text), Txt_OgrenciAdi.Text, Txt_OgrenciSoyadi.Text, Txt_OgrenciBolumu.Text, label6.Text);
                }
                else if (Rd_Yuksek.Checked == true)
                {
                    label6.Text = "Yuksek";
                    Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler[BolumEkrani.BolumIslemID].KayıtlıDersler[DersEkrani.DersIslemID].DerseOgrenciEkle(Convert.ToInt16(Txt_OgrenciID.Text), Txt_OgrenciAdi.Text, Txt_OgrenciSoyadi.Text, Txt_OgrenciBolumu.Text, label6.Text);
                }
                else if (Rd_Doktora.Checked == true)
                {
                    label6.Text = Rd_Doktora.Text;
                    Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler[BolumEkrani.BolumIslemID].KayıtlıDersler[DersEkrani.DersIslemID].DerseOgrenciEkle(Convert.ToInt16(Txt_OgrenciID.Text), Txt_OgrenciAdi.Text, Txt_OgrenciSoyadi.Text, Txt_OgrenciBolumu.Text, label6.Text);
                }
            }
            else
            {
                MessageBox.Show("Bos alan bırakmamalısınız. Dikkatli olun !", "Hata", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
            }
        }

        private void Btn_OgrenciSil_Click(object sender, EventArgs e)
        {
            if(Txt_OgrenciSilID.Text != "")
            {
                Universite.Fakulteler[FakulteEkrani.FakulteIslemID].Bolumler[BolumEkrani.BolumIslemID].KayıtlıDersler[DersEkrani.DersIslemID].DerstenOgrenciSi(Convert.ToInt16(Txt_OgrenciSilID.Text));
            }
            else
            {
                MessageBox.Show("Silmek istediginiz ıD'yi girmeniz gerekiyor", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }

        private void Btn_TekrarEkle_Click(object sender, EventArgs e)
        {
            Txt_OgrenciAdi.Text = "";
            Txt_OgrenciBolumu.Text = "";
            Txt_OgrenciID.Text = "";
            Txt_OgrenciSoyadi.Text = "";
        }

        private void Btn_Bilgilendirme_Click(object sender, EventArgs e)
        {
            BilgilendirmeFormu b = new BilgilendirmeFormu();
            b.Show();
        }
    }
}

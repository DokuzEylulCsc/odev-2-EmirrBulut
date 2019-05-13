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
    public partial class FakulteEkrani : Form
    {
        public FakulteEkrani()
        {
            InitializeComponent();
        }

        Universite uni = Universite.Instance;
        BolumEkrani b = new BolumEkrani();
        public static int FakulteIslemID;
        bool flag = false;

        private void Btn_FakulteEkle_Click(object sender, EventArgs e)
        {
            if (Txt_FakulteID.Text != "" && Txt_FakulteAdi.Text != "")
            {
                uni.FakulteEkle(Convert.ToInt16(Txt_FakulteID.Text), Txt_FakulteAdi.Text);
            }
            else
            {
                Console.WriteLine("Eklemek icin bir seyler girmelisiniz :)");
            }
        }

        private void Btn_TekrarFakulteEkle_Click(object sender, EventArgs e)
        {
            Txt_FakulteID.Text = "";
            Txt_FakulteAdi.Text = "";
            Txt_FakulteID.Focus();
        }

        private void Btn_Cıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_FakulteGetir_Click(object sender, EventArgs e)// Fakulteleri listeme butonu.
        {
            try
            {
                foreach (Fakulte item in Universite.Fakulteler.Values)
                {
                    FakultelerListesi.Items.Add("Fakulte ID :" + " " + item.FakulteId  + "  " + " ---- " +"Fakulte Adı :"  + "  " + item.FakulteAd);
                   
                }
            }
            catch (ArgumentException)
            {

                throw new ArgumentException("Kayıtlı Fakulte Yok !!");
            }
        }

        private void Btn_Ileri_Click(object sender, EventArgs e)
        {
            if (Txt_IslemId.Text != "")
            {
                FakulteIslemID = Convert.ToInt16(Txt_IslemId.Text);
                foreach (int item in Universite.Fakulteler.Keys)
                {
                    if (FakulteIslemID == item)
                    {
                        flag = true;
                    }
                }
                if (flag == true)
                {
                    this.Hide();
                    b.Show();                   
                }         
            }
            else
            {
                MessageBox.Show("Once bir ID girmeniz gerekiyor", "Hata", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }

        }

        private void Btn_Bilgilendirme_Click(object sender, EventArgs e)
        {
            BilgilendirmeFormu b = new BilgilendirmeFormu();
            b.Show();
        }
    }
}

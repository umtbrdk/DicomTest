using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DicomTest
{
    public partial class DbSett : Form
    {
        public DbSett()
        {
            InitializeComponent();
        }
        public string dbAdres, dbSifre, dbKullAdi;

        private void DbSett_Load(object sender, EventArgs e)
        {
            BaglantiAyarlari();
        }
        public void BaglantiAyarlari() // bağlantı ayarları

        {
            string dosya_dizini = AppDomain.CurrentDomain.BaseDirectory.ToString() + "PacsServis.ini";
            if (File.Exists(dosya_dizini) == false) // dizindeki dosya var mı ?
            {
                const string sPath = "PacsServis.ini";
                System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
                SaveFile.Write("DB=" + "172.0.0.1:1521/orcl" + ";");
                SaveFile.Write("KullAdi=" + "HASTANE" + ";");
                SaveFile.Write("KullSifre=" + "HASTANE");
                SaveFile.Close();

                MessageBox.Show(dosya_dizini + " ayar dosyası bulunamadı. Yenisi oluşturuluyor. Lütfen bağlantı bilgilerini kendinize göre ayarlayınız.", "Ayar Dosyası Bulunamadı!");

            }
            else
            {
                string veri = "";
                using (StreamReader sr = new StreamReader("PacsServis.ini"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        veri = line;
                    }
                    sr.Close();
                }
                dbAdres = veri.Substring(3, veri.IndexOf(";") - 3);
                dbSifre = veri.Substring(veri.IndexOf("KullSifre") + 10, veri.Length - (veri.IndexOf("KullSifre") + 10));
                dbKullAdi = veri.Substring(veri.IndexOf("KullAdi=") + 8, (veri.LastIndexOf(";")) - (veri.IndexOf("KullAdi=") + 8));
                txtServer.Text = dbAdres;
                txtKullAdi.Text = dbKullAdi;
                txtSifre.Text = dbSifre;
                
                Database.ConnStr(dbAdres, dbKullAdi, dbSifre);
            }
        }

    }
}

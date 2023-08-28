using FellowOakDicom.Network.Client;
using FellowOakDicom.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FellowOakDicom;
using System.Reflection;
using FellowOakDicom.Network.Client.Advanced.Association;
using FellowOakDicom.Network.Client.Advanced.Connection;
using Oracle.ManagedDataAccess.Client;
using System.IO;
using System.Web.Hosting;
using Telegram.Bot;


namespace DicomTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string dbAdres, dbSifre, dbKullAdi, ip, called, exeAdi;
        int port, sure;
        static TelegramBotClient teleBot = new TelegramBotClient("5851247495:AAFDRl_6-PjEtKXL9jRa9x6PnxsUmBdcP1E"); // HBYS Bilgi İşlem
        string grupCode = "-902916735";// MeddataPACS

        private void Form1_Load(object sender, EventArgs e)
        {
            BaglantiAyarlari();
            LogKlasorCreate();
            ListeGetir();
        }
        void LogKlasorCreate()
        {
            if (!Directory.Exists(@"log"))
                Directory.CreateDirectory("log");
        }
        void LogInsert(string ipAdres, int port, string exeAdi)
        {
            string time = DateTime.Now.ToShortDateString();
            string sPath = "DicomTest" + time + ".log";
            string str_Path = HostingEnvironment.ApplicationPhysicalPath + ("log") + "\\" + sPath;
            string log = ipAdres + ";" + port + ";" + exeAdi + ";" + DateTime.Now.ToString("HH:mm:ss");

            try
            {
                if (!File.Exists(str_Path))
                {
                    File.Create(str_Path).Close();
                    File.AppendAllText(str_Path, log + Environment.NewLine);
                }
                else if (File.Exists(str_Path))
                {
                    File.AppendAllText(str_Path, log + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Log yazarken hata : " + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            testAsync(txtIP.Text, Convert.ToInt32(txtPort.Text), txtCalledIE.Text, txtExeAdi.Text);
          
        }
        async Task testAsync(string ip, int port, string called, string exeAdi)
        {
            try
            {
                var client = DicomClientFactory.Create(ip, port, false, "SCU", called);
                client.NegotiateAsyncOps();
                //for (int i = 0; i < 2; i++)
                await client.AddRequestAsync(new DicomCEchoRequest());
                await client.SendAsync();
                //MessageBox.Show("IP Adres : " + ip + " Port : " + port + " Called : " + called + " Test tamamlandı. ","Echo Test Başarılı!");
            }
            catch (Exception e)
            {
                //MessageBox.Show("Bağlantı Başarısız.."+ ip + ":" + port);
                LogInsert(ip, port, exeAdi);
                TeleBildirim("GALEN", ip, port, called, exeAdi);
            }
        }

        void PacsImport()
        {
            string servisMi;
            if (chServisMi.Checked) servisMi = "T"; else servisMi = "F";

            string cmdtxt = @"INSERT INTO HASTANE.TBL_PACS_CIHAZ(ID, IP_ADRES, PORT, CALLED_AE, AKTIF, HIZMET_ADI, DOSYA_YOLU, SERVIS_MI, EXE_ADI)
                      values (HASTANE.SQ_TBL_PACS_CIHAZ.nextVal, :ip , :port, :called, :aktif, :hizmetAdi, :dosyaYolu, :servisMi, :exeAdi)";
            try
            {
                OracleDataAdapter da = new OracleDataAdapter();
                using (OracleConnection conn = new OracleConnection(Database.connstr))
                using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
                {
                    conn.Open();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = cmdtxt;
                    cmd.Parameters.Add(":ip", txtIP.Text);
                    cmd.Parameters.Add(":port", txtPort.Text);
                    cmd.Parameters.Add(":called", txtCalledIE.Text);
                    cmd.Parameters.Add(":aktif", "T");
                    cmd.Parameters.Add(":hizmetAdi", txtHizmet.Text);
                    cmd.Parameters.Add(":dosyaYolu", txtDosya.Text);
                    cmd.Parameters.Add(":servisMi", servisMi);
                    cmd.Parameters.Add(":exeAdi", txtExeAdi.Text);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                }
                MessageBox.Show("Ekleme Başarılı","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ListeGetir();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Servis bilgisi eklenemedi : " + ex.Message);
            }
        }
        void PacsDelete(int id)
        {

            string cmdtxt = @"DELETE HASTANE.TBL_PACS_CIHAZ WHERE ID = " + id;
            try
            {
                OracleDataAdapter da = new OracleDataAdapter();
                using (OracleConnection conn = new OracleConnection(Database.connstr))
                using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
                {
                    conn.Open();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = cmdtxt;

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                }
                MessageBox.Show("Seçili bağlantı silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeGetir();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Servis bilgisi silinemedi : " + ex.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (txtIP.Text != "" && txtPort.Text != "" && txtExeAdi.Text != "" && txtCalledIE.Text != "")
            {
                PacsImport();
            }
            else MessageBox.Show("Servis bilgilerini doldurunuz!","Veri Bulunamadı!");
        }

        private void dgList_SelectionChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(dgList.CurrentRow.Cells["PORT"].Value.ToString());
            //MessageBox.Show(dgList.CurrentRow.ToString()) ;
        }
        
        private void button2_Click_1(object sender, EventArgs e)
        {
            sure = Convert.ToInt32(numSure.Value) * 60;
            timer1.Interval = sure * 1000;
            if (btnStart.Text == "Başlat")
            {
                timer1.Start();
                tmrDakika.Start();
                btnStart.Text = "Durdur";
            }
            else
            {
                btnStart.Text = "Başlat";
                timer1.Stop();
                tmrDakika.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ForTestAsync();
        }


        private void tmrDakika_Tick(object sender, EventArgs e)
        {
            if (sure == 0 )
            {
                sure = Convert.ToInt32(numSure.Value) * 60;
            }
            lblSure.Text = sure--.ToString();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgList.CurrentRow.Cells["ID"].Value);
            PacsDelete(id);
        }

        async Task ForTestAsync()
        {
            //MessageBox.Show(dgList.Rows[1].Cells["PORT"].Value.ToString());

            for (int i = 0; i < dgList.RowCount; i++)
            {
                port = Convert.ToInt32(dgList.Rows[i].Cells["PORT"].Value);
                ip = dgList.Rows[i].Cells["IP_ADRES"].Value.ToString();
                called = dgList.Rows[i].Cells["CALLED_AE"].Value.ToString();
                exeAdi = dgList.Rows[i].Cells["EXE_ADI"].Value.ToString();

                await testAsync(ip, port, called, exeAdi);
            }
        }

        private void ListeGetir()
        {
            string cmdtxt = "SELECT * FROM HASTANE.TBL_PACS_CIHAZ WHERE AKTIF = 'T' ORDER BY ID";

            try
            {
                using (OracleConnection conn = new OracleConnection(Database.connstr))
                using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
                {
                    conn.Open();
                    dgList.DataSource = null;
                    //gridView1.Columns.Clear();
                    // reader is IDisposable and should be closed
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        //List<String> items = new List<String>();
                        if (dr.HasRows)
                        {
                            System.Data.DataTable dataTable = new System.Data.DataTable();
                            dataTable.Load(dr);
                            dgList.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("TBL_PACS_CIHAZ Tablosunda veri bulunamadı.", "Veri Bulunamadı");
                        }
                    }
                    if (this.dgList.RowCount > 0)
                    {
                      
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void TeleBildirim(string hastaneAdi, string ip, int port, string called, string exeAdi)
        {
            string telegramMessage = @"HASTANE : " + hastaneAdi + "\nIP Adres : " + ip + "\nPort : " + port + "\nCalled AE : " + called + "\nExe Adı : " + exeAdi;

            teleBot.SendTextMessageAsync(grupCode, telegramMessage);
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
                Database.ConnStr(dbAdres, dbKullAdi, dbSifre);
            }
        }


    }
}

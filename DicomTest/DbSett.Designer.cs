namespace DicomTest
{
    partial class DbSett
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKullAdi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTable = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chEposta = new System.Windows.Forms.CheckBox();
            this.chTelegram = new System.Windows.Forms.CheckBox();
            this.chSMS = new System.Windows.Forms.CheckBox();
            this.txtEposta = new System.Windows.Forms.TextBox();
            this.txtTeleID = new System.Windows.Forms.TextBox();
            this.txtSMS = new System.Windows.Forms.TextBox();
            this.txtTeleNo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Server Adres";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(86, 6);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(100, 20);
            this.txtServer.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Kull.Adı";
            // 
            // txtKullAdi
            // 
            this.txtKullAdi.Location = new System.Drawing.Point(86, 32);
            this.txtKullAdi.Name = "txtKullAdi";
            this.txtKullAdi.Size = new System.Drawing.Size(100, 20);
            this.txtKullAdi.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Şifre";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(86, 58);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(100, 20);
            this.txtSifre.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Bağlantı Test";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(103, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Kaydet";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTable);
            this.groupBox1.Location = new System.Drawing.Point(192, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 98);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tablo Ayarları";
            // 
            // btnTable
            // 
            this.btnTable.Location = new System.Drawing.Point(6, 21);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(81, 23);
            this.btnTable.TabIndex = 16;
            this.btnTable.Text = "Tablo Oluştur";
            this.btnTable.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTeleNo);
            this.groupBox2.Controls.Add(this.txtSMS);
            this.groupBox2.Controls.Add(this.txtTeleID);
            this.groupBox2.Controls.Add(this.txtEposta);
            this.groupBox2.Controls.Add(this.chSMS);
            this.groupBox2.Controls.Add(this.chTelegram);
            this.groupBox2.Controls.Add(this.chEposta);
            this.groupBox2.Location = new System.Drawing.Point(15, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 92);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bildirim Ayarları";
            // 
            // chEposta
            // 
            this.chEposta.AutoSize = true;
            this.chEposta.Location = new System.Drawing.Point(6, 19);
            this.chEposta.Name = "chEposta";
            this.chEposta.Size = new System.Drawing.Size(92, 17);
            this.chEposta.TabIndex = 0;
            this.chEposta.Text = "E-Mail Bildirimi";
            this.chEposta.UseVisualStyleBackColor = true;
            // 
            // chTelegram
            // 
            this.chTelegram.AutoSize = true;
            this.chTelegram.Location = new System.Drawing.Point(6, 42);
            this.chTelegram.Name = "chTelegram";
            this.chTelegram.Size = new System.Drawing.Size(107, 17);
            this.chTelegram.TabIndex = 2;
            this.chTelegram.Text = "Telegram Bildirimi";
            this.chTelegram.UseVisualStyleBackColor = true;
            // 
            // chSMS
            // 
            this.chSMS.AutoSize = true;
            this.chSMS.Location = new System.Drawing.Point(6, 65);
            this.chSMS.Name = "chSMS";
            this.chSMS.Size = new System.Drawing.Size(86, 17);
            this.chSMS.TabIndex = 4;
            this.chSMS.Text = "SMS Bildirimi";
            this.chSMS.UseVisualStyleBackColor = true;
            // 
            // txtEposta
            // 
            this.txtEposta.Location = new System.Drawing.Point(127, 17);
            this.txtEposta.Name = "txtEposta";
            this.txtEposta.Size = new System.Drawing.Size(151, 20);
            this.txtEposta.TabIndex = 1;
            // 
            // txtTeleID
            // 
            this.txtTeleID.Location = new System.Drawing.Point(127, 40);
            this.txtTeleID.Name = "txtTeleID";
            this.txtTeleID.Size = new System.Drawing.Size(151, 20);
            this.txtTeleID.TabIndex = 3;
            // 
            // txtSMS
            // 
            this.txtSMS.Location = new System.Drawing.Point(127, 63);
            this.txtSMS.Name = "txtSMS";
            this.txtSMS.Size = new System.Drawing.Size(151, 20);
            this.txtSMS.TabIndex = 5;
            // 
            // txtTeleNo
            // 
            this.txtTeleNo.Location = new System.Drawing.Point(284, 40);
            this.txtTeleNo.Name = "txtTeleNo";
            this.txtTeleNo.Size = new System.Drawing.Size(87, 20);
            this.txtTeleNo.TabIndex = 20;
            // 
            // DbSett
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 213);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKullAdi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServer);
            this.MaximizeBox = false;
            this.Name = "DbSett";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Veritabanı Ayarları";
            this.Load += new System.EventHandler(this.DbSett_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKullAdi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTeleNo;
        private System.Windows.Forms.TextBox txtSMS;
        private System.Windows.Forms.TextBox txtTeleID;
        private System.Windows.Forms.TextBox txtEposta;
        private System.Windows.Forms.CheckBox chSMS;
        private System.Windows.Forms.CheckBox chTelegram;
        private System.Windows.Forms.CheckBox chEposta;
    }
}
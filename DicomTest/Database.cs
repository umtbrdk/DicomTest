using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomTest
{
    internal class Database
    {
        public static string dbAdres, dbKullAdi, dbSifre, connstr, islemCevap;
        public static DateTime guncelTar;
        public static string ConnStr(string _dbAdres, string _dbKullAdi, string _dbSifre)
        {
            dbAdres = _dbAdres;
            dbKullAdi = TurToEng(_dbKullAdi);
            dbSifre = _dbSifre;
            connstr = "data source=" + dbAdres + ";user id=" + dbKullAdi + ";password=" + dbSifre + ";";
            return connstr;
        }


        public static string TurToEng(string text)
        {
            char[] trChar = { 'ı', 'ğ', 'İ', 'Ğ', 'ç', 'Ç', 'ş', 'Ş', 'ö', 'Ö', 'ü', 'Ü' };
            char[] engChar = { 'i', 'g', 'I', 'G', 'c', 'C', 's', 'S', 'o', 'O', 'u', 'U' };

            for (int i = 0; i < trChar.Length; i++)
                text = text.Replace(trChar[i], engChar[i]);

            return text;

        }

        public static DateTime YeniTarih(DateTime _yeniTar)
        {
            guncelTar = _yeniTar;
            return guncelTar;
        }
        public static string IslemOK(string _islem)
        {
            if (_islem == "F")
                islemCevap = "F";
            else islemCevap = "T";
            return islemCevap;
        }
    }
}

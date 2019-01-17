using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageRankConsoleProject.Classes
{
    public class Düğüm
    {
        public static List<Düğüm> dugumler = new List<Düğüm>();
        public string isim;
        public float hesap1 = 0;
        public float hesap2 = 0;
        public float pageRank = 0;
        List<Düğüm> gidenDugumler = new List<Düğüm>();
        List<Düğüm> gelenDugumler = new List<Düğüm>();




        public Düğüm(string isim)
        {
            this.isim = isim;
            dugumler.Add(this); // genel düğümler tablomuza eklenir.
        }
        public void gidenEkle(params Düğüm[] dugumler) // çokça düğüm alabilir
        {
            foreach (Düğüm d in dugumler) // alınan düğümler teker teker , her düğüme özel giden  ve gelen düğümler listelerine eklenir.
            {
                this.gidenDugumler.Add(d); // giden düğüm eklendiği gibi , giden düğüme de aşağıdaki kodda gelen eklenir.
                d.gelenEkle(this); // gidene eklediğimiz gibi o düğümün gelenine de bu eklenir.
            }

        }
        void gelenEkle(Düğüm d)
        {
            this.gelenDugumler.Add(d); // düğüm nesnesi oluşturulursa bu sınıfın statik düğümler listesine eklenir.
        }

        //hesaplamalar için static metodlar açılır , tüm düğümler için gerekli hesaplamalar yapılıp düğümlerin içindeki değerler doldurulur
        public static void hesap_1()
        {// hesap1 = toplam düğüm sayısı
         //toplam düğüm sayısı hesaplanıp, her düğümün hesap1 değişkeni doldurulur
            float toplam_dugum = 0;
            foreach (Düğüm item in dugumler)
            {
                toplam_dugum++;
            }
            toplam_dugum = 1 / toplam_dugum;
            foreach (Düğüm item in dugumler)
            {
                item.hesap1 = toplam_dugum;
            }
        }
        public static void hesap_2()
        {
            //hesap2 = (ilgili düğümü hesap1'i  (BÖLÜ) ilgili düğüme gelen düğümleri komşuluk sayıları) * ilgili düğüme gelen her düğüm için ...  hepsinin toplamı = hesap2
            foreach (Düğüm i1 in dugumler) // Her Düğüm için aşağıdaki işlemler yapılır
            {
                float hesap_2 = 0;
                float gelen_komsunun_giden_sayisi = 0;

                foreach (Düğüm i2 in i1.gelenDugumler)
                {
                    foreach (Düğüm i3 in i2.gidenDugumler)
                    {
                        gelen_komsunun_giden_sayisi++;
                    }
                    hesap_2 += ((i1.hesap1) / gelen_komsunun_giden_sayisi);
                    gelen_komsunun_giden_sayisi = 0;
                }
                i1.hesap2 = hesap_2;
            }
        }

        public static void hesap_3()
        {//rangePage = ( ilgili düğüme gelen düğümlerin hesap2'si (BÖLÜ) yine o gelen düğümün komşuluk(giden) sayısı ) * tüm gelen düğümler için ... hepsinin toplamı = rangePage

            foreach (Düğüm i1 in dugumler) // Her Düğüm için aşağıdaki işlemler yapılır
            {
                float pageRank_yeni = 0;
                float gelen_komsunun_giden_sayisi = 0;

                foreach (Düğüm i2 in i1.gelenDugumler)
                {
                    foreach (Düğüm i3 in i2.gidenDugumler)
                    {
                        gelen_komsunun_giden_sayisi++;
                    }
                    pageRank_yeni += ((i2.hesap2) / gelen_komsunun_giden_sayisi);
                    gelen_komsunun_giden_sayisi = 0;
                }
                i1.pageRank = pageRank_yeni;
            }
        }
    }
}

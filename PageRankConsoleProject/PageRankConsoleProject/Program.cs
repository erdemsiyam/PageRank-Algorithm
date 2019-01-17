using PageRankConsoleProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageRankConsoleProject
{
    class Program
    {

        // ÖNEMLİ : 
        // PROGRAM C# Konsol Uygulaması olarak yazıldı.
        // KAYNAK OLARAK BU VİDEO KULLANILMIŞTIR : https://www.youtube.com/watch?v=P8Kt6Abq_rM
        // DEĞERLER OLDUKÇA YAKIN ÇIKMAKTADIR.
        static void Main(string[] args)
        {
            // Örnek (Example) : creating nodes
            Düğüm d1 = new Düğüm("d1");
            Düğüm d2 = new Düğüm("d2");
            Düğüm d3 = new Düğüm("d3");
            Düğüm d4 = new Düğüm("d4");
            Düğüm d5 = new Düğüm("d5");
            Düğüm d6 = new Düğüm("d6");
            Düğüm d7 = new Düğüm("d7");
            Düğüm d8 = new Düğüm("d8");
            Düğüm d9 = new Düğüm("d9");
            Düğüm d10 = new Düğüm("d10");

            // Örnek (Example) : entry the nodes connections
            d1.gidenEkle(d6, d7, d8, d9);
            d2.gidenEkle(d6, d7);
            d3.gidenEkle(d6, d7);
            d4.gidenEkle(d6, d7, d8, d9);
            d5.gidenEkle(d6, d8, d9, d10);
            d6.gidenEkle(d1, d2, d3, d4, d5, d7, d8, d10);
            d7.gidenEkle(d1, d2, d3, d4, d6, d8, d9, d10);
            d8.gidenEkle(d1, d4, d5, d6, d7, d9, d10);
            d9.gidenEkle(d1, d4, d5, d7, d8, d10);
            d10.gidenEkle(d5, d6, d7, d8, d9);

            // Örnek (Example) : calculate the example
            Düğüm.hesap_1();
            Düğüm.hesap_2();
            Düğüm.hesap_3(); //sonuncu hesap pageRank hesabı (the last one is page rank result of the example)

            float pageRank_toplam = 0;
            foreach (Düğüm item in Düğüm.dugumler) // düğüm sınıfının içinde statik tuttuğumuz tüm düğümlerin page rank'ını yazdırıyoruz.
            {
                Console.WriteLine(item.isim + " : " + item.pageRank.ToString());
                pageRank_toplam += item.pageRank; // sonuçların toplamını almaktayız , 1 den farklıysa hata var demektir

            }
            Console.WriteLine("Toplam : " + pageRank_toplam.ToString()); // sonuç toplamlarını yazar.

            Console.ReadLine(); // konsolu durdurmaması için beklet
        }
    }
}

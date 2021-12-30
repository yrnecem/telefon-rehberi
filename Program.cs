using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telefon_rehberi
{
    class Kisi
    {     
        public string isim;
        public string soyisim;
        public string telefon;

        public Kisi(string isim, string soyisim, string telefon)
        {
            this.isim = isim;
            this.soyisim = soyisim;
            this.telefon = telefon;
        }     
    }

    public enum SiralamaDuzeni
        {
            Artan,
            Azalan
        }

    class KisiIslemler
    {
        List<Kisi> kisiler = new List<Kisi>();

        public KisiIslemler(List<Kisi> kisiler)
        {
            this.kisiler = kisiler;
        }

        void kisiGoruntule(Kisi kisi)
        {
            Console.WriteLine("-->İsim: " + kisi.isim);
            Console.WriteLine("   Soyisim: " + kisi.soyisim);
            Console.WriteLine("   Telefon numarası: " + kisi.telefon);
            Console.WriteLine();
        }

        public void isimSoyisimAraması(string gelen)
        {
            Console.WriteLine();
            bool kayitVarmi = false;

            for (int i = 0; i < kisiler.Count; i++)
            {
                if (gelen == kisiler[i].isim || gelen == kisiler[i].soyisim)
                {
                    kisiGoruntule(kisiler[i]);
                    kayitVarmi=true;
                }
            }

            if (!kayitVarmi)
            {
                islemSonucuIsle("Aradığınız ifadeyle eşleşen sonuç bulunamamıştır.");
            }
        }
        public void telefonNumarasıArama(string gelen)
        {
            Console.WriteLine();
            bool kayitVarmi = false;

            for (int i = 0; i < kisiler.Count; i++)
            {
                if (gelen == kisiler[i].telefon)
                {
                    kisiGoruntule(kisiler[i]);
                    kayitVarmi = true;
                }
            }
            if (!kayitVarmi)
            {
                islemSonucuIsle("Aradığınız ifadeyle eşleşen sonuç bulunamamıştır.");
            }

        }

        public bool numaraVarmi(string gelen,out int index)
        {
            for (int i = 0; i < kisiler.Count; i++)
            {
                if (gelen == kisiler[i].isim || gelen==kisiler[i].soyisim)
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }
        public void numaraSil(int index)
        {
             kisiler.RemoveAt(index);
             islemSonucuIsle("Silme İşlemi Başarıyla Gerçekleşti.");
        }
        public void numaraGuncelle(int index,string yeniTelefon)
        {
            kisiler[index].telefon = yeniTelefon;
            islemSonucuIsle("Güncelleme İşlemi Başarıyla Gerçekleşti.");
        }

        public void rehberListele(SiralamaDuzeni siralamaSecimi)
        {
            kisiler.Sort((u1, u2) => u1.isim.CompareTo(u2.isim));//isime göre sırala

            if (siralamaSecimi == SiralamaDuzeni.Azalan)//eğer azalan isteniyorsa listeyi ters çevir
            {
                kisiler.Reverse();
            }
           
            Console.WriteLine();
            for (int i = 0; i < kisiler.Count; i++)
            {
                kisiGoruntule(kisiler[i]);
            }
        }
        void islemSonucuIsle(string islemSonucu)
        {
            Console.WriteLine(islemSonucu);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Kisi> kisiler = new List<Kisi>();
            kisiler.Add(new Kisi("yaren ecem","terzioğlu","1905"));
            kisiler.Add(new Kisi("şevval","izgördü","6335"));
            kisiler.Add(new Kisi("ceren","tarı","4434"));
            kisiler.Add(new Kisi("bilge","şengül","2000"));
            kisiler.Add(new Kisi("ecem rana","dumlu","2001"));

            KisiIslemler kisiIslemler = new KisiIslemler(kisiler);
            while (true)
            {
                Console.WriteLine("*****************");
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz");
                Console.WriteLine("(1) Telefon Numarası Kaydet");
                Console.WriteLine("(2) Telefon Numarası Sil");
                Console.WriteLine("(3) Telefon Numarası Güncelle");
                Console.WriteLine("(4) Rehber Listele");
                Console.WriteLine("(5) Rehberde Arama");
                Console.WriteLine("(6) Sonlandır");
                Console.WriteLine("******************");

                Console.Write("\nİşlem seçiniz:");
            
                try
                {
                    int islemNo = Convert.ToInt16(Console.ReadLine());

                    if (islemNo < 1 || islemNo > 6)
                    {
                        Console.WriteLine("\nLütfen 1-6 arası işlem seçiniz!");
                        continue;
                    }
                    else if (islemNo == 6)
                    {
                        Console.WriteLine("İşlem Sonlandırıldı.");
                        break;
                    }

                Console.Clear();

                switch (islemNo)
                {
                    case 1:
                        {
                            Console.Write(" Lütfen isim giriniz:");
                            string ad = Console.ReadLine();
                            Console.Write(" Lütfen soyisim giriniz:");
                            string soyad = Console.ReadLine();
                            Console.Write(" Lütfen telefon numarası giriniz:");
                            string telNo = Console.ReadLine();
                            Kisi geciciKisi = new Kisi(ad,soyad,telNo);

                            kisiler.Add(geciciKisi);

                            Console.WriteLine("Kayıt işlemi gerçekleştirildi.");

                            break;
                        }
                    case 2:
                        {
                            while (true)
                            {
                                Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
                                string girilen = Console.ReadLine();
                                int index = -1;

                                if (kisiIslemler.numaraVarmi(girilen, out index)) {
                                    Console.WriteLine("-->"+girilen + " değerinizle eşleşen kayıt silinmek üzere onaylıyor musunuz?(y/n)");
                                    Console.Write("Seçiminiz:");
                                    string islem = Console.ReadLine();

                                    if (islem == "y")
                                    {
                                        kisiIslemler.numaraSil(index);
                                        break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen işlem seçiniz.");
                                    Console.WriteLine(" İşlemi sonlandırmak için: (1)");
                                    Console.WriteLine(" Yeniden denemek için: (2)");

                                    Console.Write("Seçiminiz:");
                                    int yeniSecim = Convert.ToInt16(Console.ReadLine());
                                    if (yeniSecim == 1)
                                    {
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            while (true)
                            {
                                Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");
                                string girilen = Console.ReadLine();
                                int index = -1;

                                if (kisiIslemler.numaraVarmi(girilen, out index))
                                {
                                    Console.Write("-->" + girilen + " değerinizle eşleşen kaydı güncellemek için yeni numara giriniz:");
                                    string yeniNo = Console.ReadLine();

                                    kisiIslemler.numaraGuncelle(index, yeniNo);

                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen işlem seçiniz.");
                                    Console.WriteLine(" Güncellemeyi sonlandırmak için: (1)");
                                    Console.WriteLine(" Yeniden denemek için: (2)");

                                    Console.Write("Seçiminiz:");
                                    int yeniSecim = Convert.ToInt16(Console.ReadLine());
                                    if (yeniSecim == 1)
                                    {
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Hangi düzende sıralamak istediğinizi seçiniz.");
                            Console.WriteLine(" A-Z için: (1)");
                            Console.WriteLine(" Z-A için: (2)");
                            Console.Write("Seçiminiz:");
                            int siralamaSecimi= Convert.ToInt16(Console.ReadLine());

                            if (siralamaSecimi == 1)
                            {
                                   kisiIslemler.rehberListele(SiralamaDuzeni.Artan);
                            }
                            else
                            {
                                  kisiIslemler.rehberListele(SiralamaDuzeni.Azalan);
                            }

                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
                            Console.WriteLine(" *İsim veya soyisime göre arama yapmak için: (1)");
                            Console.WriteLine(" *Telefon numarasına göre arama yapmak için: (2)");

                            Console.Write("Seçiminiz:");
                            int yeniSecim = Convert.ToInt16(Console.ReadLine());

                            if (yeniSecim == 1)
                            {
                                Console.Write("İsim veya soyisim giriniz:");
                                string aranan_adveyaSoyad = Console.ReadLine();
                                kisiIslemler.isimSoyisimAraması(aranan_adveyaSoyad);
                            }
                            else
                            {
                                Console.Write("Telefon giriniz:");
                                string aranan_telefon = Console.ReadLine();
                                kisiIslemler.telefonNumarasıArama(aranan_telefon);
                            }

                            break;
                        }
                }
                Console.WriteLine("\nYeni işlem için bir tuşa basınız");
                Console.ReadKey();
                Console.Clear();
                }catch (FormatException e)
                {
                    Console.WriteLine("Hatalı giriş yapıldı!\n");
                }
        }
            Console.ReadKey();
        }
    }
}
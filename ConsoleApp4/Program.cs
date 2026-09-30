using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main()
    {
        bool davam = true;
        while (davam)
        {
            Console.WriteLine();
            Console.WriteLine("===== ANA MENYU =====");
            Console.WriteLine("1) Telebe Qeydiyyat Sistemi");
            Console.WriteLine("2) Hendesi Kalkulyator");
            Console.WriteLine("3) Ededler Analizi");
            Console.WriteLine("4) Ededi Tapmaq");
            Console.WriteLine("0) Cixis");
            Console.Write("Secim: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    Tapshiriq1();
                    break;
                case "2":
                    Tapshiriq2();
                    break;
                case "3":
                    Tapshiriq3();
                    break;
                case "4":
                    Tapshiriq4();
                    break;
                case "0":
                    davam = false;
                    break;
                default:
                    Console.WriteLine("Yanlis secim!");
                    break;
            }
        }
    }

    static int OxuInt(string mesaj)
    {
        int netice;
        Console.Write(mesaj);
        while (!int.TryParse(Console.ReadLine(), out netice))
        {
            Console.Write("Yanlis giris. Yeniden daxil edin: ");
        }
        return netice;
    }

    static double OxuDouble(string mesaj)
    {
        double netice;
        Console.Write(mesaj);
        while (!double.TryParse(Console.ReadLine().Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out netice) || netice <= 0)
        {
            Console.Write("Yanlis giris. Musbet eded daxil edin: ");
        }
        return netice;
    }

    static void Tapshiriq1()
    {
        Dictionary<int, string> telebeler = new Dictionary<int, string>
        {
            { 1, "Aysel" },
            { 2, "Elvin" },
            { 3, "Nigar" },
            { 4, "Rashad" },
            { 5, "Leyla" }
        };

        bool davam = true;
        while (davam)
        {
            Console.WriteLine();
            Console.WriteLine("--- Telebe Qeydiyyat Sistemi ---");
            Console.WriteLine("1) Telebe elave et");
            Console.WriteLine("2) Telebeni ID ile axtar");
            Console.WriteLine("3) Butun telebeleri goster");
            Console.WriteLine("4) Cixis");
            Console.Write("Secim: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    int id = OxuInt("Telebe ID: ");
                    if (telebeler.ContainsKey(id))
                    {
                        Console.WriteLine("Bu ID artiq movcuddur!");
                    }
                    else
                    {
                        Console.Write("Telebe adi: ");
                        string ad = Console.ReadLine();
                        telebeler.Add(id, ad);
                        Console.WriteLine("Telebe elave olundu.");
                    }
                    break;
                case "2":
                    int axtarilan = OxuInt("Axtarilan ID: ");
                    if (telebeler.TryGetValue(axtarilan, out string tapilanAd))
                    {
                        Console.WriteLine("Tapildi: " + axtarilan + " - " + tapilanAd);
                    }
                    else
                    {
                        Console.WriteLine("Bu ID ile telebe tapilmadi.");
                    }
                    break;
                case "3":
                    Console.WriteLine("Butun telebeler:");
                    foreach (KeyValuePair<int, string> t in telebeler)
                    {
                        Console.WriteLine(t.Key + " - " + t.Value);
                    }
                    break;
                case "4":
                    davam = false;
                    break;
                default:
                    Console.WriteLine("Yanlis secim!");
                    break;
            }
        }
    }

    static void Tapshiriq2()
    {
        Console.WriteLine();
        Console.WriteLine("--- Hendesi Kalkulyator ---");
        Console.WriteLine("1) Daire");
        Console.WriteLine("2) Duzbucaqli");
        Console.WriteLine("3) Ucbucaq");
        Console.Write("Fiqur secin: ");
        string secim = Console.ReadLine();
        double sahe;

        switch (secim)
        {
            case "1":
                double r = OxuDouble("Radius: ");
                sahe = Math.PI * Math.Pow(r, 2);
                Console.WriteLine("Dairenin sahesi: " + Math.Round(sahe, 2));
                break;
            case "2":
                double en = OxuDouble("En: ");
                double uzunluq = OxuDouble("Uzunluq: ");
                sahe = en * uzunluq;
                Console.WriteLine("Duzbucaqlinin sahesi: " + Math.Round(sahe, 2));
                break;
            case "3":
                double a = OxuDouble("1-ci teref: ");
                double b = OxuDouble("2-ci teref: ");
                double c = OxuDouble("3-cu teref: ");
                if (a + b <= c || a + c <= b || b + c <= a)
                {
                    Console.WriteLine("Bu olcülerle ucbucaq mövcud deyil!");
                }
                else
                {
                    double p = (a + b + c) / 2;
                    sahe = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                    Console.WriteLine("Ucbucaqin sahesi: " + Math.Round(sahe, 2));
                }
                break;
            default:
                Console.WriteLine("Yanlis secim!");
                break;
        }
    }

    static void Tapshiriq3()
    {
        Console.WriteLine();
        Console.WriteLine("--- Ededler Analizi ---");
        List<int> ededler = new List<int>();

        for (int i = 1; i <= 10; i++)
        {
            ededler.Add(OxuInt(i + "-ci eded: "));
        }

        int max = ededler[0];
        int min = ededler[0];
        int cut = 0;
        int tek = 0;

        foreach (int n in ededler)
        {
            max = Math.Max(max, n);
            min = Math.Min(min, n);

            if (n % 2 == 0)
            {
                cut++;
            }
            else
            {
                tek++;
            }
        }

        Console.WriteLine("En boyuk eded: " + max);
        Console.WriteLine("En kicik eded: " + min);
        Console.WriteLine("Cut ededlerin sayi: " + cut);
        Console.WriteLine("Tek ededlerin sayi: " + tek);
    }

    static void Tapshiriq4()
    {
        Console.WriteLine();
        Console.WriteLine("--- Ededi Tapmaq ---");
        Random random = new Random();
        int gizli = random.Next(0, 101);
        int cehd;
        int say = 0;

        Console.WriteLine("0 ile 100 arasinda eded fikirlesdim. Tapin!");

        do
        {
            cehd = OxuInt("Cehdiniz: ");
            say++;

            if (cehd > gizli)
            {
                Console.WriteLine("Daha kicik eded cehd edin");
            }
            else if (cehd < gizli)
            {
                Console.WriteLine("Daha boyuk eded cehd edin");
            }
        }
        while (cehd != gizli);

        Console.WriteLine("Tebrikler! Eded " + gizli + " idi. Cehd sayi: " + say);
    }
}
namespace prednaska_22._4_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cislo;
            int pocet = 0;
            int pocetZapornych = 0;
            do
            {
                Console.WriteLine("zadej cislo");
                cislo = int.Parse(Console.ReadLine());
                pocet++;
                int soucet =+ pocet; 
                if (cislo < 0)
                    pocetZapornych++;

            } while (cislo != 0);
            Console.WriteLine($"pocet cisel: {pocet}, pocet zapornych cisel: {pocetZapornych}");
        }

    }
    internal class Priklad3
    {
        static void Main(string[] args )
        {
            

            string znacka;
            int cena;
            Tauto auto;

            auto = ZadejAuto();

            ZadejAuto(out znacka, out cena);
            VypisAuto(ref znacka, ref cena);

        }
        static void ZadejAuto(string znacka, int cena)
        {
            znacka = "Volvo";
            cena = 140000;

        }
        static void VypisAuto(string znacka, int cena)
        {
            Console.WriteLine($"Cena: {cena}, Znacka: {znacka}");
        }

        struct Tauto
        {
            public string znacka;
            public int cena;
        }

        static Tauto ZadejAuto()
        {
            Tauto autoPomoc;
            autoPomoc.znacka = "Skoda";
            autoPomoc.cena = 10000;
            return autoPomoc;
        }

        static void VypsatAuta(Tauto autoPomoc)
        {

        }
    }
}

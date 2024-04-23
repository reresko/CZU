namespace cviko_13._3_
{
    internal class Program
    {
        int cislo;
        struct TStudent
        {
            public string jmeno;
            public string prijmeni;
            public int ID;
        }

        static TStudent zadejStudenta()
        {
            TStudent temp = new TStudent();
            Console.WriteLine("zadej jmeno studenta: ");
            temp.jmeno = Console.ReadLine();

            Console.WriteLine("zadej prijmeni studenta: ");
            temp.prijmeni = Console.ReadLine();

            Console.WriteLine("zadej ID studenta: ");
            temp.ID = int.Parse(Console.ReadLine());

            return temp;
        }

        static void zadejStudenty(ref TStudent[] poleS, ref int pocetS)
        {
            string odpoved;
            Console.WriteLine("chces zadat studenta?");
            odpoved = Console.ReadLine();
            while (odpoved=="A")
            {
                poleS[pocetS] = zadejStudenta();
                pocetS++;
                Console.WriteLine("chces zadat studenta?");
                odpoved = Console.ReadLine();
            }

        }
        static void vypisStudentu(TStudent[] poleS, int pocetS)
        {
            for (int i = 0; i < pocetS; i++)
            {
                Console.WriteLine(poleS[i].jmeno + " " + poleS[i].prijmeni + " " + poleS[i].ID);
            }
        }

        static void smazatStudenta(ref TStudent[] poleS, int index, ref int pocetS)
        {
            for (int i = index;i < pocetS-1; i++)
            {
                poleS[i] = poleS[i+1];
            }
        }
        static void Main()
        {
            TStudent [] mujStudent = new TStudent[20];
            int pocetStudentu = 0;

            zadejStudenty(ref mujStudent, ref pocetStudentu);
            vypisStudentu(mujStudent, pocetStudentu);
            mujStudent[0].jmeno = "mocka";

            Console.ReadKey();
        }
    }
}

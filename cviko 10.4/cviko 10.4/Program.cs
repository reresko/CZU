namespace cviko_10._4_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static int nactiCislo(string text = "Zadej celé číslo")
            {
                string vstup="";
                int cislo=0;
                int pocetPokusu = 3;
                bool jeToCislo = false;

                while (!jeToCislo && pocetPokusu >0)
                {
                    Console.WriteLine(text);
                    vstup = Console.ReadLine();
                    jeToCislo = int.TryParse(vstup, out cislo);
                    if (jeToCislo)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("spravne zadano");
                        Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("zadane cislo: {0}", cislo);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("nespravne zadano");
                        Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("pocet pokusu: {0}", pocetPokusu-1);
                        Console.ResetColor();
                        pocetPokusu--;
                    }
                }
                
                return cislo;
                
            }



            static int nactiCisloJinak(string text = "Zadej celé číslo")
            {
                string vstup = "";
                int cislo = 0;
                int pocetPokusu = 3;
                bool jeToCislo = false;

                while (!jeToCislo && pocetPokusu > 0)
                {
                    Console.WriteLine(text);
                    vstup = Console.ReadLine();
                    try
                    {
                        cislo = int.Parse(vstup);
                        Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("spravne zadano");
                        Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("zadane cislo: {0}", cislo);
                        Console.ResetColor();
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("nespravne zadano");
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.Source);
                        Console.WriteLine(e.HResult);
                        Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("pocet pokusu: {0}", pocetPokusu - 1);
                        Console.ResetColor();
                        pocetPokusu--;

                        
                        
                    }
                    //finally { } -provede se kdyz fce aspon jednou spadne do catche
                }

                return cislo;

            }



            nactiCisloJinak();

        }
    }
}

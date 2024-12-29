namespace cviko_24._4_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] strom = new char[31, 31];

            static void rStrom(int vyska, int pozicex, int pozicey, ref char[,] pStrom)
            {
                if (vyska > 0)
                {
                    if (pStrom[pozicex, pozicey] == 'x')
                    {
                        pStrom[pozicex, pozicey] = 'X';
                    }
                    else
                    {
                        pStrom[pozicex, pozicey] = 'x';
                    }
                    rStrom(vyska--, pozicex--, pozicey++, ref pStrom);
                    rStrom(vyska--, pozicex++, pozicey++, ref pStrom);
                }
            }

            for (int i = 0; i < 31; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    strom[i, j] = '.';
                }
            }

            rStrom(5, 15, 0, ref strom);

            for (int i = 0; i < 31; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    Console.Write(strom[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}

//pondelky uterky stredy galba
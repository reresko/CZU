



namespace cviko2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string retezec = "doleva na 30";
            string retezec2 = "doprava na 30";
            string ret, ret2;
            ret = retezec.PadRight(30);
            ret2 = retezec2.PadLeft(30);

            string[] jmena = { "jana", "karel", "oto" };
            float[] casy = {12.8f, 13.3f, 9.5f};

            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
            Console.WriteLine(retezec.PadRight(30));
            Console.WriteLine(retezec2.PadLeft(30));
            Console.WriteLine(ret);
            Console.WriteLine(ret2);

            Console.WriteLine("{0, -30} {1, 30}", retezec, retezec2);


            for (int i = 0; i < jmena.Length; i++)
            {
                Console.WriteLine("{0, -15}{1, 15:N2}", jmena[i], casy[i]);
            }


            int sachovnice = 8;

            for (int radek = 0; radek <= sachovnice; radek++)
            {
                for (int pozice = 0;pozice <= sachovnice; pozice++)
                {
                    if ((radek+pozice)%2==0) { Console.Write("O"); }
                    else { Console.Write("X"); }
                }
                Console.WriteLine();
            }

            int[] posloupnost = {7,8,5,4,6,9,2,3,1,2,3,4,5,6,7};
            bool prohozeni = true;
            int temp = 0;

            while (prohozeni)
            {
                prohozeni = false;
                for(int i = 0; i<posloupnost.Length-1; i++)
                {
                    temp = posloupnost[i]; posloupnost[i] = posloupnost[i + 1];
                    posloupnost[i + 1] = temp; prohozeni = true;
                }
            }
            for (int i = 0; i < posloupnost.Length; i++)
            {
                Console.Write(posloupnost[i] + " ");
            }

            Console.ReadKey();
        }
    }
}

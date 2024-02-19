using System;
using System.IO;
//using GlobalLowLevelKeyboardHook;

namespace keylogger
{
    internal class Program
    {


        static void Main(string[] args)
        {
            string filePath = @"c:\Users\adca\Desktop\log.txt";
            ConsoleKeyInfo keyInfo;

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                do
                {
                    keyInfo = Console.ReadKey(intercept: true);
                    writer.Write($"{keyInfo.KeyChar}");

                } while (keyInfo.Key != ConsoleKey.Escape);
            }
            Console.WriteLine("\ninput saved to .txt file");
        }
    }
}

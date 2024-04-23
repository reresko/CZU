
namespace bankovniSystemVeryLite
{
    internal class UI
    {
        static void Main()
        {
            UI UI = new UI();
            Account Account = new Account();

            Account.LoadBalance();
            Account.LoadUsername();
            Account.LoadPassword();
            
            Account.Login();
            bool prihlasen = true;

            while (prihlasen)
            {
                UI.Menu();
                Console.Write("Zadej požadavek: ");
                string x = Console.ReadLine();
                Console.WriteLine();

                switch (x)
                {
                    case "1":
                        Account.Vklad();
                        break;

                    case "2":
                        Account.Vyber();
                        break;

                    case "3":
                        Account.TransactionHistory.PrintTransactionHistory();
                        break;

                    case "4":
                        Account.ChangeUsername();
                        break;

                    case "5":
                        Account.ChangePassword();
                        break;

                    case "6":
                        prihlasen = false;
                        break;

                    case "0":
                        return;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Neplatný vstup, zkuste to znovu.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Account.VypisZustatku();
                        break;
                }

                if (!prihlasen)
                {
                    Console.Clear();
                    Account.Login();
                    prihlasen = true;
                }
            }                        
        }
        public void Menu()
        {
            Console.WriteLine("\n---------- MENU ----------\n");
            Console.WriteLine("1................Vklad");
            Console.WriteLine("2................Výběr");
            Console.WriteLine("3................Historie transakcí");
            Console.WriteLine("4................Změnit uživatelské jméno");
            Console.WriteLine("5................Změnit heslo");
            Console.WriteLine("6................Odhlásit se");
            Console.WriteLine("0................Vypnout");
            Console.WriteLine();
        }

    }
}
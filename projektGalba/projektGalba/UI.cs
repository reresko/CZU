

namespace bankovniSystemVeryLite
{
    internal class UI
    {
        static void Main()
        {
            UI UI = new UI();
            Account Account = new Account();

            Account.LoadBalance();
            Account.Login();


            while (true)
            {
                Console.WriteLine();
                UI.Menu();
                Console.Write("Zadej požadavek: ");
                string x = Console.ReadLine();
                Console.WriteLine();

                switch (x)
                {
                    case "1":
                        Account.Deposit();
                        break;

                    case "2":
                        Account.Withdraw();
                        break;

                    case "3":
                        Account.TransactionHistory.PrintTransactionHistory();
                        break;

                    case "0":
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input, try again.\n");
                        //Console.WriteLine(); tady dodelat at to printi zustatek po tom co dam spatnej input
                        break;
                }
            }                        
        }
        public void Menu()
        {
            Console.WriteLine("---------- MENU ----------\n");
            Console.WriteLine("1................Deposit");
            Console.WriteLine("2................Withdraw");
            Console.WriteLine("3................Transaction History");
            Console.WriteLine("0................Shutdown");
            Console.WriteLine();
        }
    }
}
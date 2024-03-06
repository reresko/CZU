

namespace bankovniSystemVeryLite
{
    internal class Account
    {
        static string username = "admin";
        static string password = "admin";
        private float balance = 0;

        public static TransactionHistory TransactionHistory = new TransactionHistory();

        public float GetBalance()
        {
            return balance;
        }
        public void Login()
        {
            bool loggedIn = false;
            while (!loggedIn)
            {
                Console.Write("\nZadejte uživatelské jméno: ");
                string usernameInput = Console.ReadLine();
                Console.Write("\nZadejte heslo: ");
                string passwordInput = Console.ReadLine();

                if (usernameInput == username && passwordInput == password)
                {
                    Console.Clear();
                    Console.WriteLine("Úspěšně přihlášen.\n");
                    loggedIn = true;
                    Console.Write("Aktuální zůstatek: ");
                    Console.WriteLine(balance + " Kč");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("chybně zadané uživatelské jméno nebo heslo. zkuste znovu: ");
                }
            }

        }
        public void SaveBalance()
        {
            File.WriteAllText("balance.txt", balance.ToString());
        }
        public void LoadBalance()
        {
            if (File.Exists("balance.txt"))
            {
                string balanceText = File.ReadAllText("balance.txt");
                if (float.TryParse(balanceText, out float loadedBalance))
                {
                    balance = loadedBalance;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Failed to parse balance from file.");
                }
            }
        }

        public void Deposit()
        {

            float castka;
            bool floatBool = false;
            while (!floatBool)
            {
                
                Console.Write("Jakou částku chcete vložit: ");
                if (!float.TryParse(Console.ReadLine(), out castka))
                {
                    Console.WriteLine();
                    Console.WriteLine("Chybně zadaná hodnota.\n");
                }
                else
                {
                    if (castka > 0)
                    {
                        Console.Clear();
                        balance = balance + castka;
                        TransactionHistory.AddTransaction(TransactionType.Deposit, castka);
                        SaveBalance();
                        Console.WriteLine("Částka byla úspěšně vložena.\n");
                        Console.Write("Aktuální zůstatek: ");
                        Console.WriteLine(balance + " Kč");
                        floatBool = true;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Zadejte kladné číslo.\n");
                    }
                }
            }

        }

        public void Withdraw()
        {
            float castka;
            bool floatBool = false;
            while (!floatBool)
            {
                Console.Write("Jakou částku chcete vybrat: ");
                if (!float.TryParse(Console.ReadLine(), out castka))
                {
                    Console.WriteLine();
                    Console.WriteLine("Chybně zadaná hodnota.\n");
                }
                else
                {
                    
                    if (castka > balance)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Nedostatek prostředků.\n");
                    }
                    else
                    {
                        if (castka > 0)
                        {
                            Console.Clear();
                            balance = balance - castka;
                            TransactionHistory.AddTransaction(TransactionType.Withdraw, castka);
                            SaveBalance();
                            Console.WriteLine("Částka byla úspěšně vybrána\n");
                            Console.Write("Aktuální zůstatek: ");
                            Console.WriteLine(balance + " Kč");
                            floatBool = true;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Zadejte kladné číslo.\n");
                        }
                    }

                }
            }
        }
    }
}
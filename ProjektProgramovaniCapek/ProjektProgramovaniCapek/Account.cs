

namespace bankovniSystemVeryLite
{
    // Definice třídy Account, která zahrnuje operace související s bankovním účtem
    internal class Account
    {
        // Statické proměnné pro výchozí uživatelské jméno a heslo
        static string username = "admin";
        static string password = "admin";
        // Proměnná pro zůstatek na účtu
        private float balance = 0;

        // Instance třídy TransactionHistory pro přístup k funkcím z dané třídy
        public static TransactionHistory TransactionHistory = new TransactionHistory();

        // Metoda pro přihlášení uživatele
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
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Úspěšně přihlášen.");
                    Console.ForegroundColor = ConsoleColor.White;
                    loggedIn = true;
                    VypisZustatku();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Chybně zadané uživatelské jméno nebo heslo. Zkuste to znovu.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

        }

        // Metoda pro uložení uživatelského jména do souboru
        public void SaveUsername()
        {
            File.WriteAllText("username.txt", username.ToString());
        }

        // Metoda pro načtení uživatelského jména ze souboru
        public void LoadUsername()
        {
            if (File.Exists("username.txt"))
            {
                string loadedUsername = File.ReadAllText("username.txt");
                username = loadedUsername;
            }
        }

        // Metoda pro uložení hesla do souboru
        public void SavePassword()
        {
            File.WriteAllText("password.txt", password.ToString());
        }

        // Metoda pro načtení hesla ze souboru
        public void LoadPassword()
        {
            if (File.Exists("password.txt"))
            {
                string loadedPassword = File.ReadAllText("password.txt");
                password = loadedPassword;
            }
        }

        // Metoda pro změnu uživatelského jména
        public void ChangeUsername()
        {
            Console.Write("\nZadejte nové uživatelské jméno: ");
            string newUsername = Console.ReadLine();
            username = newUsername;
            SaveUsername();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Uživatelské jméno bylo úspěšně změněno na: " + username);
            Console.ForegroundColor = ConsoleColor.White;
            VypisZustatku();
        }

        // Metoda pro změnu hesla
        public void ChangePassword()
        {
            Console.Write("\nZadejte staré heslo: ");
            string oldPassword = Console.ReadLine();

            if (oldPassword == password)
            {
                Console.Write("\nZadejte nové heslo: ");
                string newPassword = Console.ReadLine();
                Console.Write("\nZadejte nové heslo znovu: ");
                string newPasswordAgain = Console.ReadLine();
                if (newPasswordAgain == newPassword)
                {
                    password = newPassword;
                    SavePassword();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Heslo bylo úspěšně změněno.");
                    Console.ForegroundColor = ConsoleColor.White;
                    VypisZustatku();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nové heslo se musí shodovat. Změna hesla selhala.");
                    Console.ForegroundColor = ConsoleColor.White;
                    VypisZustatku();
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Špatné staré heslo. Změna hesla selhala.");
                Console.ForegroundColor = ConsoleColor.White;
                VypisZustatku();
            }
        }

        // Metoda pro uložení zůstatku na účtu do souboru
        public void SaveBalance()
        {
            File.WriteAllText("balance.txt", balance.ToString());
        }

        // Metoda pro načtení zůstatku ze souboru
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nepodařilo se zpracovat zůstatek ze souboru.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        // Metoda pro výpis zůstatku na účtu
        public void VypisZustatku()
        {
            Console.Write("\nAktuální zůstatek: ");
            Console.WriteLine(balance + " Kč");
        }

        // Metoda pro vložení peněz na účet
        public void Vklad()
        {
            float castka;
            bool jeCIslo = false;
            while (!jeCIslo)
            {

                Console.Write("Pro ukončení vkladu a návrat do Menu stiskněte '0'\nZadejte částku, kterou chcete vložit: ");
                if (!float.TryParse(Console.ReadLine(), out castka))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nChybně zadaná hodnota.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    castka = (float)Math.Round(castka, 2);
                    if (castka > 100000)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nPro vložení částky větší než 100 000 zajděte do nejbližší pobočky Vaší banky.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (castka > 0)
                    {
                        Console.Clear();
                        balance = balance + castka;
                        TransactionHistory.AddTransaction(TransactionType.Vklad, castka);
                        SaveBalance();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Částka byla úspěšně vložena.");
                        Console.ForegroundColor = ConsoleColor.White;
                        VypisZustatku();
                        jeCIslo = true;
                    }
                    else if (castka == 0)
                    {
                        Console.Clear();
                        VypisZustatku();
                        jeCIslo = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nZadejte kladné číslo.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
            }

        }

        // Metoda pro výběr peněz z účtu
        public void Vyber()
        {
            float castka;
            bool jeCIslo = false;
            while (!jeCIslo)
            {
                Console.Write("Pro ukončení stiskněte '0'\nJakou částku chcete vybrat: ");
                if (!float.TryParse(Console.ReadLine(), out castka))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nChybně zadaná hodnota.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    castka = (float)Math.Round(castka, 2);
                    if (castka > balance)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nNedostatek prostředků.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        if (castka > 100000)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nPro výběr částky větší než 100 000 zajděte do nejbližší pobočky Vaší banky.\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (castka > 0 && castka <= 100000)
                        {
                            Console.Clear();
                            balance = balance - castka;
                            TransactionHistory.AddTransaction(TransactionType.Vyber, castka);
                            SaveBalance();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Částka byla úspěšně vybrána");
                            Console.ForegroundColor = ConsoleColor.White;
                            VypisZustatku();
                            jeCIslo = true;
                        }
                        else if (castka == 0)
                        {
                            Console.Clear();
                            VypisZustatku();
                            jeCIslo = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nZadejte kladné číslo.\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
            }
        }
    }
}
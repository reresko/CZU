using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bankovniSystemVeryLite
{

    // Definice třídy TransactionHistory pro uchovávání historie transakcí
    internal class TransactionHistory
    {
        // Instance třídy Account pro práci s účtem
        Account Account = new Account();

        // Seznam transakcí
        private List<Transaction> transactionHistory = new List<Transaction>();
        // Název souboru pro ukládání historie transakcí
        private string filename = "transactionhistory.txt";

        // Konstruktor třídy TransactionHistory
        public TransactionHistory()
        {
            LoadTransactionHistory();
        }

        // Metoda pro přidání transakce do historie
        public void AddTransaction(TransactionType typ, float castka)
        {
            Transaction transaction = new Transaction(typ, castka, DateTime.Now);
            transactionHistory.Add(transaction);
            SaveTransactionHistory();
        }

        // Metoda pro výpis historie transakcí
        public void PrintTransactionHistory()
        {
            // Výpis hlavičky
            Console.Clear();
            Console.WriteLine("HISTORIE TRANSAKCÍ\n");

            // Pokud je historie transakcí prázdná, vyskočí chybová hláška
            if (transactionHistory.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nebyly nalezeny žádné pohyby.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            // Pokud historie transakcí obsahuje více než 10 položek, vypíše se posledních 10
            if (transactionHistory.Count > 10)
            {
                for (int i = Math.Max(0, transactionHistory.Count - 9) - 1; i < transactionHistory.Count; i++)
                {
                    var transaction = transactionHistory[i];

                    // Zobrazení transakce podle typu
                    if (transaction.Typ == TransactionType.Vklad)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Typ: {transaction.Typ}, Částka: {transaction.Castka} Kč,  Datum: {transaction.Datum}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Typ: {transaction.Typ}, Částka: {transaction.Castka} Kč,  Datum: {transaction.Datum}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                // Pokud historie transakcí obsahuje 10 nebo méně položek, vypíšou se všechny
            }
            else
            {
                // Zobrazení transakce podle typu
                foreach (var transaction in transactionHistory)
                {
                    if (transaction.Typ == TransactionType.Vklad)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Typ: {transaction.Typ}, Částka: {transaction.Castka} Kč,  Datum: {transaction.Datum}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Typ: {transaction.Typ}, Částka: {transaction.Castka} Kč,  Datum: {transaction.Datum}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }

            // Načtení aktuálního zůstatku účtu
            float balance = 0;
            string balanceText = File.ReadAllText("balance.txt");

            if (float.TryParse(balanceText, out float loadedBalance))
            {
                balance = loadedBalance;
            }
            Console.WriteLine();
            Console.Write("aktuální zůstatek: ");
            Console.WriteLine(balance + " Kč");
        }

        // Metoda pro uložení historie transakcí do souboru
        public void SaveTransactionHistory()
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Transaction transaction in transactionHistory)
                {
                    writer.WriteLine($"{transaction.Typ},{transaction.Castka},{transaction.Datum}");
                }
            }
        }


        // Metoda pro načtení historie transakcí ze souboru
        public void LoadTransactionHistory()
        {
            // Kontrola, zda soubor s historií transakcí existuje
            if (File.Exists(filename))
            {
                try
                {
                    // Otevření souboru pro čtení pomocí stream readeru
                    using (StreamReader reader = new StreamReader(filename))
                    {
                        string line;
                        // Čtení řádek po řádku ze souboru
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Rozdělení načteného řádku podle oddělovače (čárka) a uložení do pole
                            string[] rozdeleno = line.Split(",");
                            // Kontrola, zda má načtený řádek správný formát (očekávají se 3 položky oddělené čárkou)
                            if (rozdeleno.Length == 3)
                            {
                                TransactionType typ;
                                // Pokus o převod první položky (typu transakce) ze stringu na enum TransactionType
                                if (Enum.TryParse(rozdeleno[0], out typ))
                                {
                                    float castka;
                                    // Pokus o převod druhé položky (částky) ze stringu na float
                                    if (float.TryParse(rozdeleno[1], out castka))
                                    {
                                        DateTime datum;
                                        // Pokus o převod třetí položky (data) ze stringu na DateTime
                                        if (DateTime.TryParse(rozdeleno[2], out datum))
                                        {
                                            // Vytvoření nové transakce a přidání do historie transakcí
                                            transactionHistory.Add(new Transaction(typ, castka, datum));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // Zachycení výjimky v případě chyby při čtení ze souboru
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nepodařilo se načíst historii transakcí.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            // Pokud soubor s historií transakcí neexistuje, vypiš hlášku a nastav prázdnou historii
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Soubor s historií transakcí nebyl nalezen, začíná se s prázdnou historií.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    // Výčet typů transakcí
    public enum TransactionType
    {
        Vklad,
        Vyber
    }

    // Třída reprezentující jednu transakci
    public class Transaction
    {
        public TransactionType Typ { get; set; }
        public float Castka { get; set; }
        public DateTime Datum { get; set; }

        // Konstruktor třídy Transaction - volá se automaticky při vytváření nové instance třídy
        public Transaction(TransactionType typ, float castka, DateTime datum)
        {
            Typ = typ;
            Castka = castka;
            Datum = datum;
        }
    }
}
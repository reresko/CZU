using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankovniSystemVeryLite
{

    internal class TransactionHistory
    {
        Account Account = new Account();
        private List<Transaction> transactionHistory = new List<Transaction>();
        private string filename = "transactionhistory.txt";
        public TransactionHistory()
        {
            LoadTransactionHistory();
        }

        public void AddTransaction(TransactionType typ, float castka)
        {
            Transaction transaction = new Transaction(typ, castka, DateTime.Now);
            transactionHistory.Add(transaction);
            SaveTransactionHistory();
        }

        public void PrintTransactionHistory()
        {
            Console.Clear();
            Console.WriteLine("HISTORIE TRANSAKCÍ\n");

            if (transactionHistory.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nebyly nalezeny žádné pohyby.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            if (transactionHistory.Count > 10)
            {
                for (int i = Math.Max(0, transactionHistory.Count - 9) - 1; i < transactionHistory.Count; i++)
            {
                var transaction = transactionHistory[i];
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
            else
            {
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

        public void LoadTransactionHistory()
        {
            if (File.Exists(filename))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(filename))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] rozdeleno = line.Split(",");
                            if (rozdeleno.Length == 3)
                            {
                                TransactionType typ;
                                if (Enum.TryParse(rozdeleno[0], out typ))
                                {
                                    float castka;
                                    if (float.TryParse(rozdeleno[1], out castka))
                                    {
                                        DateTime datum;
                                        if (DateTime.TryParse(rozdeleno[2], out datum))
                                        {
                                            transactionHistory.Add(new Transaction(typ, castka, datum));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nepodařilo se načíst historii transakcí.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Soubor s historií transakcí nebyl nalezen, začíná se s prázdnou historií.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    public enum TransactionType
    {
        Vklad,
        Vyber
    }

    public class Transaction
    {
        public TransactionType Typ { get; set; }
        public float Castka { get; set; }
        public DateTime Datum { get; set; }

        public Transaction(TransactionType typ, float castka, DateTime datum)
        {
            Typ = typ;
            Castka = castka;
            Datum = datum;
        }   
    }

}
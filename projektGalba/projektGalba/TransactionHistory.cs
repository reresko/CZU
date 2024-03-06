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

        public void AddTransaction(TransactionType type, float amount)
        {
            Transaction transaction = new Transaction(type, amount, DateTime.Now);
            transactionHistory.Add(transaction);
            SaveTransactionHistory();
        }

        public void PrintTransactionHistory()
        {
            Console.Clear();
            Console.WriteLine("TRANSACTION HISTORY\n");

            if (transactionHistory.Count == 0)
            {
                Console.WriteLine("No transactions found.");
                return;
            }

            for (int i = Math.Max(0, transactionHistory.Count - 10) - 1; i < transactionHistory.Count; i++)
            {
                var transaction = transactionHistory[i];
                if (transaction.Type == TransactionType.Deposit)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Type: {transaction.Type}, Amount: {transaction.Amount} Kč,  date: {transaction.Date}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Type: {transaction.Type}, Amount: {transaction.Amount} Kč,  date: {transaction.Date}");
                    Console.ForegroundColor = ConsoleColor.White;
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
                    writer.WriteLine($"{transaction.Type},{transaction.Amount},{transaction.Date}");
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
                                TransactionType type;
                                if (Enum.TryParse(rozdeleno[0], out type))
                                {
                                    float amount;
                                    if (float.TryParse(rozdeleno[1], out amount))
                                    {
                                        DateTime date;
                                        if (DateTime.TryParse(rozdeleno[2], out date))
                                        {
                                            transactionHistory.Add(new Transaction(type, amount, date));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
                catch
                {
                    Console.WriteLine("Failed to load transaction history.");
                }
            }
            else
            {
                Console.WriteLine("Transaction history file not found, starting with empty history.");
            }
        }
    }

    public enum TransactionType
    {
        Deposit,
        Withdraw
    }

    public class Transaction
    {
        public TransactionType Type { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }

        public Transaction(TransactionType type, float amount, DateTime date)
        {
            Type = type;
            Amount = amount;
            Date = date;
        }   
    }

}
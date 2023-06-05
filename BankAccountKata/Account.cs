using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountKata
{
    public class Account
    {

        private Transaction transaction;
        private static double balance;
        private IList<Transaction> transactions = new List<Transaction>();


        public void Deposit(double amount, string date)
        {
            transaction = new Transaction(amount, date);
            transactions.Add(transaction);
        }

        public void Withdraw(double amount, string date) 
        {
            transaction = new Transaction(-amount, date);
            transactions.Add(transaction);
        }
        public void PrintStatement()
        {
            Console.WriteLine("DATE|AMOUNT|BALANCE");
            foreach(var transaction in transactions)
            {
                balance += transaction.amount;
                if(transaction.amount >= 0)
                    Console.WriteLine($"{transaction.date}|{transaction.amount:F2}|{balance:F2}");
                else
                    Console.WriteLine($"{transaction.date}|{transaction.amount}|{balance:F2}");

            }

        }

        class Transaction
        {
            public double amount;
            public string date;
            public double balance;
            public Transaction(double amount, string date) 
            { 
                this.amount = amount;
                this.date = date;
            }
        }
    }
}

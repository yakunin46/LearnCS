using System;
using System.Collections.Generic;
using System.Text;

namespace Num1
{
    public class BankAccount
    {
        private string owner = "Owner";
        private decimal balance = 0;
        private string accountNumber = "N0000";
        private static int accountCounter = 0;
        public BankAccount(string owner, decimal balance)
        {
            this.owner = owner;

            if (balance < 0)
                this.balance = 0;
            else
                this.balance = balance;

            accountNumber = $"N{++accountCounter:D4}";
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine($"ОШИБКА! Сумма депозита должна быть больше нуля. ");
                Console.WriteLine($"Вы пытались внести {amount:C}");
                return;
            }
            balance += amount;
            Console.WriteLine($"Счет {accountNumber} успешно пополнен на {amount:C}");
            Console.WriteLine($"Текущий баланс: {balance:C}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > balance)
            {
                Console.WriteLine($"ОШИБКА! Сумма вывода должна быть больше нуля " +
                    $"и не превышать текущий баланс.");
                Console.WriteLine($"Вы пытались вывести {amount:C}");
                return;
            }
            balance -= amount;
            Console.WriteLine($"Вывод средств со счета {accountNumber} " +
                $"на сумму {amount:C} прошел успешно.");
            Console.WriteLine($"Текущий баланс: {balance:C}");
        }

        public void GetInfo()
        {
            Console.WriteLine($"Владелец: {owner}");
            Console.WriteLine($"Баланс: {balance:C}");
            Console.WriteLine($"Номер счета: {accountNumber}");
        }
    }
}
using System;

namespace Banking
{
    public class BankTerminal
    {
        public Action<int>? OnMoneyWithdraw;
        // для виправлення помилок
        // public event Action<int>? OnMoneyWithdraw;

        public void Withdraw(int amount)
        {
            Console.WriteLine($"Знято готівку: {amount} грн");
            OnMoneyWithdraw?.Invoke(amount);
        }
    }
}
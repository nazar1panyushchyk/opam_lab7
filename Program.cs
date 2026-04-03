using System;
using Banking;
using Closures;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Завдання 1 ===");
        Lambda.Execute();

        Console.WriteLine("=== Завдання 2 ===");
        RunBankTerminalWithDelegate();
    }

    static void RunBankTerminalWithDelegate()
    {
        var terminal = new BankTerminal();

        terminal.OnMoneyWithdraw += amount =>
            Console.WriteLine($"Лог операції: знято {amount} грн");

        terminal.OnMoneyWithdraw += amount =>
            Console.WriteLine($"Сповіщення: з рахунку списано {amount} грн");

        Console.WriteLine("Нормальна робота термінала:");
        terminal.Withdraw(500);

        // демонстрація помилок:
        Console.WriteLine("\nСторонній код втручається в роботу термінала:");

        terminal.OnMoneyWithdraw = null;
        Console.WriteLine("Усі підписники були видалені через пряме присвоєння null.");

        Console.WriteLine("Повторна операція після втручання:");
        terminal.Withdraw(300);

        terminal.OnMoneyWithdraw?.Invoke(9999);
        Console.WriteLine("Сторонній код може викликати делегат навіть без реального зняття коштів.");
    }
}

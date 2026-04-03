using System;
using System.Collections.Generic;

namespace Closures
{
    public static class Lambda
    {
        public static void Execute()
        {
            Console.WriteLine("Неправильний варіант:");

            var actions = new List<Action>();

            for (int i = 1; i <= 5; i++)
            {
                actions.Add(() => Console.WriteLine($"Значення: {i}"));
            }

            foreach (var action in actions)
                action();

            Console.WriteLine("\nВиправлений варіант:");

            actions.Clear();

            for (int i = 1; i <= 5; i++)
            {
                int snapshot = i;
                actions.Add(() => Console.WriteLine($"Значення: {snapshot}"));
            }

            foreach (var action in actions)
                action();
        }
    }
}
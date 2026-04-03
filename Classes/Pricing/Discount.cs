using System;
using System.Collections.Generic;

namespace Pricing
{
    public static class Discount
    {
        public static void Run()
        {
            Console.WriteLine("Робота багатоадресного делегата Func:");

            Func<double, double>? discountCalculator = null;

            discountCalculator += price => price * 0.95;
            discountCalculator += price => price * 0.90;
            discountCalculator += price => price - 100;

            double result = discountCalculator!(1000);

            Console.WriteLine($"Результат виклику discountCalculator(1000): {result} грн");

            Console.WriteLine();
            Console.WriteLine("Послідовне застосування знижок через ланцюжок викликів:");

            double priceValue = 1000;
            Console.WriteLine($"Початкова ціна: {priceValue} грн");

            foreach (Delegate handler in discountCalculator.GetInvocationList())
            {
                var discountStep = (Func<double, double>)handler;
                priceValue = discountStep(priceValue);

                Console.WriteLine($"Після чергової знижки: {priceValue} грн");
            }

            Console.WriteLine($"Кінцева ціна після всіх знижок: {priceValue} грн");
        }
    }
}
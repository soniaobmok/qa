using System;

namespace laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            ExceptionManager.Handle(new DivideByZeroException());
            ExceptionManager.Handle(new InvalidOperationException());
            ExceptionManager.Handle(new ArithmeticException());

            Console.WriteLine($"Critical: {ExceptionManager.GetCounts().Item1}\nOrdinary: {ExceptionManager.GetCounts().Item2}");
            Console.WriteLine($"Send Errors: {ExceptionManager.GetCounts().Item3}");

        }
    }
}

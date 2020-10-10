using System;

namespace laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            ExceptionManager exceptionManager = new ExceptionManager();

            exceptionManager.Handle(new DivideByZeroException());
            exceptionManager.Handle(new InvalidOperationException());
            exceptionManager.Handle(new ArithmeticException());

            Console.WriteLine($"Critical: {exceptionManager.GetCounts().Item1}\nOrdinary: {exceptionManager.GetCounts().Item2}");
            Console.WriteLine($"Send Errors: {exceptionManager.GetCounts().Item3}");

        }
    }
}

using System;

namespace ExceptionManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = ExceptionManagerFactory
                .CreateSimpleExceptionManager()
                .Handle(new DivideByZeroException())
                .Handle(new InvalidOperationException())
                .Handle(new ArithmeticException())
                .GetStats();
            Console.WriteLine(result);
        }
    }
}

using System;

namespace ExceptionManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new ExceptionManager(
                new CriticalExceptionConfigurableDeterminator(),
                new CriticalExceptionServerInformer()
            )
                .Handle(new DivideByZeroException())
                .Handle(new InvalidOperationException())
                .Handle(new ArithmeticException())
                .GetStats();
            Console.WriteLine(result);
        }
    }
}

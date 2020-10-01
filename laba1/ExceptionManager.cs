using System;
using System.Collections.Generic;
using System.Text;

namespace laba1
{
    public class ExceptionManager
    {
        private static Int16 critical = 0;
        private static Int16 ordinary = 0;
        public static Boolean IsCritical(Exception e)
        {
            return (
                e is DivideByZeroException ||
                e is FormatException ||
                e is ArithmeticException
            );
        }
        public static void Handle(Exception e)
        {
            if (IsCritical(e))
                { critical++; }
            else
                { ordinary++; }
        }
        public static (Int16 critical, Int16 ordinary) GetCounts()
        {
            return (critical, ordinary);
        }
    }
}

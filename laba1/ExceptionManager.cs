using System;
using System.Collections.Generic;
using System.Text;

namespace laba1
{
    public class ExceptionManager
    {
        private static UInt16 critical;
        private static UInt16 ordinary;
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
        public static (UInt16 critical, UInt16 ordinary) GetCounts()
        {
            return (critical, ordinary);
        }
    }
}

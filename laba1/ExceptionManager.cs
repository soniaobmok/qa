using System;
using System.Collections.Generic;
using System.Text;

namespace laba1
{
    class ExceptionManager
    {
        private static int critical = 0;
        private static int ordinary = 0;
        public static bool IsCritical(Exception e)
        {
            if (
                e is DivideByZeroException ||
                e is FormatException ||
                e is ArithmeticException
            ) return true;
            return false;
        }
        public static void Handle(Exception e)
        {
            if (IsCritical(e))
                { critical++; }
            else
                { ordinary++; }
        }
        public static (int, int) GetCounts()
        {
            return (critical, ordinary);
        }
    }
}

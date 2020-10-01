using System;
using System.Collections.Generic;
using System.Text;

namespace laba1
{
    class ExceptionManager
    {
        public static bool isCritical(Exception e)
        {
            if (e is DivideByZeroException || e is NullReferenceException) return true;
            return false;
        }
        public static void handle(Exception e)
        {
            var a = isCritical(e) ? critical++ : ordinary++;
            Console.WriteLine("critical: " + critical);
            Console.WriteLine("ordinary: " + ordinary);
        }
        private static int critical = 0;
        private static int ordinary = 0;
    }
}

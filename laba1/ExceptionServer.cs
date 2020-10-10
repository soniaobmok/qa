using System;
using System.Collections.Generic;
using System.Text;

namespace laba1
{
    class ExceptionServer
    {
        private static List<string> exceptionList = new List<string>();

        public static Boolean ReceiveException(string exception)
        {
            if (string.IsNullOrEmpty(exception))
            {
                Console.WriteLine("Error while receiving exception! Exception is null.");
                return false;
            }

            try
            {
                exceptionList.Add(exception);
            } catch (Exception e)
            {
                Console.WriteLine("Error while receiving exception! " + e.Message);
                return false;
            }
            return true;
        }
    }
}

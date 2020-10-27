using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionManager
{
    public static class ExceptionServer
    {
        private static readonly List<String> exceptionList = new List<String>();

        public static Boolean ReceiveException(String exception)
        {
            if (String.IsNullOrEmpty(exception))
            {
                Console.WriteLine("Error while receiving exception! Exception is null.");
                return false;
            }

            try
            {
                exceptionList.Add(exception);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while receiving exception! " + e.Message);
                return false;
            }
            return true;
        }
    }
}

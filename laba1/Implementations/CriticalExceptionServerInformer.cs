using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionManager
{
    class CriticalExceptionServerInformer : ICriticalExceptionInformer
    {
        private static UInt16 sendErrorCounter;
        public UInt16 GetErrorsCount()
        {
            return sendErrorCounter;
        }

        public void IncrementErrorCounter()
        {
            sendErrorCounter++;

        }

        public Boolean Inform(Exception exception)
        {
            Boolean result = ExceptionServer.ReceiveException(exception.GetType().ToString());

            if (!result)
                IncrementErrorCounter();

            return result;
        }
    }
}

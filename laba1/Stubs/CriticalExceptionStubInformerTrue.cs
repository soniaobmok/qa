using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionManager
{
    public class CriticalExceptionStubInformerTrue : ICriticalExceptionInformer
    {
        public UInt16 GetErrorsCount()
        {
            return 0;
        }

        public void IncrementErrorsCount()
        {
            return;
        }

        public Boolean Inform(Exception exception)
        {
            return true;
        }
    }
}

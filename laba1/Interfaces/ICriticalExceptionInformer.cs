using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionManager
{
    public interface ICriticalExceptionInformer
    {
        public void IncrementErrorCounter();
        public UInt16 GetErrorsCount();
        public Boolean Inform(Exception exception);
    }
}

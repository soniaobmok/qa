using System;

namespace ExceptionManager
{
    public class CriticalExceptionStubDeterminatorFalse : ICriticalExceptionDeterminator
    {
        public bool determinate(Exception e)
        {
            return false;
        }
    }
}

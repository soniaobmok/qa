using System;

namespace ExceptionManager
{
    public class CriticalExceptionStubDeterminatorTrue : ICriticalExceptionDeterminator
    {
        public bool determinate(Exception e)
        {
            return true;
        }
    }
}

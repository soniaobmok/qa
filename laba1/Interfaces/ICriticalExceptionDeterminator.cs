using System;

namespace ExceptionManager
{
    public interface ICriticalExceptionDeterminator
    {
        public Boolean determinate(Exception e);
    }
}

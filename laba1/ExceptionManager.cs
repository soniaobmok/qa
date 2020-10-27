using System;

namespace ExceptionManager
{
    public class ExceptionManager
    {
        private static UInt16 critical;
        private static UInt16 ordinary;

        public ICriticalExceptionDeterminator СriticalExceptionDeterminator { get; set; }
        public ICriticalExceptionInformer ExceptionInformer { get; set; }
        public ExceptionManager() { }

        public (UInt16 critical, UInt16 ordinary) GetStats()
        {
            return (critical, ordinary);
        }

        public Boolean IsCritical(Exception exception)
        {
            return СriticalExceptionDeterminator.determinate(exception);
        }

        public Boolean Inform(Exception exception)
        {
            return ExceptionInformer.Inform(exception);
        }

        public ExceptionManager Handle(Exception exception)
        {
            if (exception == null)
                return this;
            if (IsCritical(exception))
            {
                critical++;
                Inform(exception);
            }
            else
            {
                ordinary++;
            }
            return this;
        }
    }
}

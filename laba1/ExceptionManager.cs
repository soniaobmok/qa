using System;

namespace ExceptionManager
{
    public class ExceptionManager
    {
        private static UInt16 critical;
        private static UInt16 ordinary;

        private readonly ICriticalExceptionDeterminator criticalExceptionDeterminator;
        private readonly ICriticalExceptionInformer exceptionInformer;

        public ExceptionManager(
            ICriticalExceptionDeterminator determinator,
            ICriticalExceptionInformer informer)
        {
            criticalExceptionDeterminator = determinator;
            exceptionInformer = informer;
        }

        public (UInt16 critical, UInt16 ordinary) GetStats()
        {
            return (critical, ordinary);
        }

        public Boolean IsCritical(Exception exception)
        {
            return criticalExceptionDeterminator.determinate(exception);
        }

        public Boolean Inform(Exception exception)
        {
            return exceptionInformer.Inform(exception);
        }

        public ExceptionManager Handle(Exception exception)
        {
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

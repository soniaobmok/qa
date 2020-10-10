using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionManager
{
    public static class ExceptionManagerFactory
    {
        public static ExceptionManager CreateSimpleExceptionManager()
        {
            return new ExceptionManager
            {
                СriticalExceptionDeterminator = new CriticalExceptionConfigurableDeterminator(),
                ExceptionInformer = new CriticalExceptionServerInformer()
            };
        }

        public static ExceptionManager CreateStubExceptionManagerTrue()
        {
            return new ExceptionManager
            {
                СriticalExceptionDeterminator = new CriticalExceptionStubDeterminatorTrue(),
                ExceptionInformer = new CriticalExceptionStubInformerTrue()
            };
        }

        public static ExceptionManager CreateStubExceptionManagerFalse()
        {
            return new ExceptionManager
            {
                СriticalExceptionDeterminator = new CriticalExceptionStubDeterminatorFalse(),
                ExceptionInformer = new CriticalExceptionStubInformerFalse()
            };
        }
    }
}

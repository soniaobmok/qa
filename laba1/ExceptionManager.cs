using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace laba1
{
    public class ExceptionManager : IExceptionManager, IExceptionSender
    {
        private static UInt16 critical;
        private static UInt16 ordinary;
        private static UInt16 sendError;

        public Boolean IsCritical(Exception e)
        {
            using (StreamReader reader = new StreamReader("D:\\qa\\laba1\\config.txt")) // TODO: fix the path
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                    if (e.GetType().ToString() == line)
                        return true;

                return false;
            }
        }

        public void IncErrorCount()
        {
            sendError++;
        }

        public void Handle(Exception e)
        {
            if (IsCritical(e))
            { 
                critical++;

                if (!SendToServer(e))
                    IncErrorCount();
            }
            else
                { ordinary++; }
        }

        public (UInt16 critical, UInt16 ordinary, UInt16 sendError) GetCounts()
        {
            return (critical, ordinary, sendError);
        }

        public Boolean SendToServer(Exception e)
        {
            ExceptionServer server = new ExceptionServer();
            return server.ReceiveException(e.GetType().ToString());
        }
    }
}

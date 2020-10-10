using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace laba1
{
    public class ExceptionManager
    {
        private static UInt16 critical;
        private static UInt16 ordinary;
        private static UInt16 sendError;

        public static Boolean IsCritical(Exception e)
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

        public static void Handle(Exception e)
        {
            if (IsCritical(e))
            { 
                critical++;

                if (!SendToServer(e))
                    sendError++;
            }
            else
                { ordinary++; }
        }

        public static (UInt16 critical, UInt16 ordinary, UInt16 sendError) GetCounts()
        {
            return (critical, ordinary, sendError);
        }

        public static Boolean SendToServer(Exception e)
        {
            return ExceptionServer.ReceiveException(e.GetType().ToString());
        }
    }
}

using System;
using System.IO;

namespace ExceptionManager
{
    class CriticalExceptionConfigurableDeterminator : ICriticalExceptionDeterminator
    {
        public bool determinate(Exception e)
        {
            var config = Properties.Resources.config;
            using (StreamReader reader = new StreamReader("..\\..\\..\\config.txt"))
            {
                String line;

                while ((line = reader.ReadLine()) != null)
                    if (e.GetType().ToString() == line) return true;

                return false;
            }
        }
    }
}

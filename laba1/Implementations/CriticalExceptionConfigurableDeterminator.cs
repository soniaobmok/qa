using System;
using System.IO;

namespace ExceptionManager
{
    class CriticalExceptionConfigurableDeterminator : ICriticalExceptionDeterminator
    {
        public bool determinate(Exception e)
        {
            using (StreamReader reader = new StreamReader("C:\\Users\\megag\\Desktop\\qa\\laba1\\config.txt")) // todo: fix the path
            {
                String line;

                while ((line = reader.ReadLine()) != null)
                    if (e.GetType().ToString() == line) return true;

                return false;
            }
        }
    }
}

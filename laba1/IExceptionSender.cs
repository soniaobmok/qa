using System;
using System.Collections.Generic;
using System.Text;

namespace laba1
{
    interface IExceptionSender
    {
        public Boolean SendToServer(Exception e);
        public void IncErrorCount();
    }
}

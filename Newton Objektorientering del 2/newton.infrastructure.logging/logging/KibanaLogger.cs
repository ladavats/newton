using newton.infrastructure.logging.logging.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.infrastructure.logging.logging
{
    public class KibanaLogger : ILogger
    {
        public void LogCriticalError(string description, string errormessage)
        {
            throw new NotImplementedException();
        }

        public void LogError(string description, string errormessage)
        {
            throw new NotImplementedException();
        }

        public void LogInfo(string description)
        {
            throw new NotImplementedException();
        }
    }
}

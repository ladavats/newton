using newton.infrastructure.logging.logging.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newton.infrastructure.logging.logging
{
    public class TextFileLogger : ILogger
    {
        public void LogCriticalError(string description, string errormessage)
        {
            
        }

        public void LogError(string description, string errormessage)
        {
            
        }

        public void LogInfo(string description)
        {
            //Logga en rad i en textfil            
        }
    }
}

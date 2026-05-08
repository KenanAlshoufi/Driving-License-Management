using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driving_License_Management.Class_Global
{
    
    public class clsLogging
    {
        public static void SetEventLog(string Message,string LogName, EventLogEntryType type)
        {
            string SourseName = "DVLD";
            if (!EventLog.SourceExists(SourseName))
            {
                EventLog.CreateEventSource(SourseName, LogName);
            }

            EventLog.WriteEntry(SourseName, Message, type);
        }


    }
}

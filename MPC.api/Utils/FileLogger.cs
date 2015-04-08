using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace MPC.Utils
{
    /// <summary>
    /// Class for writing out logs to file
    /// </summary>
    public class FileLogger
    {
        /// <summary>
        /// Log file
        /// </summary>
        private const string LOG_FILE = ".log";

        /// <summary>
        /// Error log file
        /// </summary>
        private const string ERROR_LOG_FILE = ".error.log";

        StreamWriter LogOutput;
        StreamWriter ErrorLogOutput;

        /// <summary>
        /// Sets up Log output to file
        /// </summary>
        /// <param name="Logger">Logger instance in MPC</param>
        public FileLogger(Logger Logger)
        {
            string Now = DateTime.Now.ToString();
            Now = Now.Replace(' ', '.');
            Now = Now.Replace('/', '_');
            Now = Now.Replace(':', '-');

            string LFile = "logs/" + Now + LOG_FILE;
            string ELFile = "logs/" + Now + ERROR_LOG_FILE;

            LogOutput = new StreamWriter(LFile, true);
            ErrorLogOutput = new StreamWriter(ELFile, true);

            LogOutput.AutoFlush = true;
            ErrorLogOutput.AutoFlush = true;

            Logger.MessageRecieved += Logger_MessageRecieved;

            LogOutput.WriteLine("<<  | MPC FILE LOGGER | >>");
            LogOutput.WriteLine("<< Started: " + Now+ " >>");

            ErrorLogOutput.WriteLine("<<  | MPC FILE LOGGER | >>");
            ErrorLogOutput.WriteLine("<< Started: " + Now + " >>");
        }


        /// <summary>
        /// Loads message to the appropriate files
        /// </summary>
        private void Logger_MessageRecieved(string Message, bool WasError)
        {
            if (WasError)
            {
                ErrorLogOutput.WriteLine(DateTime.Now.ToString()+ " | "  + Message);
                Message = "ERROR | " + Message;
            }
            LogOutput.WriteLine(DateTime.Now.ToString() +  " | " + Message);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPC.Utils
{
    /// <summary>
    /// MPC Logging information and external output portal
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Generic log of MPC.
        /// </summary>
        private List<string> MPCLog;

        /// <summary>
        /// Contains only the log entries which are tagged with ERROR.
        /// </summary>
        private List<string> ErrorLog;


        //Event for changing ouput of Log
        public delegate void LogMessageHandler(string Message, bool WasError);


        /// <summary>
        /// Notifies when log recieves message
        /// </summary>
        public event LogMessageHandler MessageRecieved;



        public Logger()
        {
            MPCLog = new List<string>();
            ErrorLog = new List<string>();
        }


        /// <summary>
        /// Log a standard message
        /// </summary>
        /// <param name="Message">Log Message</param>
        public void Log(string Message)
        {
            MPCLog.Add(DateTime.Now.ToString() + " | " + Message);
            OnMessage(Message, false);
        }


        /// <summary>
        /// Log an error message
        /// </summary>
        /// <param name="Message">Error Message</param>
        public void LogError(string Message)
        {
            MPCLog.Add(DateTime.Now.ToString() + " | ERROR | " + Message);
            ErrorLog.Add(DateTime.Now.ToString() + " | ERROR | " + Message);
            OnMessage(Message, true);
        }


        /// <summary>
        /// Fires MessageRecieved event. If there are no listeners, echo message to console
        /// </summary>
        /// <param name="Message">Log Message</param>
        /// <param name="IsError">Error flag</param>
        private void OnMessage(string Message, bool IsError)
        {
            if (MessageRecieved != null)
            {
                MessageRecieved(Message, IsError);
            }

            //If no listener, we just echo to console, by default
            else
            {
                string Output = "> ";
                if (IsError) { Output += "{ERROR} "; }

                Output += Message;
                Console.WriteLine(Output);
            }
        }

    }
}

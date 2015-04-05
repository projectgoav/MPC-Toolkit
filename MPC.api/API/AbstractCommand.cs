using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPC.API
{
    /// <summary>
    /// Provides an abstract Command which reports progress to any listeners to the command.
    /// </summary>
    public abstract class AbstractCommand : ICommand
    {
        //Command events which occur
        public delegate void CommandReportingProgressHandler(int Progress);
        public event CommandReportingProgressHandler ProgressChanged;

        public delegate void CommmandReportingCompletionHandler();
        public event CommmandReportingCompletionHandler CommandComplete;

        public delegate void CommandReportingErrorHandler(Exception e);
        public event CommandReportingErrorHandler CommandError;

        /// <summary>
        /// Number of tasks the run() command will execute, if more than one.
        /// Used when reporting progress to provide a percentage
        /// </summary>
        protected int TaskCount = 1;

        public abstract void Setup();

        public abstract void Run();

        public abstract void TearDown();


        /// <summary>
        /// Reports progress to listener
        /// </summary>
        /// <param name="TasksCompleted">Number of tasks completed when called</param>
        protected void ReportProgress(int TasksCompleted)
        {
            if (ProgressChanged != null)
            {
                ProgressChanged(TasksCompleted / TaskCount);
            }
        }

        /// <summary>
        /// Reports the task was completed to listener
        /// </summary>
        protected void ReportCompletion()
        {
            if (CommandComplete != null)
            {
                CommandComplete();
            }
        }

        /// <summary>
        /// Reports the task was not completed successfully
        /// </summary>
        /// <param name="e">Exception thrown caused by run() failing</param>
        protected void ReportError(Exception e)
        {
            if (CommandError != null)
            {
                CommandError(e);
            }
        }
    }
}

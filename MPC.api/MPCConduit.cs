using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MPC.Commands;

namespace MPC
{
    /// <summary>
    /// Conduit object allowing access to interals of API with default settings and implementation
    /// </summary>
    public class MPCConduit
    {
        /// <summary>
        /// Global settings and configuration file
        /// </summary>
        protected static Global Global;

        /// <summary>
        /// Pools of commands within API. Once added to the poll, they are conducted
        /// </summary>
        public CommandPool CommandPool;

    
        public MPCConduit()
        {
            Global = new Global();
            CommandPool = new CommandPool();
        }


        /// <summary>
        /// Runs a compile of the MPC site
        /// </summary>
        public void RunCompile()
        {
            CommandPool.PutCommand(new CompileCommand());
        }

        /// <summary>
        /// Runs a compile of the MPC site
        /// </summary>
        /// <param name="FullCopy">If True will copy CSS, JS and other design files.</param>
        public void RunCompile(bool FullCopy)
        {
            RunCompile();

            if (FullCopy)
            {
                CommandPool.PutCommand(new CopyCommand());
            }
        }

        /// <summary>
        /// Enables file logging for this application
        /// </summary>
        public void EnableLogging()
        {
            Global.EnableFileLogging();
        }


        //Stupid, for testing purposes
        public string Version() { return "V1.1"; }
    }
}

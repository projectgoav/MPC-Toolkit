using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPC
{
    /// <summary>
    /// Conduit object allowing access to interals of API. This is the default implementation of the API, if you wish to use standard bits with standard settings
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

        //Stupid, for testing purposes
        public string Version() { return "V1.1"; }
    }
}

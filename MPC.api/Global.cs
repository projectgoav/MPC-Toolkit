using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MPC;
using MPC.Utils;

namespace MPC
{
    /// <summary>
    /// Contains Global configuration settings and other global variables during runtime
    /// </summary>
    public class Global
    {
        //Global flag to ensure config is not reset during runtime.
        private static bool ConfigSet = false;

        /// <summary>
        /// MPC Configuration Object
        /// </summary>
        public static Config Config { get; private set; }


        /// <summary>
        /// Set the Configuration for MPC Framework
        /// </summary>
        /// <param name="NewConfig"></param>
        public static void SetConfig(Config NewConfig)
        {
            //Only set if there isn't one already
            if (!ConfigSet)
            {
                Config = NewConfig;
                ConfigSet = true;
            }
        }
    }
}

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
        /// <summary>
        /// MPC Configuration Object
        /// </summary>
        private static Config _Config;

        /// <summary>
        /// MPC Logger
        /// </summary>
        private static Logger _Log;

        private static FileLogger _FileLogger;

        /// <summary>
        /// Gets the Logger used by MPC
        /// </summary>
        public static Logger Log { get { return GetLogger(); } }

        /// <summary>
        /// Get the Config. Same as GetConfig method.
        /// </summary>
        public static Config Config { get { return GetConfig(); } }

        /// <summary>
        /// Get the Global config
        /// </summary>
        /// <returns>Configration Class</returns>
        public static Config GetConfig()
        {
            //Making sure this is only instanciated once
            if (_Config == null)
            {
                _Config = new Config();
            }
            return _Config;
        }

        /// <summary>
        /// Returns Logger instance
        /// </summary>
        /// <returns>MPC Logger</returns>
        public static Logger GetLogger()
        {
            //Making sure this is only instanciated once
            if (_Log == null)
            {
                _Log = new Logger();
            }
            return _Log;
        }

        /// <summary>
        /// Enables File logging in MPC
        /// </summary>
        public static void EnableFileLogging()
        {
            _FileLogger = new FileLogger(Log);
        }
    }



}

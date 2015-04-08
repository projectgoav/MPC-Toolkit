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
    }



}

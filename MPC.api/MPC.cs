using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MPC.api.Commands;
using MPC.api.Configuration;
using MPC.api.IO;

namespace MPC.api
{
    /// <summary>
    /// Main API Controller
    /// </summary>
    public class MPC
    {
        /// <summary>
        /// MPC Global configuration.
        /// Must be set when program loads
        /// </summary>
        public static Config cfg;

        private static Compile Compiler = new Compile();
        private static Publish Uploader;

        /// <summary>
        /// Initilize MPC API
        /// TODO Add startup options here
        /// </summary>
        public static void init()
        {
            cfg = ConfigurationIO.LoadConfig(Config.CONFIG_FILE);
            Uploader = new Publish(cfg.Username);
        }

        /// <summary>
        /// Compile pages here
        /// </summary>
        /// <param name="cmd"></param>
        public static void Compile(string[] cmd)
        {
            Compiler.Run(cmd);
        }

        /// <summary>
        /// Publish pages to server
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static bool Publish(string[] cmd)
        {
            return Uploader.Run(cmd);
        }


    }
}

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
        /// Handles sending of API messages to desination
        /// </summary>
        public static MPCOut MPCOut = new MPCOut();

        /// <summary>
        /// Initilize MPC API
        /// TODO Add startup options here
        /// </summary>
        public static bool init()
        {
            try
            {
                cfg = ConfigurationIO.LoadConfig(Config.CONFIG_FILE);
            }
            catch (Exception e) { MPCOut.SendMessage(e.Message); return false; }
            Uploader = new Publish(cfg.Username);
            return true;
        }

        /// <summary>
        /// Compile pages here
        /// </summary>
        /// <param name="cmd"></param>
        public static void Compile(string[] cmd)
        {
            if (cfg == null)
            {
                MPCOut.SendMessage("Missing configuration file.");
                return;
            }

            Compiler.Run(cmd);
        }

        /// <summary>
        /// Publish pages to server
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static bool Publish(string[] cmd)
        {
            if (cfg == null)
            {
                MPCOut.SendMessage("Missing configuration file.");
                return false;
            }

            return Uploader.Run(cmd);
        }



        public static string GetVersion()
        {
            return "V1.1(A)";
        }


    }
}

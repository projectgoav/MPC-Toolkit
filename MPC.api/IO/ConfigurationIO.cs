using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Nini.Config;

using MPC.api.Configuration;

namespace MPC.api.IO
{
    public class ConfigurationIO
    {
        /// <summary>
        /// Load in configuration to MPC
        /// </summary>
        /// <param name="Filename">Location of config.ini</param>
        /// <returns>Loaded configuration object</returns>
        public static Config LoadConfig(string Filename)
        {
            Config cfg = new Config();

            try
            {
                IniConfigSource s = new IniConfigSource(Config.CONFIG_FILE);

                //Template Sources
                cfg.HeaderTemplate = s.Configs["Templates"].GetString("Header");
                cfg.FooterTemplate = s.Configs["Templates"].GetString("Footer");
                cfg.NavTemplate = s.Configs["Templates"].GetString("NavBar");
                cfg.ModalTemplate = s.Configs["Templates"].GetString("Modal");

                //Where to Publish finished products
                cfg.PublishLocation = s.Configs["Sources"].GetString("Publish");

                //Get all the pages to fix & where they are stored
                cfg.Pages = s.Configs["Sources"].GetString("Pages").Split(',');
                cfg.Folders = s.Configs["Sources"].GetString("Folders").Split(',');
                cfg.SourceLocation = s.Configs["Sources"].GetString("Source");
                cfg.DesignLocation = s.Configs["Sources"].GetString("Design");

                cfg.Username = s.Configs["FTP"].GetString("Username");

                Console.WriteLine(">> Configuration loaded!");

                return cfg;
            }
            catch (Exception e) { Console.WriteLine("MPC>> * Configuration file error *\nMessage: {0} \n\nTrace: {1}", e.Message, e.StackTrace); return null; }
        }

    }
}

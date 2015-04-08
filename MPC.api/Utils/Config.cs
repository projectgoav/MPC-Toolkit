using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using Nini.Config;

namespace MPC.Utils
{
    /// <summary>
    /// Configuration details of the MPC API
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Creates and loads in the given configuration options
        /// </summary>
        public Config()
        {
            try
            {
                IniConfigSource s = new IniConfigSource(CONFIG_FILE);

                //Template Sources
                HeaderTemplate = s.Configs["Templates"].GetString("Header");
                FooterTemplate = s.Configs["Templates"].GetString("Footer");
                NavTemplate = s.Configs["Templates"].GetString("NavBar");
                ModalTemplate = s.Configs["Templates"].GetString("Modal");

                //Where to Publish finished products
                PublishLocation = s.Configs["Sources"].GetString("Publish");

                //Get all the pages to fix & where they are stored
                Pages = s.Configs["Sources"].GetString("Pages").Split(',');
                Folders = s.Configs["Sources"].GetString("Folders").Split(',');
                SourceLocation = s.Configs["Sources"].GetString("Source");
                DesignLocation = s.Configs["Sources"].GetString("Design");

                Username = s.Configs["FTP"].GetString("Username");
            }
               
            // Simple throw here
            // TODO make better
            catch (Exception e) { throw e; }
        }


        /// <summary>
        /// Fixed location of configuration ini file
        /// </summary>
        public const string CONFIG_FILE = "Config.ini";

        //[[ TEMAPLATES ]]\\

        /// <summary>
        /// Location of the Header template code
        /// </summary>
        public string HeaderTemplate { get; set; }

        /// <summary>
        /// Location of the Footer template code
        /// </summary>
        public string FooterTemplate { get; set; }

        /// <summary>
        /// Location of the Navbar template code
        /// </summary>
        public string NavTemplate { get; set; }

        /// <summary>
        /// Location of the Modal data for the groups page
        /// </summary>
        public string ModalTemplate { get; set; }

        //[[ PAGES ]]\\

        /// <summary>
        /// List of pages to be compiled
        /// </summary>
        public string[] Pages { get; set; }

        /// <summary>
        /// List of folders to be copied to publish loccation
        /// </summary>
        public string[] Folders { get; set; }

        //[[ FOLDERS]]\\

        /// <summary>
        /// Root directory containing all code for website
        /// </summary>
        public string SourceLocation { get; set; }

        /// <summary>
        /// Path to Design folders, taken from Source
        /// </summary>
        public string DesignLocation { get; set; }

        /// <summary>
        /// Path to compile output directory, taken from Source
        /// </summary>
        public string PublishLocation { get; set; }

        //[[ FTP ]]\\

        /// <summary>
        /// FTP Username
        /// </summary>
        public string Username { get; set; }
    }
}

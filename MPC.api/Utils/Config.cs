using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPC.Utils
{
    /// <summary>
    /// Configuration details of the MPC API
    /// </summary>
    public class Config
    {
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

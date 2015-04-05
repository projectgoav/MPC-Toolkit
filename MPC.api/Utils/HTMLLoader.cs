using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace MPC.Utils
{
    /// <summary>
    /// Performs HTML load operations on template files for application
    /// </summary>
    public class HTMLLoader
    {

        /// <summary>
        /// Load and read in data from given HTML file as one long line
        /// </summary>
        /// <param name="Filename">HTML file to load</param>
        /// <returns>Data from HTML Line on one line or exits if error occured</returns>
        public string Load(string Filename)
        {
            try
            {
                string HTML = "";
                string[] Buffer = File.ReadAllLines(Filename);

                foreach (string Line in Buffer) { HTML += Line; }

                return HTML;
            }
            catch (Exception e)
            {
                Console.WriteLine("MPC>> * Error loading in HTML Document {0} *\nMessage: {1} \n\nTrace: {2}", Filename, e.Message, e.StackTrace);
                Console.WriteLine("\n\n>> Exited with error code 0x4"); System.Environment.Exit(4);
                return null;
            }
        }
    }
}

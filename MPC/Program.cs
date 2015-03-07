using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using Nini.Config;
using MPC.api;

namespace MPC
{
    /// <summary>
    /// MPC helper program for use when developing the Website
    /// </summary>
    class Program
    {
        private string[] Commands = { "compile", "publish", "clean" };


        /// <summary>
        /// Entry point to application
        /// </summary>
        static void Main(string[] args)
        {
            Program me = new Program();
            me.Run();
            Console.WriteLine("> Bye!");
        }


        /// <summary>
        /// Main Program loop which deals with input and dispatches to tasks
        /// </summary>
        private void Run()
        {
            //Load configuration settings and close if they are equal to null
            api.MPC.init();

            //Enter Main Command Loop and get input from user
            Console.Write("MPC> ");
            string[] cmd = Console.ReadLine().ToLower().Split(' ');

            //Just loop until we get a quit
            while (cmd[0] != "quit")
            {
                if (Commands.Contains(cmd[0]) == false) { Console.WriteLine(">> Invalid command"); }
                else
                {
                    switch (cmd[0])
                    {
                        case "compile": { api.MPC.Compile(null); break; }
                        case "clean":   { Clean(cmd); break; }
                        case "publish": { api.MPC.Publish(null); break; }
                    }
                }

                //Get next input
                Console.Write("MPC> ");
                cmd = Console.ReadLine().ToLower().Split(' ');
            }

        }

        private static void Clean(string[] cmd)
        {
            Console.WriteLine(">> Nothing to clean.");
        }

    }
}

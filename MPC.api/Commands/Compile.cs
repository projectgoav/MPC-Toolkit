using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using MPC.api.IO;
using MPC.api.Configuration;

namespace MPC.api.Commands
{
    public class Compile
    {
        /// <summary>
        /// Run the compilation command
        /// </summary>
        /// <param name="cmd"></param>
        public void Run(string[] cmd)
        {
            HTMLLoader PageLoader = new HTMLLoader();

            DateTime First = DateTime.Now;

            //Load in Template Text
            string Header = PageLoader.Load(MPC.cfg.SourceLocation + MPC.cfg.HeaderTemplate);
            string Footer = PageLoader.Load(MPC.cfg.SourceLocation + MPC.cfg.FooterTemplate);
            string NavBar = PageLoader.Load(MPC.cfg.SourceLocation + MPC.cfg.NavTemplate);
            string Modals = PageLoader.Load(MPC.cfg.SourceLocation + MPC.cfg.ModalTemplate);

            Console.WriteLine("> Loaded templates");


            for (int i = 0; i < MPC.cfg.Pages.Length; ++i)
            {
                Console.Write("> (working) Page: {0}", MPC.cfg.Pages[i]);

                string PageTitle = MPC.cfg.Pages[i].Replace(".html", "");
                string PageNav = NavBar;
                string PageContent = null;

                switch (PageTitle)
                {
                    case "index": { PageNav = PageNav.Replace("id=\"Home\"", "id=\"Home_A\""); break; }
                    case "worship": { PageNav = PageNav.Replace("id=\"Worship\"", "id=\"Worship_A\""); break; }
                    case "people": { PageNav = PageNav.Replace("id=\"People\"", "id=\"People_A\""); break; }
                    case "find": { PageNav = PageNav.Replace("id=\"Contact\"", "id=\"Contact_A\""); break; }
                    case "future": { PageNav = PageNav.Replace("id=\"Future\"", "id=\"Future_A\""); break; }

                    //We need to do something special here and load in our modals for the Groups
                    case "groups":
                        {
                            PageNav = PageNav.Replace("id=\"Groups\"", "id=\"Groups_A\"");
                            PageNav += Modals;
                            break;
                        }


                    default: break;
                }

                //Put the page together and save elsewhere
                PageContent = Header + PageNav;
                PageContent += PageLoader.Load(MPC.cfg.SourceLocation + MPC.cfg.Pages[i]);
                PageContent += Footer;

                File.WriteAllText(MPC.cfg.PublishLocation + MPC.cfg.Pages[i], PageContent);
                Console.Write("\r> (DONE) Page: {0}                          \n", MPC.cfg.Pages[i]);
            }

            Console.Write("\n> (working) Copying design files...");

            //Copy all directories
            for (int i = 0; i < MPC.cfg.Folders.Length; ++i)
            {
                FileSystemAccess.DirectoryCopy(MPC.cfg.DesignLocation + MPC.cfg.Folders[i], MPC.cfg.PublishLocation + MPC.cfg.Folders[i], true);
            }
            
            Console.Write("\r> (DONE) Copied design files          \n");

            DateTime Second = DateTime.Now;
            TimeSpan TimeTaken = Second - First;

            Console.WriteLine("\n> Compiled {0} page(s) in {1}ms\n", MPC.cfg.Pages.Length, TimeTaken.TotalMilliseconds);
        }
    }
}

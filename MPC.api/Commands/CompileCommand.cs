using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using MPC;
using MPC.API;
using MPC.Utils;

namespace MPC.Commands
{
    public class CompileCommand : AbstractCommand
    {
        private HTMLLoader PageLoader;
        private string[] Pages;
        private string SourceLocation;
        private string CopyLocation;
        private string[] Extensions;

        private TimeSpan TimeTaken;

        public CompileCommand()
        {
            Setup();
        }

        //Instanciate objects and create a working copy of the settings, so to speed up access time.
        public override void Setup()
        {
            PageLoader = new HTMLLoader();

            Pages = Global.Config.Pages;
            SourceLocation = Global.Config.SourceLocation;
            CopyLocation = Global.Config.PublishLocation;

            Extensions = new string[4];

            Extensions[0] = Global.Config.HeaderTemplate;
            Extensions[1] = Global.Config.FooterTemplate;
            Extensions[2] = Global.Config.NavTemplate;
            Extensions[3] = Global.Config.ModalTemplate;

            TaskCount = Pages.Length;
        }

        public override void TearDown()
        {
            throw new NotImplementedException();
        }


        public override void Run()
        {
            DateTime First = DateTime.Now;

            //Load in Template Text
            string Header = PageLoader.Load(SourceLocation + Extensions[0]);
            string Footer = PageLoader.Load(SourceLocation + Extensions[1]);
            string NavBar = PageLoader.Load(SourceLocation + Extensions[2]);
            string Modals = PageLoader.Load(SourceLocation + Extensions[3]);

            //MPC.MPCOut.SendMessage("> Loaded templates");

            for (int i = 0; i < Pages.Length; ++i)
            {
                //MPC.MPCOut.SendMessage("> (working) Page: " + MPC.cfg.Pages[i]);

                string PageTitle = Pages[i].Replace(".html", "");
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
                PageContent += PageLoader.Load(SourceLocation + Pages[i]);
                PageContent += Footer;

                // AS OF 1.1: Error checking with writing to the file, casue why wouldn't it not work?
                try
                {
                    File.WriteAllText(CopyLocation + Pages[i], PageContent);
                }
                catch (Exception e)
                {
                    ReportError(e);
                    return;
                }

                ReportProgress(i);

                //MPC.MPCOut.SendMessage("\r> (DONE) Page: {0} " + MPC.cfg.Pages[i] + "                       \n");
            }

            //MPC.MPCOut.SendMessage("\n> (working) Copying design files...");
            DateTime Second = DateTime.Now;
            TimeTaken = Second - First;

            ReportCompletion();

            //MPC.MPCOut.SendMessage("\n> Compiled {0} page(s) in {1}ms\n", MPC.cfg.Pages.Length, TimeTaken.TotalMilliseconds);
        }
    }
}

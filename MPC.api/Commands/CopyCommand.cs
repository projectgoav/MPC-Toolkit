using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MPC;
using MPC.API;
using MPC.Utils;

namespace MPC.Commands
{
    /// <summary>
    /// Copies over the design CSS, JS and other files required when publishing MPC
    /// </summary>
    public class CopyCommand : ICommand
    {
        private string SourceLocation;
        private string CopyLocation;
        private string[] Folders;

        public void Setup()
        {
            SourceLocation = Global.Config.DesignLocation;
            CopyLocation = Global.Config.PublishLocation;
            Folders = Global.Config.Folders;
        }

        public void Run()
        {
            //Copy all directories
            for (int i = 0; i < Folders.Length; ++i)
            {
                FileSystemAccess.DirectoryCopy(SourceLocation + Folders[i], CopyLocation + Folders[i], true);
            }
        }

        public void TearDown()
        {
            throw new NotImplementedException();
        }


    }
}

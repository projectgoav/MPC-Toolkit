using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPC.API
{
    /// <summary>
    /// Defines a Command as part of the MPC API
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Perform any pre-command setup code. Loading in settings should be done here.
        /// </summary>
        void Setup();

        /// <summary>
        /// Run the actual task in the API setting
        /// </summary>
        void Run();

        /// <summary>
        /// Perform any after-runtime actions, such as updating settings.
        /// </summary>
        void TearDown();
    }
}

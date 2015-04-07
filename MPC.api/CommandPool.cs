using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MPC.API;

namespace MPC
{
    /// <summary>
    /// Defines a pool where commands sit, waiting to be executed
    /// </summary>
    public class CommandPool
    {
        private delegate void OnPoolHandler();
        private event OnPoolHandler OnCommandPooled;
  
        //Stores commands waiting to be run
        Queue<ICommand> Pool;

        public CommandPool()
        {
            Pool = new Queue<ICommand>();
            OnCommandPooled += CommandPool_OnCommandPooled;
        }

        /// <summary>
        /// Runs tasks that have been added to the pool.
        /// </summary>
        private void CommandPool_OnCommandPooled()
        {
            while (Pool.Count > 0)
            {
                Pool.Dequeue().Run();
            }
        }

        /// <summary>
        /// Places a command into the pool.
        /// </summary>
        /// <param name="C">Command to be added.</param>
        public void PutCommand(ICommand C)
        {
            Pool.Enqueue(C);
            OnCommandPooled();  //Make sure to tell the pool we have some data in it
        }

        /// <summary>
        /// Gets current size of Pool
        /// <remarks>
        /// NOTE: As events are single threaded, this should always return a value less than 1
        /// </remarks>
        /// </summary>
        public int PoolSize { get { return Pool.Count; } }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPC.api
{
    //Defines API output
    public class MPCOut
    {
        public delegate void APIMessageHandler(string Message);
        public event APIMessageHandler OnAPIMessage;


        //Handles sending a message to either the console, or to the Program that has attached to the API
        protected virtual void SendMessage(string Message)
        {
            if (OnAPIMessage != null)
            {
                OnAPIMessage(Message);
            }
            else
            {
                Console.WriteLine(Message);
            }
        }

    }
}

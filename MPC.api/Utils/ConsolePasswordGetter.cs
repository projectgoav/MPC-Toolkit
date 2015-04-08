using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPC.Utils
{
    /// <summary>
    /// Gets a password from the console, masking it from other people
    /// </summary>
    public class ConsolePasswordGetter
    {
        private string _Password;

        /// <summary>
        /// Gets the password that has been entered. Will be null until you've called Get()
        /// </summary>
        public string Password { get { return _Password; } }

        public char PasswordChar { get; set; }

        public ConsolePasswordGetter()
        {
            _Password = null;
            PasswordChar = '~';
        }

        /// <summary>
        /// Gets console input from user
        /// </summary>
        public void Get()
        {
            string UserPassword = "";
            string letter = Console.ReadKey(true).KeyChar.ToString();

            while (letter != "\r")
            {
                if (letter == "\b")
                {
                    if (UserPassword.Length != 0) { UserPassword = UserPassword.Substring(0, UserPassword.Length - 1); }
                }
                else { UserPassword += letter; }

                letter = Console.ReadKey(true).KeyChar.ToString();
            }

            _Password = UserPassword;
        }

        /// <summary>
        /// Clears Password from memory
        /// </summary>
        public void Clear()
        {
            _Password = null; 
        }


    }
}

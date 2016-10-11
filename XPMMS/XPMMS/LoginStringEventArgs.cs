using System;
using System.Collections.Generic;
using System.Text;
//using Android.Drm;

namespace XPMMS
{
    public class LoginStringEventArgs : EventArgs
    {
        /// <summary>
        /// A custom event that carries over a just registered user's login details to the login page for convenience's sake.
        /// This way of doing it was based on a suggestion from: http://blog.adamkemp.com/2015/03/decoupling-views.html
        /// </summary>

        public string StringArgs { get; private set; }

        public LoginStringEventArgs(string args)
        {
            StringArgs = args;
        }
    }
}

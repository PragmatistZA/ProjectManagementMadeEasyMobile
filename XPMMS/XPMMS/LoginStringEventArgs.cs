using System;
using System.Collections.Generic;
using System.Text;
using Android.Drm;

namespace XPMMS
{
    public class LoginStringEventArgs : EventArgs
    {
        public string StringArgs { get; private set; }

        public LoginStringEventArgs(string args)
        {
            StringArgs = args;
        }
    }
}

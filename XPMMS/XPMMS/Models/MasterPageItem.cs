using System;
using System.Collections.Generic;
using System.Text;

namespace XPMMS.Models
{
    /// <summary>
    /// This class represents the structure of an item on the logout hamburger menu.
    /// </summary>

    public class MasterPageItem
    {
        public string Title { get; set; }

        public string IconSource { get; set; }

        public Type TargetType { get; set; }
    }
}

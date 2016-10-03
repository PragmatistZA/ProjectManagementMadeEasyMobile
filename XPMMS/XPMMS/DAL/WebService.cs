using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagementMadeEasyApp.Helpers;

namespace XPMMS.DAL
{
    class WebService
    {
        private readonly pmmeWS _pmmeWS = new pmmeWS();

        public void AddNewUser(string firstName, string lastName, string email, string password)
        {
            _pmmeWS.BeginaddNewUser(firstName, lastName, email, SHA1.Encode(password), delegate { }, new object());
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;

namespace ProjectManagementMadeEasyApp.Models
{
    public class UserModel
    {
        public int User_ID { get; set; }

        public int Team_ID { get; set; }

        public string Team_Name { get; set; }

        public string Title { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Contact { get; set; }

        public string Job_Desc { get; set; }
    }
}
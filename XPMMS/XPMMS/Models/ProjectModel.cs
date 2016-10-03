using System;

namespace XPMMS.Models
{
    public class ProjectModel
    {
        public int Proj_ID { get; set; }

        public int Proj_Manager_ID { get; set; }

        public string Proj_Desc { get; set; }

        public DateTime Proj_Due { get; set; }

        public string Project_Name { get; set; }
    }
}
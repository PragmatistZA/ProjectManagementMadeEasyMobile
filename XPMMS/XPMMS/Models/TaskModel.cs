using System;

namespace XPMMS.Models
{
    public class TaskModel
    {
        public int Task_ID { get; set; }

        public int Project_ID { get; set; }

        public string Task_Desc { get; set; }

        public int Time_Req { get; set; }

        public DateTime Task_Created { get; set; }

        public DateTime Task_Due { get; set; }

        public int Status { get; set; }
    }
}
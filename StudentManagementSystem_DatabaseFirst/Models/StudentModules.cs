using System;
using System.Collections.Generic;

namespace StudentManagementSystem_DatabaseFirst.Models
{
    public partial class StudentModules
    {
        public string AdminNo { get; set; }
        public string ModuleId { get; set; }

        public virtual Students AdminNoNavigation { get; set; }
        public virtual Modules Module { get; set; }
    }
}

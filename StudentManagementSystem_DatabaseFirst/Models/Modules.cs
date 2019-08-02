using System;
using System.Collections.Generic;

namespace StudentManagementSystem_DatabaseFirst.Models
{
    public partial class Modules
    {
        public Modules()
        {
            StudentModules = new HashSet<StudentModules>();
        }

        public string ModuleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentModules> StudentModules { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace StudentManagementSystem_DatabaseFirst.Models
{
    public partial class Students
    {
        public Students()
        {
            StudentModules = new HashSet<StudentModules>();
        }

        public string AdminNo { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string DiplomaId { get; set; }

        public virtual Diploma Diploma { get; set; }
        public virtual Addresses Addresses { get; set; }
        public virtual ICollection<StudentModules> StudentModules { get; set; }
    }
}

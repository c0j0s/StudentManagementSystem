using System;
using System.Collections.Generic;

namespace StudentManagementSystem_DatabaseFirst.Models
{
    public partial class Diploma
    {
        public Diploma()
        {
            Students = new HashSet<Students>();
        }

        public string DiplomaId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Students> Students { get; set; }
    }
}

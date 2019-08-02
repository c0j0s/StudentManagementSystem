using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem_CodeFirst.Models
{
    public class Student {
        public string AdminNo { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }

        public Address Address { get; set; }

        public string DiplomaId { get; set; }
        public Diploma Diploma { get; set; }

        public ICollection<StudentModules> StudentModules { get; set; }
    }
}

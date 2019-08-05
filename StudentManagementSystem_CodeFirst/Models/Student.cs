using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem_CodeFirst.Models
{
    public class Student {
        //Since our primary key does not end with "ID"
        [Key]
        [StringLength(7)]
        public string AdminNo { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        //We only want to store date
        [DataType(DataType.Date)]
        //Display name
        [Display(Name = "Date of Birth")]
        public DateTime Dob { get; set; }

        //Since we only want "M" or "F"
        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [Required]
        // A regular expression for Singapore telephone number
        [RegularExpression(@"(6|8|9)\d{7}",
            ErrorMessage = "Invalid Phone Number!")]
        [Display(Name = "Handphone")]
        public string ContactNumber { get; set; }

        public Address Address { get; set; }

        [Required]
        [Display(Name = "Diploma")]
        public string DiplomaId { get; set; }
        public Diploma Diploma { get; set; }

        public ICollection<StudentModules> StudentModules { get; set; }
    }
}

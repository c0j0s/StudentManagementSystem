using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem_CodeFirst.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        [Required]
        public string StreetName { get; set; }
        public string Details { get; set; }

        [Required]
        // Valid Singapore postal code range
        [Range(010000, 999999)]
        public int PostalCode { get; set; }

        // We do not want to map this to a table field
        [NotMapped]
        public string FullAddress
            => $"{StreetName} {Details}, Singapore {PostalCode}";


        public int StudentId { get; set; }
        public Student Student { get; set; }

    }

}

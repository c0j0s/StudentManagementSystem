using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem_CodeFirst.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string StreetName { get; set; }
        public string Details { get; set; }
        public int PostalCode { get; set; }
<<<<<<< Updated upstream
=======

        // We do not want to map this to a table field
        [NotMapped]
        public string FullAddress
            => $"{StreetName} {Details}, Singapore {PostalCode}";

        public string AdminNo { get; set; }
        public Student Student { get; set; }

>>>>>>> Stashed changes
    }

}

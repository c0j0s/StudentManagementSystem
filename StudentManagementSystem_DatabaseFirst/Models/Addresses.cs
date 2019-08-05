using System;
using System.Collections.Generic;

namespace StudentManagementSystem_DatabaseFirst.Models
{
    public partial class Addresses
    {
        public int AddressId { get; set; }
        public string StreetName { get; set; }
        public string Details { get; set; }
        public int PostalCode { get; set; }
        public string AdminNo { get; set; }

        public virtual Students AdminNoNavigation { get; set; }
    }
}

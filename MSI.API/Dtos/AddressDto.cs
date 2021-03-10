using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSI.API.Dtos
{
    public class AddressDto
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}

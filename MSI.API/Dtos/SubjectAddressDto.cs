using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSI.API.Dtos
{
    public class SubjectAddressDto
    {
        public AddressDto Address { get; set; }
        public NameDto Subject { get; set; }
    }
}

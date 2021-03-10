using System.Collections.Generic;


namespace MSI.Domain
{
    public class Address
    {
        public Address()
        {
            SubjectAddresses = new HashSet<SubjectAddress>();
        }

        public int AddressId { get; set; }
        public string StreetNumber { get; set; }
        public string Direction { get; set; }
        public string StreetName { get; set; }
        public string StreetType { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public virtual ICollection<SubjectAddress> SubjectAddresses { get; set; }
    }
}

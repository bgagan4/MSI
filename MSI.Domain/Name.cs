using System.Collections.Generic;

namespace MSI.Domain
{
    public class Name
    {
        public Name()
        {
            SubjectAddresses = new HashSet<SubjectAddress>();
        }

        public int SubjectId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mi { get; set; }
        public string Suffix { get; set; }

        public virtual ICollection<SubjectAddress> SubjectAddresses { get; set; }
    }
}

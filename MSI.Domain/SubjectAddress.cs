namespace MSI.Domain
{
    public class SubjectAddress
    {
        public int SubjectAddressId { get; set; }
        public int SubjectId { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Name Subject { get; set; }
    }
}

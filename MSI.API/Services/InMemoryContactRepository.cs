using MSI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSI.API.Services
{
    public class InMemoryContactRepository : IContactRepository
    {
        private readonly List<SubjectAddress> _subjectAddresses;
        public InMemoryContactRepository()
        {
            _subjectAddresses = new List<SubjectAddress>
            {
                new SubjectAddress
                {
                    SubjectAddressId = 1,
                    AddressId = 1,
                    SubjectId = 1,
                    Address = new Address
                    {
                        AddressId = 1,
                        StreetNumber = "1",
                        Direction = "Left",
                        StreetName = "street",
                        StreetType = "type",
                        City = "city",
                        State = "state",
                        Zip = "zip"
                    },
                    Subject = new Name
                    {
                        SubjectId = 1,
                        FirstName = "FirstName",
                        LastName = "LastName",
                        Mi = "Mi",
                        Suffix = "Suffix"
                    }
                },

                new SubjectAddress
                {
                    SubjectAddressId = 2,
                    AddressId = 2,
                    SubjectId = 2,
                    Address = new Address
                    {
                        AddressId = 2,
                        StreetNumber = "2",
                        Direction = "Left",
                        StreetName = "street",
                        StreetType = "type",
                        City = "city",
                        State = "state",
                        Zip = "zip"
                    },
                    Subject = new Name
                    {
                        SubjectId = 2,
                        FirstName = "FirstName",
                        LastName = "LastName",
                        Mi = "Mi",
                        Suffix = "Suffix"
                    }
                }
            };
        }

        public bool AddSubjectAddress(SubjectAddress subjectAddress)
        {
            var maxSubjectAddressId = _subjectAddresses.Max(x => x.SubjectAddressId);
            subjectAddress.SubjectAddressId = maxSubjectAddressId + 1;
            subjectAddress.AddressId = _subjectAddresses.First(x => x.SubjectAddressId == maxSubjectAddressId).AddressId + 1;
            subjectAddress.SubjectId = _subjectAddresses.First(x => x.SubjectAddressId == maxSubjectAddressId).SubjectId + 1;
            _subjectAddresses.Add(subjectAddress);

            return true;
        }

        public IList<SubjectAddress> GetAllSubjectAddresses()
        {
            return _subjectAddresses;
        }

        public SubjectAddress GetSubjectAddressById(int id)
        {
            return _subjectAddresses.First(x => x.SubjectAddressId == id);
        }
    }
}

using MSI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSI.API.Services
{
    public interface IContactRepository
    {
        bool AddSubjectAddress(SubjectAddress subjectAddress);
        SubjectAddress GetSubjectAddressById(int id);
        IList<SubjectAddress> GetAllSubjectAddresses();
    }
}

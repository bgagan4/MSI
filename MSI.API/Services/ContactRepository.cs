using Microsoft.EntityFrameworkCore;
using MSI.Data;
using MSI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSI.API.Services
{
    public class ContactRepository : IContactRepository, IDisposable
    {
        private ContactContext _contactContext;

        public ContactRepository(ContactContext contactContext)
        {
            _contactContext = contactContext;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool AddSubjectAddress(SubjectAddress subjectAddress)
        {
            if (subjectAddress == null)
            {
                throw new ArgumentNullException(nameof(subjectAddress));
            }

            if (subjectAddress.Address == null)
            {
                throw new ArgumentNullException(nameof(subjectAddress.Address));
            }

            if (subjectAddress.Subject == null)
            {
                throw new ArgumentNullException(nameof(subjectAddress.Subject));
            }

            //Save Subject, Address and relation in that order.
            _contactContext.Add(subjectAddress.Subject);
            _contactContext.Add(subjectAddress.Address);
            _contactContext.Add(subjectAddress);

            return _contactContext.SaveChanges() > 0;

        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_contactContext != null)
                {
                    _contactContext.Dispose();
                    _contactContext = null;
                }
            }
        }

        public SubjectAddress GetSubjectAddressById(int id)
        {
            return _contactContext.SubjectAddresses.Include(i => i.Subject)
               .Include(i => i.Address)
               .FirstOrDefault(x => x.SubjectAddressId == id);
        }

        public IList<SubjectAddress> GetAllSubjectAddresses()
        {
            return _contactContext.SubjectAddresses
                .Include(i => i.Subject)
               .Include(i => i.Address)
               .ToList();
        }
    }
}

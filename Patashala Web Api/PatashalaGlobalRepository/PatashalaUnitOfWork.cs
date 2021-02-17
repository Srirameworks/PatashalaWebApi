using Patashala_Web_Api.Models;
using Patashala_Web_Api.PatashalaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patashala_Web_Api.PatashalaGlobalRepository
{
    public class PatashalaUnitOfWork:IDisposable
    {
        // Part 1
        private PatashalaDbContext context = new PatashalaDbContext();
        private PatashalaRepository<Address> addressRepository;
        private PatashalaRepository<Students> studentRepository;
        private PatashalaRepository<AuthModel> authModelRepository;
      

        public PatashalaRepository<Address> AddressRepository
        {
            get
            {
                if (this.addressRepository == null)
                {
                    this.addressRepository = new PatashalaRepository<Address>(context);
                }
                return addressRepository;
            }
        }

        public PatashalaRepository<Students> StudentRepository
        {
            get
            {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new PatashalaRepository<Students>(context);
                }
                return studentRepository;
            }
        }


        public PatashalaRepository<AuthModel> AuthModelRepository
        {
            get
            {
                if (this.authModelRepository == null)
                {
                    this.authModelRepository = new PatashalaRepository<AuthModel>(context);
                }
                return authModelRepository;
            }
        }


        // Part 2
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
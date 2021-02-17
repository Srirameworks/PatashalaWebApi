using Patashala_Web_Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Patashala_Web_Api.PatashalaContext
{
    public class PatashalaDbContext:DbContext
    {
        public PatashalaDbContext() : base("testdb") {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Address> _Address { get; set; }
        public virtual DbSet<Students> _Students { get; set; }
        public virtual DbSet<Subject> _Subjects { get; set; }
        public virtual DbSet<Teachers> _Teachers { get; set; }
        public virtual DbSet<AuthModel> _AuthModel { get; set; }

    }
}
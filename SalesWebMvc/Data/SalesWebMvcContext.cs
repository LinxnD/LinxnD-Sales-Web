using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWebMvc.Data
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext (DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Departament> Departament { get; set; }
        public DbSet<Seller> seller { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }

        internal List<Departament> OrderBy(Func<object, object> value)
        {
            throw new NotImplementedException();
        }

        internal List<Departament> ToList()
        {
            throw new NotImplementedException();
        }
    }
}

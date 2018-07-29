using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using iCiS.Models;

namespace iCiS.Data

{
    public class iCiSContext : DbContext
    {
        public iCiSContext (DbContextOptions<iCiSContext> options) : base(options)
        {
        }

        public DbSet<iCiS.Models.Servidor> Servidores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servidor>().ToTable("Servidores");
        }
    }
}

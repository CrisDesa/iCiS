using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace iCiS.Models
{
    public class iCiSContext : DbContext
    {
        public iCiSContext (DbContextOptions<iCiSContext> options)
            : base(options)
        {
        }

        public DbSet<iCiS.Models.Servidor> Servidor { get; set; }
    }
}

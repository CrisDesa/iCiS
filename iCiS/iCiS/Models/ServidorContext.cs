using Microsoft.EntityFrameworkCore;


namespace iCiS.Models
{
    public class ServidorContext : DbContext
    {
        public ServidorContext(DbContextOptions<ServidorContext> options)
            : base(options)
        {
        }

        public DbSet<Servidor> Servidor { get; set; }
    }
}

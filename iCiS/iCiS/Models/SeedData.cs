using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System;
using iCiS.Data;

namespace iCiS.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ServidorContext(
                serviceProvider.GetRequiredService<DbContextOptions<ServidorContext>>()))
            {
                // revisa para ver si existe algun servidor
                if (context.Servidor.Any())
                {
                    return; // la base ha sido minada
                }
                context.Servidor.AddRange();
                context.SaveChanges();
            }
        }
    }
}

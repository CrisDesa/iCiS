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
            using (var context = new iCiSContext(
                serviceProvider.GetRequiredService<DbContextOptions<iCiSContext>>()))
            {
                // revisa para ver si existe algun servidor
                if (context.Servidores.Any())
                {
                    return; // la base ha sido minada
                }
                context.Servidores.AddRange(

                    new Servidor
                    {
                        Nombre = "Servidor2",
                        Conexion = true,
                        Fecha_captura = DateTime.Now
                    },

                    new Servidor
                    {
                        Nombre = "Servidor3",
                        Conexion = false,
                        Fecha_captura = DateTime.Now
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}

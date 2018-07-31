using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System;

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
                context.Servidor.AddRange(
                    new Servidor
                    {
                        ID = 1,
                        Nombre = "servidor1",
                        Conexion = true,
                        Fecha_captura = "2018-07-31"
                    },
                    new Servidor
                    {
                        ID = 2,
                        Nombre = "Primero",
                        Conexion = false,
                        Fecha_captura = DateTime.Now.ToString("yyyy-MM-dd")
                    },
                    new Servidor
                    {
                        ID = 3,
                        Nombre = "Segundo",
                        Conexion = false,
                        Fecha_captura = "2018-06-29"
                    }


                    );
                context.SaveChanges();
            }
        }
    }
}

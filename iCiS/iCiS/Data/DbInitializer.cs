using System;
using System.Linq;
using iCiS.Models;

namespace iCiS.Data
{
    public class DbInitializer
    {
        public static void Initialize(iCiSContext context)
        {
            context.Database.EnsureCreated();
            // ver algun servidor
            if (context.Servidores.Any())
            {
                return; // DB ha sido iniciada
            }

            var servidores = new Servidor[]
            {
                new Servidor{ID=2,Nombre="Primero",Conexion=false,Fecha_captura=DateTime.Now },
                new Servidor{ID=3,Nombre="Segundo",Conexion=false,Fecha_captura=DateTime.Now }
            };
            foreach (Servidor s in servidores)
            {
                context.Servidores.Add(s);
            }
            context.SaveChanges();

        }
    }
}

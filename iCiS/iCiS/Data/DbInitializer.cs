using System;
using System.Linq;
using iCiS.Models;

namespace iCiS.Data
{
    public class DbInitializer
    {
        public static void Initialize(ServidorContext context)
        {
            context.Database.EnsureCreated();
            // ver algun servidor
            if (context.Servidor.Any())
            {
                return; // DB ha sido iniciada
            }

            var servidores = new Servidor[]
            {
           };
            foreach (Servidor s in servidores)
            {
                context.Servidor.Add(s);
            }
            context.SaveChanges();

        }
    }
}

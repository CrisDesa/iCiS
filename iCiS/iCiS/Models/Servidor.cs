using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iCiS.Models
{
    public class Servidor
    {
        public int ID { get; set;  }
        public string Nombre { get; set; }
        public string Sistema_operativo { get; set; }
        public DateTime Fecha_captura { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class RegistroAlmacen
    {
        public int IdRegistro { get; set; }
        public int IdSucursal { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }

    }
}

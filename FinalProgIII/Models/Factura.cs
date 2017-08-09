using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProgIII.Models
{
    public class Factura
    {
        public int FacturaID { get; set; }
        public int ClienteID { get; set; }
        public string EmailCliente { get; set; }
        public int ProductoID { get; set; }
        public decimal Precio { get; set; }

        public virtual Clientes Clientes { get; set; }
        public List<Producto> Juegos { get; set; }
    }
}
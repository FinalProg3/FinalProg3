using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProgIII.Models
{
    public class Ventas
    {
        [Key]
        public int VentaID { get; set; }
        public int ClienteID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public System.DateTime FechaPedido { get; set; }
        public decimal PrecioTotal { get; set; }
    }
}
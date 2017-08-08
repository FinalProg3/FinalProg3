using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProgIII.Models
{
    public class Producto
    {
        [Key]
        public int ProductoID { get; set; }
        public int ProveedorID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public System.DateTime FechaPedido { get; set; }
        public bool Disponibilidad { get; set; }
        public string FotoPROD { get; set; }


        public virtual Proveedor Proveedor { get; set; }
    }
}
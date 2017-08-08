using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProgIII.Models
{
    public class Proveedor
    {
        [Key]
        public int ProveedorID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        //public string Foto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
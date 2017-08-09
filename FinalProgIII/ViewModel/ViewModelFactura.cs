using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using FinalProgIII.Models;

namespace FinalProgIII.Models
{
    public class ViewModelFactura
    {
        [Key]
        public int VentaID { get; set; }
        public IEnumerable<Producto> ArticuloSeleccionado { get; set; }
        public IEnumerable<Clientes> Clientes { get; set; }
        public IEnumerable<Factura> FacturaView { get; set; }
    }
}        

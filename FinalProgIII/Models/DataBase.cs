using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalProgIII.Models
{
    public class DataBase : DbContext
    {
        public DataBase() : base("Final")
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
    }
}
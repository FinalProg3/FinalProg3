﻿using System;
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
    }
}
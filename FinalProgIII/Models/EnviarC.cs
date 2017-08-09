using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProgIII.Models
{
    public class EnviarC
    {
        public int CorreoID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subjet { get; set; }
    }
}
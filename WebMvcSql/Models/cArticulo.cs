using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMvcSql.Models
{
    public class cArticulo
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono{ get; set; }
        public string Cargo { get; set; }
    }
}
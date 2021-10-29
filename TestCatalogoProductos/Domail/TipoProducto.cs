using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestCatalogoProductos.Domail
{
    public class TipoProducto
    {
        [Key]
        public int IdTipoProductos { get; set; }
        public string Nombre { get; set; }
        public Boolean Fragil { get; set; }     
        public int Tipo { get; set; }
    }
}
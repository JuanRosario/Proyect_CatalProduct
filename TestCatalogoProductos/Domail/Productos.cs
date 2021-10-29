using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestCatalogoProductos.Domail
{
    public class Productos
    {
        
        public int IdProductos { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> Tipo { get; set; }
        [NotMapped()]
        public List<TipoProducto> Tipos { get; set; }
        [NotMapped()]
        public int CONDICION { get; set; }
        
    }
}
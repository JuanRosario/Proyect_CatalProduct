using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestCatalogoProductos.Models.ViewModel
{
    public class Productos
    {
        [Key]
        public int IdProductos { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> Tipo { get; set; }
      
       

    }
}
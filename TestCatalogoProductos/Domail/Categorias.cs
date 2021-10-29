using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestCatalogoProductos.Domail
{
    public class Categorias
    {
      
        public int IDCategorias { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> Tipo { get; set; }

        public Nullable<int> CategoriaDepende { get; set; }
    }
}
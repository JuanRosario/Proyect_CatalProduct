//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestCatalogoProductos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Categoria
    {
        public int IDCategorias { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> CategoriaDepende { get; set; }
    }
}

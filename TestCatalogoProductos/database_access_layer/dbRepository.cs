using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestCatalogoProductos.database_access_layer
{
    public class dbRepository : DbContext
    {
        public dbRepository()
            : base("name=ConCatalogoProducto")
        {
        }
    }
}
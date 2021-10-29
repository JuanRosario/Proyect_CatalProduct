using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestCatalogoProductos.BLL;
using TestCatalogoProductos.database_access_layer;
using TestCatalogoProductos.Domail;

namespace TestCatalogoProductoss.BLL
{
    public class ProductossBLL : IBLL<Productos>
    {
        dbRepository _dbRepository;


        public ProductossBLL()
        {
            _dbRepository = new dbRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Productos"></param>
        /// <returns></returns>
        public Productos Save(ref Productos Productos)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                #region Parameters
                sqlParameters.Add(new SqlParameter("@IdProductos", Productos.IdProductos));
                sqlParameters.Add(new SqlParameter("@Nombre", Productos.Nombre.Trim() ?? (object)DBNull.Value));
                sqlParameters.Add(new SqlParameter("@Descripcion", Productos.Descripcion ?? (object)DBNull.Value));
                sqlParameters.Add(new SqlParameter("@Tipo", Productos.Tipo ?? (object)DBNull.Value));
                sqlParameters.Add(new SqlParameter("@CONDICION", Productos.CONDICION));
                #endregion

                var resurt = _dbRepository.Database.ExecuteSqlCommand("exec SP_MASTER_PRODUCTOS @IdProductos, @Nombre, @Descripcion, @Tipo, @CONDICION", sqlParameters.ToArray());

                // Productos. = Convert.ToInt32(resurt);

                return Productos;

            }
            catch (Exception e)
            {
                throw;
            }

        }
        /// <summary>
        /// </summary>
        /// <param name="Productos"></param>
        /// <returns></returns>
        public Productos Update(ref Productos Productos)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {

                #region Parameters
                sqlParameters.Add(new SqlParameter("@IdProductos", Productos.IdProductos));
                sqlParameters.Add(new SqlParameter("@Nombre", Productos.Nombre.Trim() ?? (object)DBNull.Value));
                sqlParameters.Add(new SqlParameter("@Descripcion", Productos.Descripcion ?? (object)DBNull.Value));
                sqlParameters.Add(new SqlParameter("@Tipo", Productos.Tipo ?? (object)DBNull.Value));
                sqlParameters.Add(new SqlParameter("@CONDICION", 2));

                #endregion

                var resurt = _dbRepository.Database.ExecuteSqlCommand("exec SP_MASTER_PRODUCTOS @IdProductos, @Nombre, @Descripcion, @Tipo,@CONDICION", sqlParameters.ToArray());

                //Rol.Id_Rol = Convert.ToInt32(resurt);

                return Productos;

            }
            catch (Exception e)
            {
                throw;
            }

        }

        /// <summary>
        /// Task GetAll Product
        /// </summary>
        /// <returns></returns>
        public async Task<List<Productos>> GetAll()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
           {
                #region Parameters
                sqlParameters.Add(new SqlParameter("@CONDICION", "0"));
                sqlParameters.Add(new SqlParameter("@IdProductos", "0"));
                #endregion

                return await _dbRepository.Database
                    .SqlQuery<Productos>("exec SP_Get_PRODUCTOS @CONDICION, @IdProductos", sqlParameters.ToArray()).ToListAsync();

            }
            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// Get by IdProducto
        /// </summary>
        /// <param name="ID_Producto"></param>
        /// <returns></returns>
        public async Task<Productos> GetByID(string ID_Producto)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {

                #region Parameters
                sqlParameters.Add(new SqlParameter("@CONDICION", "1" ?? (object)DBNull.Value));
                sqlParameters.Add(new SqlParameter("@IdProductos", ID_Producto));

                #endregion

                return await _dbRepository.Database
                    .SqlQuery<Productos>("exec SP_Get_PRODUCTOS @CONDICION, @IdProductos", sqlParameters.ToArray()).FirstAsync();

            }
            catch (Exception e)
            {
                throw;
            }
        }

 
        public async Task<List<Productos>> GetByID(string ID_Producto, string Tipo)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();


            try
            {

                #region Parameters
                sqlParameters.Add(new SqlParameter("@CONDICION", "1" ?? (object)DBNull.Value));
                sqlParameters.Add(new SqlParameter("@IdProductos", ID_Producto));
                #endregion

                return await _dbRepository.Database
                    .SqlQuery<Productos>("exec SP_Get_PRODUCTOS @CONDICION, @IdProductos", sqlParameters.ToArray()).ToListAsync();

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Productos> GetAll(bool IncludeInactive)
        {
            throw new NotImplementedException();
        }




        public bool Delete(int ID)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {

                #region Parameters
                sqlParameters.Add(new SqlParameter("@IdProductos", ID));
                sqlParameters.Add(new SqlParameter("@Nombre",""));
                sqlParameters.Add(new SqlParameter("@Descripcion",""));
                sqlParameters.Add(new SqlParameter("@Tipo", "0"));
                sqlParameters.Add(new SqlParameter("@CONDICION", 3));

                #endregion

                var resurt = _dbRepository.Database.ExecuteSqlCommand("exec SP_MASTER_PRODUCTOS @IdProductos, @Nombre, @Descripcion, @Tipo,@CONDICION", sqlParameters.ToArray());

                //Rol.Id_Rol = Convert.ToInt32(resurt);

               return true;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _dbRepository.Dispose();
                }
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ConsultaLogDGIIBLL() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            //GC.SuppressFinalize(this);
        }

        #endregion

        List<Productos> IBLL<Productos>.GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Productos> GetByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<Productos> GetByNameAsync(string Name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrInsert(Productos prod, bool IsEdit = true)
        {
            throw new NotImplementedException();
        }
    }
}
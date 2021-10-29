using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestCatalogoProductos.database_access_layer;
using TestCatalogoProductos.Domail;


namespace TestCatalogoProductos.BLL
{


    public class TipoProductoBLL : IBLL<TipoProducto>
    {
        dbRepository _dbRepository;


        public TipoProductoBLL()
        {
            _dbRepository = new dbRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TipoProducto"></param>
        /// <returns></returns>
        public TipoProducto Save(ref TipoProducto TipoProducto)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                #region Parameters
                sqlParameters.Add(new SqlParameter("@IdTipoProductos", TipoProducto.IdTipoProductos));
                sqlParameters.Add(new SqlParameter("@Nombre", TipoProducto.Nombre.Trim() ?? (object)DBNull.Value));

                sqlParameters.Add(new SqlParameter("@Fragil", TipoProducto.Fragil));
                sqlParameters.Add(new SqlParameter("@CONDICION", "0"));
                #endregion

                var resurt = _dbRepository.Database.ExecuteSqlCommand("exec SP_MASTER_TipoProducto @IdTipoProductos, @Nombre, @Fragil, @CONDICION", sqlParameters.ToArray());

              

                return TipoProducto;

            }
            catch (Exception e)
            {
                throw;
            }

        }
        /// <summary>
        /// </summary>
        /// <param name="Categorias"></param>
        /// <returns></returns>
        public TipoProducto Update(ref TipoProducto TipoProducto)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {

                #region Parameters
                sqlParameters.Add(new SqlParameter("@IdTipoProductos", TipoProducto.IdTipoProductos));
                sqlParameters.Add(new SqlParameter("@Nombre", TipoProducto.Nombre.Trim() ?? (object)DBNull.Value));

                sqlParameters.Add(new SqlParameter("@Fragil", TipoProducto.Fragil));
                sqlParameters.Add(new SqlParameter("@CONDICION", 2));
                #endregion

                var resurt = _dbRepository.Database.ExecuteSqlCommand("exec SP_MASTER_TipoProducto @IdTipoProductos, @Nombre, @Fragil, @CONDICION", sqlParameters.ToArray());



                return TipoProducto;

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
        public async Task<List<TipoProducto>> GetAll()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                #region Parameters
                sqlParameters.Add(new SqlParameter("@CONDICION", "0"));
                sqlParameters.Add(new SqlParameter("@IdTipoProductos", "0"));
                #endregion

                return await _dbRepository.Database
                    .SqlQuery<TipoProducto>("exec SP_Get_TipoPodructo @CONDICION, @IdTipoProductos", sqlParameters.ToArray()).ToListAsync();

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<TipoProducto> GetAll(bool withoutThread)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                #region Parameters
                sqlParameters.Add(new SqlParameter("@CONDICION", "0"));
                sqlParameters.Add(new SqlParameter("@IdTipoProductos", "0"));
                #endregion

                return  _dbRepository.Database
                    .SqlQuery<TipoProducto>("exec SP_Get_TipoPodructo @CONDICION, @IdTipoProductos", sqlParameters.ToArray()).ToList();

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
        public async Task<TipoProducto> GetByID(string ID_TipoProducto)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {

                #region Parameters
                sqlParameters.Add(new SqlParameter("@CONDICION", "1" ?? (object)DBNull.Value));
                sqlParameters.Add(new SqlParameter("@IdTipoProductos", ID_TipoProducto));

                #endregion

                return await _dbRepository.Database
                    .SqlQuery<TipoProducto>("exec SP_Get_TipoPodructo @CONDICION, @IdTipoProductos", sqlParameters.ToArray()).FirstAsync();

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public TipoProducto GetByID(Nullable<int> ID_TipoProducto)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {

                #region Parameters
                sqlParameters.Add(new SqlParameter("@CONDICION", "1" ?? (object)DBNull.Value));
                sqlParameters.Add(new SqlParameter("@IdTipoProductos", ID_TipoProducto));

                #endregion

                return  _dbRepository.Database
                    .SqlQuery<TipoProducto>("exec SP_Get_TipoPodructo @CONDICION, @IdTipoProductos", sqlParameters.ToArray()).FirstOrDefault();

            }
            catch (Exception e)
            {
                throw;
            }
        }


        public async Task<List<TipoProducto>> GetByID(string ID_TipoProducto, string Fragil)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();


            try
            {

                #region Parameters
                sqlParameters.Add(new SqlParameter("@CONDICION", "1" ?? (object)DBNull.Value));
                sqlParameters.Add(new SqlParameter("@IdTipoProductos", ID_TipoProducto));
                #endregion

                return await _dbRepository.Database
                    .SqlQuery<TipoProducto>("exec SP_MASTER_TipoProducto @CONDICION, @IdTipoProductos", sqlParameters.ToArray()).ToListAsync();

            }
            catch (Exception e)
            {
                throw;
            }
        }

        //public List<TipoProducto> GetAll(bool IncludeInactive)
        //{
        //    throw new NotImplementedException();
        //}




        public bool Delete(int ID)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {

                #region Parameters
                sqlParameters.Add(new SqlParameter("@IdTipoProductos", ID));
                sqlParameters.Add(new SqlParameter("@Nombre", ""));

                sqlParameters.Add(new SqlParameter("@Fragil", ""));
                sqlParameters.Add(new SqlParameter("@CONDICION", 3));
                #endregion

                var resurt = _dbRepository.Database.ExecuteSqlCommand("exec SP_MASTER_TipoProducto @IdTipoProductos, @Nombre, @Fragil, @CONDICION", sqlParameters.ToArray());

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

        List<TipoProducto> IBLL<TipoProducto>.GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TipoProducto> GetByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<TipoProducto> GetByNameAsync(string Name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrInsert(TipoProducto prod, bool IsEdit = true)
        {
            throw new NotImplementedException();
        }
    }
}
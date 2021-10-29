using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestCatalogoProductos.BLL;
using TestCatalogoProductos.database_access_layer;
using TestCatalogoProductos.Domail;

namespace TestCatalogoCategorias.BLL
{

    public class CategoriasBLL : IBLL<Categorias>
    {
        dbRepository _dbRepository;


        public CategoriasBLL()
        {
            _dbRepository = new dbRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Categorias"></param>
        /// <returns></returns>
        public Categorias Save(ref Categorias Categorias)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                #region Parameters
                sqlParameters.Add(new SqlParameter("@IDCategorias", Categorias.IDCategorias));
                sqlParameters.Add(new SqlParameter("@Nombre", Categorias.Nombre.Trim() ?? (object)DBNull.Value));

                sqlParameters.Add(new SqlParameter("@Descripcion", Categorias.Nombre.Trim() ?? (object)DBNull.Value));
                sqlParameters.Add(new SqlParameter("@Tipo", Categorias.Tipo ?? (object)DBNull.Value));

                sqlParameters.Add(new SqlParameter("@CategoriaDepende", Categorias.CategoriaDepende ?? (object)DBNull.Value));
                sqlParameters.Add(new SqlParameter("@CONDICION", "0"));
                #endregion

                var resurt = _dbRepository.Database.ExecuteSqlCommand("exec SP_MASTER_CATEGORIAS @IDCategorias, @Nombre, @Descripcion ,@Tipo, @CategoriaDepende, @CONDICION", sqlParameters.ToArray());

                // Categorias. = Convert.ToInt32(resurt);

                return Categorias;

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
        public Categorias Update(ref Categorias Categorias)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {

                #region Parameters
                sqlParameters.Add(new SqlParameter("@IDCategorias", Categorias.IDCategorias));
                sqlParameters.Add(new SqlParameter("@Nombre", Categorias.Nombre.Trim() ?? (object)DBNull.Value));
                sqlParameters.Add(new SqlParameter("@Descripcion", Categorias.Nombre.Trim() ?? (object)DBNull.Value));
                sqlParameters.Add(new SqlParameter("@Tipo", Categorias.Tipo ?? (object)DBNull.Value));
                sqlParameters.Add(new SqlParameter("@CategoriaDepende", Categorias.CategoriaDepende ?? (object)DBNull.Value));
                sqlParameters.Add(new SqlParameter("@CONDICION", 2));
                #endregion

                var resurt = _dbRepository.Database.ExecuteSqlCommand("exec SP_MASTER_CATEGORIAS @IDCategorias, @Nombre, @Descripcion ,@Tipo, @CategoriaDepende, @CONDICION", sqlParameters.ToArray());

                // Categorias. = Convert.ToInt32(resurt);

                return Categorias;

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
        public async Task<List<Categorias>> GetAll()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                #region Parameters
                sqlParameters.Add(new SqlParameter("@CONDICION", "0"));
                sqlParameters.Add(new SqlParameter("@IDCategorias", "0"));
                #endregion

                return await _dbRepository.Database
                    .SqlQuery<Categorias>("exec SP_Get_CATEGORIAS @CONDICION, @IDCategorias", sqlParameters.ToArray()).ToListAsync();

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
        public async Task<Categorias> GetByID(string ID_Categorias)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {

                #region Parameters
                sqlParameters.Add(new SqlParameter("@CONDICION", "1" ?? (object)DBNull.Value));
                sqlParameters.Add(new SqlParameter("@IDCategorias", ID_Categorias));

                #endregion

                return await _dbRepository.Database
                    .SqlQuery<Categorias>("exec SP_Get_Categorias @CONDICION, @IDCategorias", sqlParameters.ToArray()).FirstAsync();

            }
            catch (Exception e)
            {
                throw;
            }
        }


        public async Task<List<Categorias>> GetByID(string ID_Categorias, string CategoriasDepende)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();


            try
            {

                #region Parameters
                sqlParameters.Add(new SqlParameter("@CONDICION", "1" ?? (object)DBNull.Value));
                sqlParameters.Add(new SqlParameter("@IdCategorias", ID_Categorias));
                #endregion

                return await _dbRepository.Database
                    .SqlQuery<Categorias>("exec SP_Get_Categorias @CONDICION, @IdCategorias", sqlParameters.ToArray()).ToListAsync();

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Categorias> GetAll(bool IncludeInactive)
        {
            throw new NotImplementedException();
        }




        public bool Delete(int ID)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {

                #region Parameters
                sqlParameters.Add(new SqlParameter("@IDCategorias",ID));
                sqlParameters.Add(new SqlParameter("@Nombre", ""));
                sqlParameters.Add(new SqlParameter("@CategoriaDepende",""));
                sqlParameters.Add(new SqlParameter("@Descripcion", "" ));
                sqlParameters.Add(new SqlParameter("@Tipo",""));
                sqlParameters.Add(new SqlParameter("@CONDICION", 3));
                #endregion

                var resurt = _dbRepository.Database.ExecuteSqlCommand("exec SP_MASTER_CATEGORIAS @IDCategorias, @Nombre,@Descripcion ,@Tipo, @CategoriaDepende, @CONDICION", sqlParameters.ToArray());

                

              
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

        List<Categorias> IBLL<Categorias>.GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Categorias> GetByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<Categorias> GetByNameAsync(string Name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrInsert(Categorias prod, bool IsEdit = true)
        {
            throw new NotImplementedException();
        }
    }
}
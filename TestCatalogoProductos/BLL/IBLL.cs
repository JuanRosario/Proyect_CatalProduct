using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCatalogoProductos.BLL
{
    public interface IBLL<T> : IDisposable   
    {
        List<T> GetAll();
        List<T> GetAll(bool IncludeInactive);
        Task<T> GetByIDAsync(int ID);
        Task<T> GetByNameAsync(string Name);
        bool Delete(int ID);
        bool UpdateOrInsert(T prod, bool IsEdit = true);
    }
    
}

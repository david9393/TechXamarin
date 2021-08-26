using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Database._Base
{
    public interface IBaseReadRepository<T> where T : class
    {

        T GetByPrimaryKey(object id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAllPaging(int pageIndex, int pageSize);

        Task<T> GetByPrimaryKeyAsync(object id);
        Task<IQueryable<T>> GetAllAsync();
        Task<IQueryable<T>> GetAllPagingAsync(int pageIndex, int pageSize);

    }

}

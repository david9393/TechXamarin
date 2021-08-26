using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Database._Base
{
    public interface ICreateRepository<T> where T : class
    {

        T Insert(T entity);
        void BulkInsert(IEnumerable<T> entities);
        void DeleteAllAndInsert(IEnumerable<T> entities);

        Task<T> InsertAsync(T entity);
        Task BulkInsertAsync(IEnumerable<T> entities);
        Task DeleteAllAndInsertAsync(IEnumerable<T> entities);

    }
}

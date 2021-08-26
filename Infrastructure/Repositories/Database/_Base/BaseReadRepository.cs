using CommonShared.Dependencies.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Database._Base
{
    public class BaseReadRepository<T> : BaseConnectionFactory<T>, IBaseReadRepository<T> where T : class
    {

        public BaseReadRepository(IEntityFrameworkCoreDependency entityFrameworkCoreDependency) : base(entityFrameworkCoreDependency)
        {
        }

        #region IReadRepository implementation
        public T GetByPrimaryKey(object id)
        {
            lock (Locker)
            {
                return DataContext.Find<T>(id);
            }
        }

        public virtual IQueryable<T> GetAll()
        {
            lock (Locker)
            {
                return Table.AsNoTracking();
            }
        }

        public IQueryable<T> GetAllPaging(int pageIndex, int pageSize)
        {
            return Table.AsNoTracking().Skip(pageIndex * pageSize).Take(pageSize);
        }

        public async Task<T> GetByPrimaryKeyAsync(object id)
        {
            return await DataContext.FindAsync<T>(id);
        }

        public async virtual Task<IQueryable<T>> GetAllAsync()
        {
            var result = Table.AsNoTracking();
            return await Task.FromResult(result);
        }

        public async virtual Task<IQueryable<T>> GetAllPagingAsync(int pageIndex, int pageSize)
        {
            var result = Table.AsNoTracking().Skip(pageIndex * pageSize).Take(pageSize);
            return await Task.FromResult(result);
        }
        #endregion

    }

}

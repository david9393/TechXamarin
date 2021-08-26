using CommonShared.Dependencies.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Database._Base
{
    public class BaseDeleteRepository<T> : BaseConnectionFactory<T>, IBaseDeleteRepository<T> where T : class
    {

        public BaseDeleteRepository(IEntityFrameworkCoreDependency entityFrameworkCoreDependency) : base(entityFrameworkCoreDependency)
        {
        }

        #region IDeleteRepository implementation
        public void Delete(T entity)
        {
            lock (Locker)
            {
                DataContext.Remove(entity);
                Commit();
            }

        }

        public void DeleteAll()
        {
            lock (Locker)
            {
                DataContext.RemoveRange(Table);
                Commit();
            }
        }

        public async Task DeleteAllAsync()
        {
            DataContext.RemoveRange(Table);
            await CommitAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            DataContext.Remove(entity);
            await CommitAsync();

        }
        #endregion

    }

}

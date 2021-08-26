using CommonShared.Dependencies.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Database._Base
{
    public class BaseUpdateRepository<T> : BaseConnectionFactory<T>, IBaseUpdateRepository<T> where T : class
    {

        public BaseUpdateRepository(IEntityFrameworkCoreDependency entityFrameworkCoreDependency) : base(entityFrameworkCoreDependency)
        {
        }

        #region IUpdateRepository implementation
        public T Update(T entity)
        {
            DataContext.Update(entity);
            Commit();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var oldItem = await Table.FindAsync(GetValuePrimaryKey(entity));
            DataContext.Entry(oldItem).CurrentValues.SetValues(entity);
            Table.Update(oldItem);
            await DataContext.SaveChangesAsync();
            DataContext.Entry(oldItem).State = EntityState.Detached;

            return entity;

        }
        #endregion

    }
}

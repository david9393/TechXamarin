using CommonShared.Dependencies.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Database._Base
{
    public class BaseCreateRepository<T> : BaseConnectionFactory<T>, ICreateRepository<T> where T : class
    {

        public BaseCreateRepository(IEntityFrameworkCoreDependency entityFrameworkCoreDependency) : base(entityFrameworkCoreDependency)
        {
        }

        public T Insert(T entity)
        {
            DataContext.Add(entity);
            Commit();
            return entity;
        }

        public void BulkInsert(IEnumerable<T> entities)
        {
            DataContext.AddRange(entities);
            Commit();
        }

        public void DeleteAllAndInsert(IEnumerable<T> entities)
        {
            DataContext.RemoveRange(Table);
            DataContext.AddRange(entities);
            Commit();
        }

        public async Task<T> InsertAsync(T entity)
        {
            await Table.AddAsync(entity);
            await CommitAsync();
            DataContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task BulkInsertAsync(IEnumerable<T> entities)
        {
            await DataContext.AddRangeAsync(entities);
            await CommitAsync();
        }

        public async Task DeleteAllAndInsertAsync(IEnumerable<T> entities)
        {
            DataContext.RemoveRange(Table);
            await DataContext.AddRangeAsync(entities);
            await CommitAsync();
        }

    }
}

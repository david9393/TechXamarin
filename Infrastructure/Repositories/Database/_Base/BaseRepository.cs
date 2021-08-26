using CommonShared.Dependencies.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Database._Base
{
    public class BaseRepository<T> : BaseConnectionFactory<T>, IRepository<T> where T : class
    {

        private readonly BaseCreateRepository<T> _createRepository;
        private readonly BaseReadRepository<T> _readRepository;
        private readonly BaseUpdateRepository<T> _updateRepository;
        private readonly BaseDeleteRepository<T> _deleteRepository;

        public BaseRepository(IEntityFrameworkCoreDependency entityFrameworkCoreDependency) : base(entityFrameworkCoreDependency)
        {
            _createRepository = new BaseCreateRepository<T>(entityFrameworkCoreDependency);
            _readRepository = new BaseReadRepository<T>(entityFrameworkCoreDependency);
            _updateRepository = new BaseUpdateRepository<T>(entityFrameworkCoreDependency);
            _deleteRepository = new BaseDeleteRepository<T>(entityFrameworkCoreDependency);
        }

        #region IDeleteRepository implementation
        public void Delete(T entity)
        {
            _deleteRepository.Delete(entity);
        }

        public void DeleteAll()
        {
            _deleteRepository.DeleteAll();
        }

        public async Task DeleteAsync(T entity)
        {
            await _deleteRepository.DeleteAsync(entity);
        }

        public async Task DeleteAllAsync()
        {
            await _deleteRepository.DeleteAllAsync();
        }
        #endregion


        #region IReadRepository implementation
        public T GetByPrimaryKey(object id)
        {
            return _readRepository.GetByPrimaryKey(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _readRepository.GetAll();
        }

        public async Task<T> GetByPrimaryKeyAsync(object id)
        {
            return await _readRepository.GetByPrimaryKeyAsync(id);
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await _readRepository.GetAllAsync();
        }

        public IQueryable<T> GetAllPaging(int pageIndex, int pageSize)
        {
            return _readRepository.GetAllPaging(pageIndex, pageSize);
        }

        public async Task<IQueryable<T>> GetAllPagingAsync(int pageIndex, int pageSize)
        {
            return await _readRepository.GetAllPagingAsync(pageIndex, pageSize);

        }
        #endregion


        #region IUpdateRepository implementation
        public T Update(T entity)
        {
            return _updateRepository.Update(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await _updateRepository.UpdateAsync(entity);
        }
        #endregion


        #region ICreateRepository implementation

        public T Insert(T entity)
        {
            return _createRepository.Insert(entity);
        }

        public void BulkInsert(IEnumerable<T> entities)
        {
            _createRepository.BulkInsert(entities);
        }

        public void DeleteAllAndInsert(IEnumerable<T> entities)
        {
            _createRepository.DeleteAllAndInsert(entities);
        }

        public async Task<T> InsertAsync(T entity)
        {
            return await _createRepository.InsertAsync(entity);
        }

        public async Task BulkInsertAsync(IEnumerable<T> entities)
        {
            await _createRepository.BulkInsertAsync(entities);
        }

        public async Task DeleteAllAndInsertAsync(IEnumerable<T> entities)
        {
            await _createRepository.DeleteAllAndInsertAsync(entities);
        }
        #endregion

    }
}

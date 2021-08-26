using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Database._Base
{
    public interface IBaseDeleteRepository<T> where T : class
    {

        void Delete(T entity);
        void DeleteAll();

        Task DeleteAsync(T entity);
        Task DeleteAllAsync();

    }

}

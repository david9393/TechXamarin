using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Database._Base
{
    public interface IBaseUpdateRepository<T> where T : class
    {

        T Update(T entity);

        Task<T> UpdateAsync(T entity);

    }
}

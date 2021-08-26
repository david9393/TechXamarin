using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Database._Base
{
    public interface IRepository<T> : ICreateRepository<T>, IBaseUpdateRepository<T>, IBaseReadRepository<T>, IBaseDeleteRepository<T> where T : class
    {
    }
}

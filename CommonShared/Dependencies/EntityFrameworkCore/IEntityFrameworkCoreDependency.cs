using System;
using System.Collections.Generic;
using System.Text;

namespace CommonShared.Dependencies.EntityFrameworkCore
{
    public interface IEntityFrameworkCoreDependency
    {
        string GetDatabasePath();

    }
}

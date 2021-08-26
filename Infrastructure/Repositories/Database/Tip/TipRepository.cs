using CommonShared.Dependencies.EntityFrameworkCore;
using CommonShared.DTO.Tips;
using Infrastructure.Repositories.Database._Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Database.Tip
{
    public class TipRepository : BaseRepository<TipModel>, ITipRepository
    {
        public TipRepository(IEntityFrameworkCoreDependency entityFrameworkCoreDependency)
            : base(entityFrameworkCoreDependency)
        {
        }
        //public async Task Add(TipModel tip)
        //{
        //    await DataContext.AddAsync(tip);
        //    await DataContext.SaveChangesAsync();
        //    DataContext.Entry(tip).State = EntityState.Detached;

        //}
       
    }
}

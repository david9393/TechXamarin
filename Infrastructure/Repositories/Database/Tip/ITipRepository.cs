using CommonShared.DTO.Tips;
using Infrastructure.Repositories.Database._Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Database.Tip
{
   public interface ITipRepository : IRepository<TipModel>
    {
        //Task Add(TipModel tip);
    }
}

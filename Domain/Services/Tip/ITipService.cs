using CommonShared.DTO.Tips;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Tip
{
    public interface ITipService
    {
        Task<TipModel> GetTip(string id);
        Task<ObservableCollection<TipModel>> GetAllTip();
        Task<TipModel> AddTip(TipModel tip);
        Task<TipModel> UpdateTip(TipModel tip);
        Task DeleteTip(TipModel tip);
    }
}

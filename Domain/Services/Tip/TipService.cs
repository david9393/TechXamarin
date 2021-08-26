using CommonShared.DTO.Tips;
using Domain.Validations;
using Infrastructure.Repositories.Database.Tip;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Tip
{
   public class TipService : ITipService
    {
        private readonly ITipRepository _tipRepository;
        private TipValidator tipValidator;
       
        public TipService(ITipRepository tipRepository)
        {
            _tipRepository = tipRepository;
            tipValidator = new TipValidator();

        }
        #region Methods SQLite

        /// <summary>
        /// Retorna un tip
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Tip</returns>
        public async Task<TipModel> GetTip(string id)
        {
            TipModel tipModel = await _tipRepository.GetByPrimaryKeyAsync(id);
            return tipModel;
        }
        /// <summary>
        /// Retorna un tip
        /// </summary>
        /// <param></param>
        /// <returns>List Tip</returns>
        public async Task<ObservableCollection<TipModel>> GetAllTip()
        {
           var result= await _tipRepository.GetAllAsync();
            ObservableCollection<TipModel> tipModels = new ObservableCollection<TipModel>(result);
            return tipModels;
        }
        /// <summary>
        /// Crea un nuevo tip
        /// </summary>
        /// <param name="tip"></param>
        /// <returns>Tip</returns>
        public async Task<TipModel> AddTip(TipModel tip)
        {
            if (!tipValidator.Validate(tip).IsValid)
            {
                return null;
            }
            TipModel tipModel = await _tipRepository.InsertAsync(tip);         
            return tipModel;
        }
        /// <summary>
        /// Modifica un nuevo tip
        /// </summary>
        /// <param name="tip"></param>
        /// <returns>Tip</returns>
        public async Task<TipModel> UpdateTip(TipModel tip)
        {
            TipModel tipModel = await _tipRepository.UpdateAsync(tip);
            return tipModel;
        }
        /// <summary>
        /// Borra un tip
        /// </summary>
        /// <param name="tip"></param>
        /// <returns></returns>
        public async Task DeleteTip(TipModel tip)
        {
            await _tipRepository.DeleteAsync(tip);
           
        }
        #endregion
    }
}

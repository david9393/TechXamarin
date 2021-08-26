using AutoMapper;
using CommonShared.DTO.Tips;
using Domain.Services.Tip;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TechnicalTest.ViewModels.Domain;
using Xamarin.Forms;

namespace TechnicalTest.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly ITipService _tipService;
        private readonly IMapper _mapper;
        public Command<TipViewModel>UpdateTipCommand { get;}
        public Command<TipViewModel> DeleteTipCommand { get;}
        public Command NewTipCommand { get; }
        public ObservableCollection<TipViewModel> Tips { get; set; }
        public MainPageViewModel(INavigationService navigationService, ITipService tipService, IMapper mapper)
            : base(navigationService)
        {
            _tipService = tipService;
            _mapper = mapper;
            Title = "Lista de Tips";
            UpdateTipCommand = new Command<TipViewModel>(async (tip) => await NavigateToUpdateTip(tip));
            DeleteTipCommand = new Command<TipViewModel>(async (tip) => await DeleteTip(tip));
            NewTipCommand = new Command(async () => await NavigateToNewTip());

        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            _ = LoadTips();
        }    
        private async Task LoadTips()
        {
            ObservableCollection<TipModel> tipModels = await _tipService.GetAllTip();
            Tips = _mapper.Map<ObservableCollection<TipViewModel>>(tipModels);
        }
        private async Task NavigateToNewTip()
        {
            await NavigationService.NavigateAsync("DetailTip");
        }
        private async Task NavigateToUpdateTip(TipViewModel tip)
        {
            INavigationParameters keys = new NavigationParameters();
            keys.Add("Tip", tip);
            await NavigationService.NavigateAsync("DetailTip", keys);
        }
        private async Task DeleteTip(TipViewModel tip)
        {
            await _tipService.DeleteTip(_mapper.Map<TipModel>(tip));
            Tips.Remove(tip);
        }
      
    }
}

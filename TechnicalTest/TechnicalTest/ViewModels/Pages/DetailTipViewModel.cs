using AutoMapper;
using CommonShared.DTO.Tips;
using Domain.Services.Tip;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalTest.ViewModels.Domain;
using Xamarin.Forms;

namespace TechnicalTest.ViewModels
{
    public class DetailTipViewModel : ViewModelBase
    {
        private readonly ITipService _tipService;
        private readonly IMapper _mapper;
        public Command UpdateTipCommand { get; }
        public Command AddTipCommand { get; }
        public TipViewModel Tip { get; set; }
        public bool IsEdit { get; set; }
        public DetailTipViewModel(INavigationService navigationService, ITipService tipService, IMapper mapper)
            : base(navigationService)
        {
            _tipService = tipService;
            _mapper = mapper;
            UpdateTipCommand = new Command(async () => await UpdateTip());
            AddTipCommand = new Command(async () => await AddTip());

        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey("Tip"))
            {   
                Tip = parameters.GetValue<TipViewModel>("Tip");
                Title = "Update Tip";
                IsEdit = true;
                return;
            }
            Tip = new TipViewModel();
            Tip.Date = DateTime.Now;
            IsEdit = false;
            Title = "New Tip";
        }
        private async Task UpdateTip()
        {
           TipModel tipModel= await _tipService.UpdateTip(_mapper.Map<TipModel>(Tip));
            if (tipModel == null)
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Verifique faltan datos requeridos", "Ok");
                return;
            }
         
            await App.Current.MainPage.DisplayAlert("Ok", "Se modifico correctamente", "Ok");
            await NavigationService.GoBackAsync();            
        }
        private async Task AddTip()
        {
            TipModel tipModel = await _tipService.AddTip(_mapper.Map<TipModel>(Tip));
            if (tipModel == null)
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Verifique faltan datos requeridos", "Ok");
                return;
            }
            await App.Current.MainPage.DisplayAlert("Ok", "Se guardo correctamente", "Ok");
            await NavigationService.GoBackAsync();

        }


    }
}

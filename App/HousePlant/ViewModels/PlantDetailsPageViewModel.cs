using System;
using HousePlant.Models;
using Prism.Commands;
using Prism.Navigation;

namespace HousePlant.ViewModels
{
    public class PlantDetailsPageViewModel: ViewModelBase
    {
        public DelegateCommand GoBackCommand { get; }

        private Plant _plant;
        public Plant Plant
        {
            get { return _plant; }
            set { SetProperty(ref _plant, value); }
        }

        public PlantDetailsPageViewModel(INavigationService navigationService)
                : base(navigationService)
        {
            Title = "Details Page";
            GoBackCommand = new DelegateCommand(GoBack);
        }

        private void GoBack()
        {
            _navigationService.GoBackAsync();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Plant = parameters.GetValue<Plant>("plant");
        }
    }
}

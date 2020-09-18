using System;
using System.Threading.Tasks;
using HousePlant.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;

namespace HousePlant.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand<string> NavigateCommand { get; }

        private bool _isMenuPresented;
        public bool IsMenuPresented
        {
            get { return _isMenuPresented; }
            set { SetProperty(ref _isMenuPresented, value); }
        }

        public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
            : base(navigationService)
        {
            Title = "Main Page";
            NavigateCommand = new DelegateCommand<string>(async (path) => await NavigateToView(path));
            eventAggregator.GetEvent<ToggleMainMenuEvent>().Subscribe(ToggleMenu);
        }

        private void ToggleMenu(bool shouldExecuteToggle)
        {
            IsMenuPresented = !IsMenuPresented;
        }

        private async Task NavigateToView(string path)
        {
            await _navigationService.NavigateAsync($"NavigationPage/{path}");
        }
    }
}
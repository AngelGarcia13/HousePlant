using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HousePlant.Events;
using HousePlant.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;

namespace HousePlant.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        IEventAggregator _eventAggregator;

        public DelegateCommand ToogleMenuCommand { get; }

        public DelegateCommand<Plant> GoToPlantDetailsCommand { get; }

        public ObservableCollection<Plant> FeaturedPlants { get; set; }

        public HomePageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
                : base(navigationService)
        {
            Title = "Home Page";
            ToogleMenuCommand = new DelegateCommand(ToogleMenu);
            GoToPlantDetailsCommand = new DelegateCommand<Plant>(GoToPlantDetails);
            _eventAggregator = eventAggregator;
            FeaturedPlants = new ObservableCollection<Plant>();
            LoadInfo();
        }

        private void GoToPlantDetails(Plant plant)
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("plant", plant);
            _navigationService.NavigateAsync("PlantDetailsPage", navigationParameters);
        }

        private void LoadInfo()
        {
            var reminders = new List<Reminder> {
                new Reminder { Requirement = "Water requirement", Description = "3 times in a week", Icon = "water_drop_icon" },
                new Reminder { Requirement = "Plant food", Description = "Once in a month", Icon = "leaf_icon" },
                new Reminder { Requirement = "Light requirement", Description = "Natural light", Icon = "sun_light_icon" },
                new Reminder { Requirement = "Optimum temperature", Description = "06 - 35 Celcius", Icon = "thermometer_icon" }
            };

            FeaturedPlants.Add(new Plant {
                Name = "Red Prayer Plant",
                BotanicalName = "Maranta leuconeura",
                ImageUrl = "plant1",
                Description = "Striking red veins against the soft, dark green leaves make the Red Prayer Plant an aesthete’s dream, and their low upkeep makes them perfect for apartment dwellers.",
                Category = PlantCategory.InsidePlant,
                Reminders = reminders
            });

            FeaturedPlants.Add(new Plant
            {
                Name = "Zebra Cactus",
                BotanicalName = "Haworthiopsis attenuata",
                ImageUrl = "plant2",
                Description = "Striking red veins against the soft, dark green leaves make the Red Prayer Plant an aesthete’s dream, and their low upkeep makes them perfect for apartment dwellers.",
                Category = PlantCategory.OutsidePlant,
                Reminders = reminders
            });

            FeaturedPlants.Add(new Plant
            {
                Name = "Red Prayer Plant",
                BotanicalName = "Maranta leuconeura",
                ImageUrl = "plant1",
                Description = "Striking red veins against the soft, dark green leaves make the Red Prayer Plant an aesthete’s dream, and their low upkeep makes them perfect for apartment dwellers.",
                Category = PlantCategory.InsidePlant,
                Reminders = reminders
            });

            FeaturedPlants.Add(new Plant
            {
                Name = "Zebra Cactus",
                BotanicalName = "Haworthiopsis attenuata",
                ImageUrl = "plant2",
                Description = "Striking red veins against the soft, dark green leaves make the Red Prayer Plant an aesthete’s dream, and their low upkeep makes them perfect for apartment dwellers.",
                Category = PlantCategory.OutsidePlant,
                Reminders = reminders
            });

        }

        private void ToogleMenu()
        {
            _eventAggregator.GetEvent<ToggleMainMenuEvent>().Publish(true);

        }
    }
}

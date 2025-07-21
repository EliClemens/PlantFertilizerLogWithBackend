using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlantFertilizerLog.Models;
using PlantFertilizerLog.Services;

namespace PlantFertilizerLog.ViewModels
{

    public class MainPageViewModel : ObservableObject
    {
        private readonly IPlantService _plantService;

        public ObservableCollection<Plant> VegPlants { get; }
        public ObservableCollection<Plant> FlowerPlants { get; }
        public ObservableCollection<Plant> HarvestPlants { get; }
        public ObservableCollection<Plant> CompletePlants { get; }

        public MainPageViewModel(IPlantService plantService)
        {
            _plantService = plantService;
            VegPlants = new(_plantService.GetPlantsByStage(PlantStage.Veg));
            FlowerPlants = new(_plantService.GetPlantsByStage(PlantStage.Flower));
            HarvestPlants = new(_plantService.GetPlantsByStage(PlantStage.Harvest));
            CompletePlants = new(_plantService.GetPlantsByStage(PlantStage.Complete));
        }
    }

}

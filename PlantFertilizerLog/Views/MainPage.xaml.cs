using PlantFertilizerLog.Models;
using PlantFertilizerLog.Services;
using PlantFertilizerLog.ViewModels;

namespace PlantFertilizerLog.Views;

public partial class MainPage : ContentPage
{
    private readonly IPlantService _plantService;

    public MainPage(IPlantService plantService)
    {
        InitializeComponent();
        _plantService = plantService;
        BindingContext = new MainPageViewModel(_plantService);
    }

    private async void OnAddPlantClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddPlantPage(_plantService, OnPlantAdded));
    }
    private async void OnAddWateringClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.CommandParameter is Plant plant)
        {
            await Navigation.PushAsync(new AddWateringPage(plant, _plantService));
        }
    }
    private void OnPlantAdded()
    {
        BindingContext = new MainPageViewModel(_plantService);
    }

    private async void OnViewPlantClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.CommandParameter is Plant plant)
            await Navigation.PushAsync(new ViewPlantPage(plant));
    }

    private async void OnDeletePlantClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.CommandParameter is Plant plant)
        {
            bool confirm = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete '{plant.Name}'?", "Delete", "Cancel");
            if (confirm)
            {
                _plantService.DeletePlant(plant.Id);
                BindingContext = new MainPageViewModel(_plantService);
            }
        }
    }

    private void OnMoveStageClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.CommandParameter is Plant plant)
        {
            _plantService.MoveToNextStage(plant.Id);
            BindingContext = new MainPageViewModel(_plantService);
        }
    }

    private void OnStartCureClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.CommandParameter is Plant plant)
        {
            _plantService.StartCure(plant.Id);
            BindingContext = new MainPageViewModel(_plantService);
        }
    }

    private async void OnMarkCompleteClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.CommandParameter is Plant plant)
        {
            _plantService.MarkComplete(plant.Id, DateTime.Now);
            await Navigation.PushAsync(new HarvestPage(plant, _plantService));
        }
    }
}

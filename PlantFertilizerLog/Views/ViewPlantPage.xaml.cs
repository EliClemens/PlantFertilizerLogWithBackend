using PlantFertilizerLog.Models;
using PlantFertilizerLog.Services;

namespace PlantFertilizerLog.Views;

public partial class ViewPlantPage : ContentPage
{
    public Plant Plant { get; }

    public ViewPlantPage(Plant plant)
    {
        InitializeComponent();
        Plant = plant;
        BindingContext = this;

    }

    private async void OnReturnClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}

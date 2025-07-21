using PlantFertilizerLog.Services;

namespace PlantFertilizerLog.Views;

public partial class OpeningPage : ContentPage
{
    private readonly IPlantService _plantService;

    public OpeningPage(IPlantService plantService)
    {
        InitializeComponent();
        _plantService = plantService;
    }

    private async void OnOpenClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage(_plantService));
    }
}

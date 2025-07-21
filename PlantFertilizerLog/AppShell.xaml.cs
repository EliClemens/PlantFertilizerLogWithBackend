namespace PlantFertilizerLog;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(Views.AddPlantPage), typeof(Views.AddPlantPage));
        Routing.RegisterRoute(nameof(Views.AddWateringPage), typeof(Views.AddWateringPage));
        Routing.RegisterRoute(nameof(Views.MainPage), typeof(Views.MainPage));
        Routing.RegisterRoute(nameof(Views.ViewPlantPage), typeof(Views.ViewPlantPage));
        Routing.RegisterRoute(nameof(Views.HarvestPage), typeof(Views.HarvestPage));
    }
}

using PlantFertilizerLog.Services;

namespace PlantFertilizerLog;

public partial class App : Application
{
    public static IPlantService PlantService { get; private set; }

    public App()
    {
        InitializeComponent();

        // Register the PlantService as the app-wide service
        PlantService = new PlantService();

        // Set the MainPage to the shell and navigate to OpeningPage
        MainPage = new AppShell();
    }
}

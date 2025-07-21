using Microsoft.Extensions.Logging;
using PlantFertilizerLog.Services;
using PlantFertilizerLog.Views;
namespace PlantFertilizerLog
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<IPlantService, PlantService>(); // Your service

            // Add all pages used with constructor dependencies
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<AddPlantPage>();
            builder.Services.AddTransient<AddWateringPage>();
            builder.Services.AddTransient<OpeningPage>();
            builder.Services.AddTransient<ViewPlantPage>();
            builder.Services.AddTransient<HarvestPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

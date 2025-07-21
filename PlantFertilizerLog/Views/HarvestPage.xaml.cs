using PlantFertilizerLog.Models;
using PlantFertilizerLog.Services;

namespace PlantFertilizerLog.Views;

public partial class HarvestPage : ContentPage
{
    public Plant Plant { get; }
    private readonly IPlantService _plantService;
    private readonly List<string> _images = new();

    public HarvestPage(Plant plant, IPlantService plantService)
    {
        InitializeComponent(); // DO NOT override this method
        Plant = plant;
        _plantService = plantService;
        BindingContext = this;
    }

    private async void OnUploadImageClicked(object sender, EventArgs e)
    {
        var result = await FilePicker.Default.PickAsync();
        if (result != null)
        {
            _images.Add(result.FullPath);
            await DisplayAlert("Image Uploaded", result.FileName, "OK");
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        Plant.BudDensity = BudDensityPicker.SelectedItem?.ToString() ?? "Medium";
        Plant.TrichomeColor = TrichomePicker.SelectedItem?.ToString() ?? "Cloudy";

        foreach (var img in _images)
        {
            Plant.ImagePaths.Add(img);
        }

        _plantService.MarkComplete(Plant.Id, DateTime.Now);

        await DisplayAlert("Done", "Plant marked as complete.", "OK");
        await Navigation.PushAsync(new MainPage(_plantService)); //push mainPage to the top of the stack
        //remove HarvestPage from the stack
        Navigation.RemovePage(this);
    }
}

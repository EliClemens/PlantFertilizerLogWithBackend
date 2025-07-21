using PlantFertilizerLog.Models;
using PlantFertilizerLog.Services;

namespace PlantFertilizerLog.Views;

public partial class AddPlantPage : ContentPage
{
    private readonly IPlantService _plantService;
    private readonly Action _onPlantAdded;
    private string _imagePath;

    public AddPlantPage(IPlantService plantService, Action onPlantAdded)
    {
        InitializeComponent();
        _plantService = plantService;
        _onPlantAdded = onPlantAdded;
    }

    private async void OnUploadImageClicked(object sender, EventArgs e)
    {
        var result = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Select a plant image"
        });

        if (result != null)
        {
            _imagePath = result.FullPath;
            await DisplayAlert("Image Selected", _imagePath, "OK");
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            await DisplayAlert("Error", "Name and is required.", "OK");
            return;
        }

        var newPlant = new Plant
        {
            Name = NameEntry.Text,
            Breeder = BreederEntry.Text,
            DateStarted = StartDatePicker.Date,
            PlantCount = int.TryParse(CountEntry.Text, out var count) ? count : 1,
            Type = TypePicker.SelectedItem?.ToString() ?? "Feminized",//default is feminized
            Origin = OriginPicker.SelectedItem?.ToString() ?? "Seed",//default is seed
            Spectrum = SpectrumPicker.SelectedItem?.ToString() ?? "Hybrid",//set default to Hybrid
            ImagePaths = string.IsNullOrEmpty(_imagePath) ? new List<string>() : new List<string> { _imagePath },
            Stage = PlantStage.Veg
        };

        _plantService.AddPlant(newPlant);
        _onPlantAdded?.Invoke();
        await Navigation.PopAsync();
    }
    public async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}

using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using PlantFertilizerLog.Models;
using PlantFertilizerLog.Services;

namespace PlantFertilizerLog.Views;

public partial class AddWateringPage : ContentPage
{
    private readonly Plant _plant;
    private readonly IPlantService _plantService;
    private readonly List<string> _images = new();
    private readonly ObservableCollection<FertilizerEntry> _fertilizers = new();

    public AddWateringPage(Plant plant, IPlantService plantService)
    {
        InitializeComponent();
        _plant = plant;
        _plantService = plantService;

        // ? Preload default fertilizers into the form (empty Amounts)
        foreach (var fert in _plant.DefaultFertilizers)
        {
            _fertilizers.Add(new FertilizerEntry
            {
                Name = fert.Name,
                NPK = fert.NPK,
                Amount = string.Empty
            });
        }

        FertilizerListView.ItemsSource = _fertilizers;
    }

    private void OnAddFertilizerClicked(object sender, EventArgs e)
    {
        _fertilizers.Add(new FertilizerEntry());
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
        if (!float.TryParse(PHEntry.Text, out float ph) ||
            !float.TryParse(PPMEntry.Text, out float ppm) ||
            !float.TryParse(TDSEntry.Text, out float tds))
        {
            await DisplayAlert("Error", "Please enter valid pH, PPM, and TDS values.", "OK");
            return;
        }

        // ? Add new fertilizers to default list (no amount)
        foreach (var fert in _fertilizers)
        {
            if (!_plant.DefaultFertilizers.Any(f => f.Name == fert.Name && f.NPK == fert.NPK))
            {
                _plant.DefaultFertilizers.Add(new FertilizerEntry
                {
                    Name = fert.Name,
                    NPK = fert.NPK,
                    Amount = string.Empty
                });
            }
        }
        
        var entry = new WateringEntry
        {
            Date = DateTime.Now,
            PH = ph,
            PPM = ppm,
            TDS = tds,
            Fertilizers = _fertilizers.ToList(),
            Images = _images.ToList()
        };

        _plantService.AddWatering(_plant.Id, entry);
        await Navigation.PopAsync();
    }
    public async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}

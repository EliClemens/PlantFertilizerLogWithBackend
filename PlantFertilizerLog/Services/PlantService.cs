using PlantFertilizerLog.Models;

namespace PlantFertilizerLog.Services
{
    public class PlantService : IPlantService
    {
        private readonly List<Plant> _plants = new();

        // Retrieves all plants
        public List<Plant> GetPlantsByStage(PlantStage stage) =>
            _plants.Where(p => p.Stage == stage).ToList();

        //Adds a new plant to the top of the list
        public void AddPlant(Plant plant)
        {
            plant.VegStartDate = DateTime.Now;
            _plants.Insert(0, plant);
        }

        // Deletes a plant by its ID
        public void DeletePlant(Guid plantId)
        {
            var plant = _plants.FirstOrDefault(p => p.Id == plantId);
            if (plant != null)
            {
                _plants.Remove(plant);
            }
        }

        //Moves plant from veg -> flower -> harvest -> complete
        public void MoveToNextStage(Guid plantId)
        {
            var plant = _plants.FirstOrDefault(p => p.Id == plantId);
            if (plant == null) return;

            if (plant.Stage == PlantStage.Veg)
            {
                plant.Stage = PlantStage.Flower;
                plant.FlowerStartDate = DateTime.Now;
            }
            else if (plant.Stage == PlantStage.Flower)
            {
                plant.Stage = PlantStage.Harvest;
                plant.HarvestStartDate = DateTime.Now;
            }
            else if (plant.Stage == PlantStage.Harvest)
            {
                plant.Stage = PlantStage.Complete;
                plant.CureEndDate = DateTime.Now;
            }
        }

        public void StartCure(Guid plantId)
        {
            var plant = _plants.FirstOrDefault(p => p.Id == plantId);
            if (plant != null)
            {
                plant.CureStartDate = DateTime.Now;
            }
        }

        public void MarkComplete(Guid plantId, DateTime cureEndDate)
        {
            var plant = _plants.FirstOrDefault(p => p.Id == plantId);
            if (plant != null)
            {
                plant.CureEndDate = cureEndDate;
                plant.Stage = PlantStage.Complete;
            }
        }

        public void AddWatering(Guid plantId, WateringEntry entry)
        {
            var plant = _plants.FirstOrDefault(p => p.Id == plantId);
            plant?.Waterings.Add(entry);
        }

        public Plant GetPlantById(Guid id) => _plants.FirstOrDefault(p => p.Id == id);
    }
}

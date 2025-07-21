using PlantFertilizerLog.Models;
using System;

namespace PlantFertilizerLog.Services
{
    public interface IPlantService
    {
        List<Plant> GetPlantsByStage(PlantStage stage);// Retrieves all plants by their growth stage
        void AddPlant(Plant plant);// Adds a new plant to the top of the list
        void MoveToNextStage(Guid plantId);//veg -> flower -> harvest -> complete
        void AddWatering(Guid plantId, WateringEntry entry);// Adds a watering entry to the plant's watering list
        void DeletePlant(Guid plantId);// Deletes a plant by its ID

        Plant GetPlantById(Guid id);// Retrieves a plant by its ID
        void StartCure(Guid plantId);// Starts the curing process for a plant
        void MarkComplete(Guid plantId, DateTime cureEndDate);// Marks a plant as complete and sets the cure end date
    }
}

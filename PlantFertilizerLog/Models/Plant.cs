using System;
using System.Collections.Generic;

namespace PlantFertilizerLog.Models
{
    public enum PlantStage { Veg, Flower, Harvest, Complete }

    public class Plant
    {
        public Guid Id { get; set; } = Guid.NewGuid();//Guid is a globally unique identifier, and keeps UNIQUE identifiers for each plant
        public string Name { get; set; }
        public string Breeder { get; set; }
        public int PlantCount { get; set; }
        public DateTime DateStarted { get; set; }
        public string Type { get; set; }
        public string Origin { get; set; }
        public string Spectrum { get; set; }//sativa, indica, hybrid
        public string BudDensity { get; set; }//larf, medium, dense
        public string TrichomeColor { get; set; }//clear, cloudy, amber
        public PlantStage Stage { get; set; } = PlantStage.Veg;//default or beginning stage is Veg
        public List<WateringEntry> Waterings { get; set; } = new();// should create a watering entry card for MainPage
        public List<string> ImagePaths { get; set; } = new();//Upload images
        public DateTime? VegStartDate { get; set; }//start of veg cycle
        public DateTime? FlowerStartDate { get; set; }//start of flower cycle
        public DateTime? HarvestStartDate { get; set; }//begin dry
        public DateTime? CureStartDate { get; set; }//end dry, start cure
        public DateTime? CureEndDate { get; set; }//end cure
        public List<FertilizerEntry> DefaultFertilizers { get; set; } = new();//list of fertilizers for AddWateringPage

    }
}

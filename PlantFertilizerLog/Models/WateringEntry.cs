using System;
using System.Collections.Generic;

namespace PlantFertilizerLog.Models
{
    public class WateringEntry
    {
        public DateTime Date { get; set; } = DateTime.Now;//date and time of watering
        public float PH { get; set; }//pH level of the water
        public float PPM { get; set; }//parts per million of nutrients in the water
        public float TDS { get; set; }//total dissolved solids in the water
        public List<FertilizerEntry> Fertilizers { get; set; } = new();//list of fertilizers used in this watering
        public List<string> Images { get; set; } = new();//list of images taken during this watering
    }

    public class FertilizerEntry
    {
        public string Name { get; set; }
        public string NPK { get; set; }
        public string Amount { get; set; }
    }
}

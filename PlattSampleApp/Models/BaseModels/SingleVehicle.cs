using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlattSampleApp.Models.BaseModels
{
    public class SingleVehicle : IEqualityComparer<SingleVehicle>
    {
        [JsonProperty("cargo_capacity")]
        public string CargoCapacity { get; set; }

        [JsonProperty("consumables")]
        public string Consumables { get; set; }

        [JsonProperty("cost_in_credits")]
        public string Cost{ get; set; }

        [JsonProperty("crew")]
        public string Crew { get; set; }

        [JsonProperty("length")]
        public string Length{ get; set; }

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("passengers")]
        public string Passengers { get; set; }

        [JsonProperty("pilots")]
        public List<string> Pilots { get; set; }

        [JsonProperty("films")]
        public List<string> Films { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("vehicle_class")]
        public string VehicleClass { get; set; }

        public bool Equals(SingleVehicle x, SingleVehicle y)
        {
            return x.Manufacturer == y.Manufacturer;
        }

        public int GetHashCode(SingleVehicle obj)
        {
            return obj.ToString().ToLower().GetHashCode();
        }
    }
}
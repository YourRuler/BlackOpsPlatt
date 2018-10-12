using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlattSampleApp.Models.BaseModels
{
    public class AllVehicles
    {
        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("results")]
        public List<SingleVehicle> Results { get; set; }

        public void Conjoin(AllVehicles next)
        {
            Next = next.Next;
            Previous = next.Previous;
            Results.AddRange(next.Results);
        }

        public VehicleSummaryViewModel ToVehicleSummaryViewModel()
        {
            var model = new VehicleSummaryViewModel();

            model.VehicleCount = Results.Where(v => v.Cost != "unknown").Count();
            var distinctModels = Results.Select(v => v.Manufacturer).Distinct().ToList();
            model.ManufacturerCount = distinctModels.Count();
            var allVehicleStats = new List<VehicleStatsViewModel>();
            distinctModels.ForEach(m =>
            {

                var manufacturerVehicles = Results.Where(v => v.Cost != "unknown" && v.Manufacturer == m).ToList();
                if(manufacturerVehicles.Count() > 0)
                {
                    var vehicleStats = new VehicleStats();
                    vehicleStats.Manufacturer = m;
                    vehicleStats.Vehicles.AddRange(manufacturerVehicles);
                    allVehicleStats.Add(vehicleStats.ToVehicleStatsViewModel());
                }
            });
            allVehicleStats = allVehicleStats.OrderByDescending(v => v.VehicleCount).ThenByDescending(v => v.AverageCost).ToList();
            model.Details.AddRange(allVehicleStats);
            return model;
        }
    }
}
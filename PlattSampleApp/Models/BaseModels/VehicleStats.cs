using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlattSampleApp.Models.BaseModels
{
    public class VehicleStats
    {
        public string Manufacturer { get; set; }

        public List<SingleVehicle> Vehicles { get; set; }

        public int VehicleCount { get { return Vehicles.Where(v => v.Manufacturer == Manufacturer).Count(); }  }

        public double AverageCost { get {
                var relevantVehicles = Vehicles.Where(v => v.Manufacturer == Manufacturer).ToList();
                double avgCost = 0.0;
                relevantVehicles.ForEach(v =>
                {
                    try
                    {
                        avgCost += double.Parse(v.Cost);
                    }
                    catch { }
                });
                avgCost /= relevantVehicles.Count();
                return avgCost;
            }
        }

        public VehicleStats()
        {
            Vehicles = new List<SingleVehicle>();
        }

        public VehicleStatsViewModel ToVehicleStatsViewModel()
        {
            var model = new VehicleStatsViewModel();

            model.ManufacturerName = Manufacturer;
            model.VehicleCount = VehicleCount;
            model.AverageCost = AverageCost;

            return model;
        }
    }
}
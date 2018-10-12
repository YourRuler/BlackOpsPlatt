using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PlattSampleApp.Models.BaseModels
{
    public class AllPlanets 
    {
        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("results")]
        public List<SinglePlanet> Results { get; set; }

        public void Conjoin(AllPlanets next)
        {
            Next = next.Next;
            Previous = next.Previous;
            Results.AddRange(next.Results);
        }

        public AllPlanetsViewModel ToAllPlanetsViewModel()
        {
            var model = new AllPlanetsViewModel();

            model.Planets = Results.Select(r=>r.ToPlanetDetailsViewModel()).OrderByDescending(
                p => (p.Diameter == "unknown") ? -1 : long.Parse(p.Diameter)).ToList();

            var knownDiameters = model.Planets.Where(p => p.Diameter != "unknown").Select(p => long.Parse(p.Diameter)).ToList();

            double averageDiameter = 0;
            knownDiameters.ForEach(d => { averageDiameter += d; });
            averageDiameter /= knownDiameters.Count();

            model.AverageDiameter = averageDiameter;

            return model;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using Newtonsoft.Json;

namespace PlattSampleApp.Models.BaseModels
{
    public class SinglePlanet
    {
        [JsonProperty("climate")]
        public string Climate { get; set; }

        [JsonProperty("diameter")]
        public string Diameter { get; set; }

        [JsonProperty("gravity")]
        public string Gravity { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("orbital_period")]
        public string LengthOfYear { get; set; }

        [JsonProperty("population")]
        public string Population { get; set; }

        [JsonProperty("residents")]
        public List<string> Residents { get; set; }

        [JsonProperty("rotation_period")]
        public string LengthOfDay { get; set; }

        [JsonProperty("surface_water")]
        public string SurfaceWaterPercentage { get; set; }

        [JsonProperty("terrain")]
        public string Terrain { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        public SinglePlanetViewModel ToSinglePlanetViewModel()
        {
            var model = new SinglePlanetViewModel();

            model.Name = Name;
            model.LengthOfDay = LengthOfDay;
            model.LengthOfYear = LengthOfYear;
            model.Diameter = Diameter;
            model.Climate = Climate;
            model.Gravity = Gravity;
            model.SurfaceWaterPercentage = SurfaceWaterPercentage;
            model.Population = Population;

            return model;
        }

        public PlanetDetailsViewModel ToPlanetDetailsViewModel()
        {
            var model = new PlanetDetailsViewModel();

            model.Name = Name;
            model.Population = Population;
            model.Diameter = Diameter;
            model.Terrain = Terrain;
            model.LengthOfYear = LengthOfYear;

            return model;
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PlattSampleApp.Models.BaseModels
{
    public class SingleResident
    {
        [JsonProperty("birth_year")]
        public string BirthYear { get; set; }

        [JsonProperty("eye_color")]
        public string EyeColor { get; set; }

        [JsonProperty("films")]
        public List<string> Films { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("hair_color")]
        public string HairColor { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("homeworld")]
        public string Homeworld { get; set; }

        [JsonProperty("mass")]
        public string Weight { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("skin_color")]
        public string SkinColor { get; set; }

        [JsonProperty("species")]
        public List<string> Species { get; set; }

        [JsonProperty("starships")]
        public List<string> Starships { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("vehicles")]
        public List<string> Vehicles { get; set; }

        public ResidentSummary ToResidentSummary()
        {
            var model = new ResidentSummary();

            model.Name = Name;
            model.Height = Height;
            model.Weight = Weight;
            model.Gender = Gender;
            model.HairColor = HairColor;
            model.EyeColor = EyeColor;
            model.SkinColor = SkinColor;

            return model;
        }
    }
}
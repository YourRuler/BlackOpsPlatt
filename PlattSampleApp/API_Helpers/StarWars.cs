using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlattSampleApp.Models.BaseModels;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlattSampleApp.API_Helpers
{
    public class StarWars
    {
        static string EndPoint = "http://swapi.co/api";

        static async Task<string> MakeAPICall(string uri)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // Get API Response
            HttpResponseMessage response = client.GetAsync("").Result;
            client.Dispose();

            if (response.IsSuccessStatusCode)
            {
                string ret = await response.Content.ReadAsStringAsync();

                return ret;
            }
            return null;

        }

        public static AllPlanets GetAllPlanets()
        {
            var ret = new List<SinglePlanet>();

            var apiResponse = MakeAPICall($"{EndPoint}/planets").Result;

            if(apiResponse != null)
            {
                var allPlanets = JsonConvert.DeserializeObject<AllPlanets>(apiResponse);
                ret.AddRange(allPlanets.Results);
                while(allPlanets.Next != null)
                {
                    apiResponse = MakeAPICall($"{allPlanets.Next}").Result;
                    allPlanets.Conjoin(JsonConvert.DeserializeObject<AllPlanets>(apiResponse));
                }
                return allPlanets;
            }
            return null;
        }

        public static SinglePlanet GetSinglePlanetByID(int planetID)
        {
            var apiResponse = MakeAPICall($"{EndPoint}/planets/{planetID}").Result;
            if (apiResponse != null)
            {
                return JsonConvert.DeserializeObject<SinglePlanet>(apiResponse);
            }
            return null;
        }

        public static PlanetResidents GetPlanetResidents(string planetName)
        {
            var apiResponse = MakeAPICall($"{EndPoint}/planets/?search={planetName}").Result;
            if(apiResponse != null)
            {
                var allPlanets = JsonConvert.DeserializeObject<AllPlanets>(apiResponse);
                while (allPlanets.Next != null)
                {
                    apiResponse = MakeAPICall($"{allPlanets.Next}").Result;
                    allPlanets.Conjoin(JsonConvert.DeserializeObject<AllPlanets>(apiResponse));
                }

                var planet = allPlanets.Results.FirstOrDefault(p => p.Name == planetName);
                if(planet != null)
                {
                    var planetResidents = new PlanetResidents();
                    var allResidents = new List<SingleResident>();
                    planet.Residents.ForEach(r =>
                    {
                        apiResponse = MakeAPICall(r).Result;
                        if (apiResponse != null)
                        {
                            allResidents.Add(JsonConvert.DeserializeObject<SingleResident>(apiResponse));
                        }
                    });

                    planetResidents.Residents.AddRange(allResidents);
                    return planetResidents;
                };
            }
            return null;
        }

        public static AllVehicles GetAllVehicles()
        {
            var apiResponse = MakeAPICall($"{EndPoint}/vehicles").Result;
            if (apiResponse != null)
            {
                var allVehicles = JsonConvert.DeserializeObject<AllVehicles>(apiResponse);
                while(allVehicles.Next != null)
                {
                    apiResponse = MakeAPICall(allVehicles.Next).Result;
                    allVehicles.Conjoin(JsonConvert.DeserializeObject<AllVehicles>(apiResponse));
                }

                return allVehicles;
            }
            return null;
        }
    }
}
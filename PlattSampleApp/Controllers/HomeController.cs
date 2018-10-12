using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlattSampleApp.Models;
using PlattSampleApp.API_Helpers;

namespace PlattSampleApp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllPlanets()
        {
            var allPlanets = StarWars.GetAllPlanets();

            return View(allPlanets.ToAllPlanetsViewModel());
        }

        public ActionResult GetPlanetTwentyTwo(int planetid)
        {
            var planet = StarWars.GetSinglePlanetByID(planetid);

            return View(planet.ToSinglePlanetViewModel());
        }

        public ActionResult GetResidentsOfPlanetNaboo(string planetname)
        {
            var model = new PlanetResidentsViewModel();

            var planetResidents = StarWars.GetPlanetResidents(planetname);

            return View(planetResidents.ToPlanetResidentsViewModel());
        }

        public ActionResult VehicleSummary()
        {
            var allVehicles = StarWars.GetAllVehicles();

            return View(allVehicles.ToVehicleSummaryViewModel());
        }
    }
}
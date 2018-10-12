using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlattSampleApp.Models.BaseModels
{
    public class PlanetResidents
    {
        public List<SingleResident> Residents { get; set; }

        public PlanetResidents()
        {
            Residents = new List<SingleResident>();
        }

        public PlanetResidentsViewModel ToPlanetResidentsViewModel()
        {
            var model = new PlanetResidentsViewModel();

            model.Residents.AddRange(Residents.Select(r => r.ToResidentSummary()).OrderBy(r => r.Name).ToList());

            return model;
        }
    }
}
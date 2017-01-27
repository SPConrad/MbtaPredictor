using MbtaPredictor.Services;
using MbtaPredictor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading.Tasks;
using MbtaPredictor.Entities;

namespace MbtaPredictor.Controllers
{
    public class HomeController : Controller
    {
        private ITripData _tripData;
        private IVehicleData _vehicleData;

        private string apiKey = "wX9NwuHnZU2ToO7GmGR9uw";

        private string getVehiclesByRouteURL = "http://realtime.mbta.com/developer/api/v2/vehiclesbyroute?api_key=";

        private string routeFragment = "&route=";

        private string jsonFragment = "&format=json";

        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            //don't really get all of them that's crazy
            //model.Trips = _tripData.GetAll();
            return View(model);
        }

        [HttpGet]
        [Route("/Home/GetRoutes")]
        public async Task<IActionResult> GetRoutes(HomePageViewModel model)
        {
            string urlToSend = getVehiclesByRouteURL + apiKey + routeFragment + model.routeType.ToString() + jsonFragment;
            var result = await WebCalls.GetUrl(urlToSend);
            ViewData["result"] = result;
            ParseAndSend(result);
            return View();
        }

        public void ParseAndSend(string data)
        {
            JObject json = JObject.Parse(data);

            JsonTextReader reader = new JsonTextReader(new StringReader(data));

            Object direction0 = json.GetValue("direction")[0];
            Object direction1 = json.GetValue("direction")[1];
        }

    }
}

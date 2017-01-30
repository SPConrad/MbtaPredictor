using MbtaPredictor.Services;
using MbtaPredictor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using MbtaPredictor.Entities;
using System.Collections;
using System.Collections.Generic;

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

        public HomeController(ITripData tripData, IVehicleData vehicleData)
        {
            _tripData = tripData;
            _vehicleData = vehicleData;
        }

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

            JObject jDirection0 = (JObject)json["direction"][0];

            List<JObject> direction0List = new List<JObject>();

            jDirection0["trip"].Count();

            foreach (JObject token in jDirection0["trip"])
            {
                direction0List.Add(token);

                Vehicle _vehicle = new Vehicle();
                Trip _trip = new Trip();

                //_trip.Id = token["id"];
                _trip.Id = token["trip_id"].ToString();
                _trip.TripHeadSign = token["trip_headsign"].ToString();
                _trip.TripName = token["trip_name"].ToString();
                _trip.Vehicle = token["vehicle"]["vehicle_id"].ToString();

                //Id = Int32.Parse(token["trip_id"].ToString());
                _vehicle.Vehicle_Id = token["vehicle"]["vehicle_id"].ToString();
                _vehicle.Lat = token["vehicle"]["vehicle_lat"].ToString();
                _vehicle.Lon = token["vehicle"]["vehicle_lon"].ToString();
                _vehicle.Bearing = Int32.Parse(token["vehicle"]["vehicle_bearing"].ToString());
                _vehicle.Timestamp = token["vehicle"]["vehicle_timestamp"].ToString();
                _vehicle.Label = token["vehicle"]["vehicle_label"].ToString();

                _vehicleData.Commit();
                _vehicleData.Add(_vehicle);
                _tripData.Commit();
                _tripData.Add(_trip);


            }
        }

    }
}

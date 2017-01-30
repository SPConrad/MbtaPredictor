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

        private string apiKey = "wX9NwuHnZU2ToO7GmGR9uw";

        private string getVehiclesByRouteURL = "http://realtime.mbta.com/developer/api/v2/vehiclesbyroute?api_key=";

        private string routeFragment = "&route=";

        private string jsonFragment = "&format=json";

        public HomeController(ITripData tripData)
        {
            _tripData = tripData;
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

            List<JObject> directionList = new List<JObject>();

            Object direction0 = json.GetValue("direction")[0];
            Object direction1 = json.GetValue("direction")[1];

            JObject jDirection0 = (JObject)json["direction"][0];

            directionList.Add((JObject)json["direction"][0]);
            directionList.Add((JObject)json["direction"][1]);

            jDirection0["trip"].Count();
            foreach (JObject direction in directionList)
            {
                foreach (JObject token in direction["trip"])
                {
                    Trip _trip = new Trip();
                    
                    _trip.Trip_Id = Int32.Parse(token["trip_id"].ToString());
                    _trip.Trip_HeadSign = token["trip_headsign"].ToString();
                    _trip.Trip_Name = token["trip_name"].ToString();

                    _trip.Vehicle_Id = token["vehicle"]["vehicle_id"].ToString();
                    _trip.Vehicle_Lat = token["vehicle"]["vehicle_lat"].ToString();
                    _trip.Vehicle_Lon = token["vehicle"]["vehicle_lon"].ToString();
                    _trip.Vehicle_Bearing = token["vehicle"]["vehicle_bearing"].ToString();
                    _trip.Vehicle_Timestamp = token["vehicle"]["vehicle_timestamp"].ToString();
                    _trip.Vehicle_Label = token["vehicle"]["vehicle_label"].ToString();

                    _tripData.Commit();
                    _tripData.Add(_trip);
                }
            }
        }

    }
}

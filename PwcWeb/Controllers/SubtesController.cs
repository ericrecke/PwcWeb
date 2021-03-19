using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PwcWeb.Models;
using PwcWeb.Models.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PwcWeb.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SubtesController : Controller
    {
        private MyDBContext db;
        public SubtesController(MyDBContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]")]
        public List<SubtesReturn> GetSubtes()
        {
            try
            {
                List<SubtesReturn> NewList = new List<SubtesReturn>();
                var Url = UrbanConfig.ApiUrl + UrbanConfig.EnumTypeServices.subtes.ToString() + "/serviceAlerts?json=1&client_id=" + UrbanConfig.ClientId + "&client_secret=" + UrbanConfig.ClientSecret;
                var client = new RestClient(Url);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var JsonData = JsonConvert.DeserializeObject<Subtes>(response.Content);
                    foreach (var md in JsonData.entity)
                    {
                        var NewModel = new SubtesReturn()
                        {
                            Id = md.id,
                            Letra = md.alert.informed_entity[0].route_id.Replace("Linea", ""),
                            Name = md.alert.informed_entity[0].route_id,
                            DescriptionInfo = md.alert.description_text.translation[0].text,
                            HeaderInfo = md.alert.header_text.translation[0].text,
                            Fecha = new DateTime(1970, 1, 1).Add(TimeSpan.FromSeconds(JsonData.header.timestamp)).ToLocalTime()
                        };
                        NewList.Add(NewModel);
                        AddLog(NewModel);
                    }
                    db.SaveChanges();
                    if (JsonData == null)
                        return new List<SubtesReturn>(); //or any other error code accordingly. Bad request is a strong candidate also.
                    return NewList;
                }
                else
                {
                    return new List<SubtesReturn>();
                }
            }
            catch (Exception ex)
            {
                return new List<SubtesReturn>();
            }

        }



        [HttpGet("[action]")]
        public SubwayMain GetSubtesGTFS(string Line = "0", string Station = "0", string Destination = "0", string search = "0")
        {
            List<SubwayGtfs> NewList = new List<SubwayGtfs>();
            SubwayMain Main = new SubwayMain();
            var Url = UrbanConfig.ApiUrl + UrbanConfig.EnumTypeServices.subtes.ToString() + "/forecastGTFS?client_id=" + UrbanConfig.ClientId + "&client_secret=" + UrbanConfig.ClientSecret;
            var client = new RestClient(Url);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var JsonData = JsonConvert.DeserializeObject<SubtesGTFS>(response.Content);
                foreach (var md in JsonData.Entity)
                {
                    var Model = LoadSubway(md);
                    NewList.Add(Model);
                }
                Main.GTFS.AddRange(NewList);
                Main.GTFS = Main.GTFS.GroupBy(x => x.Id_Route, (key, group) => group.First()).ToList();
                if (search != null && search != "0")
                {
                    var GetLine = Main.GTFS[Convert.ToInt32(Line)];
                    var Search = JsonData.Entity.Where(x => x.Linea.Direction_ID == Convert.ToInt32(Destination) && x.Linea.Route_Id == GetLine.Id_Route).FirstOrDefault();
                    if (Search != null)
                    {
                        var ModelSearch = LoadSubway(Search);
                        var StationId = GetLine.Stations.Where(x => x.id == Station).Select(x => x.stop_name).FirstOrDefault();
                        ModelSearch.Stations = ModelSearch.Stations.Where(x => x.stop_name == StationId).ToList();
                        Main.SearchValue = ModelSearch;
                    }
                }
                if (JsonData == null)
                    return new SubwayMain();
                return Main;
            }
            else
            {
                return new SubwayMain();
            }
        }

        [HttpGet("[action]")]
        public HistoryViewModel GetHistories(DateTime FechaDesde = new DateTime(), string Line = "0")
        {
            var TakeHistories = new HistoryViewModel();
            var Fecha = FechaDesde.Date;
            TakeHistories.Histories = db.SubwayHistory.Where(x => ((Line == "0" || Line == "Todas las Lineas") || x.Line == Line) && (FechaDesde == null || x.Date == Fecha)).ToList();
            TakeHistories.Lines.Add(new LineName() { Id = "Todas las Lineas" });
            TakeHistories.Lines.AddRange(db.SubwayHistory.Select(x => new LineName { Id = x.Line }).Distinct().ToList());
            return TakeHistories;
        }

        #region Functions
        public void AddLog(SubtesReturn Data)
        {
            var CheckDate = db.SubwayHistory.Where(x => x.Date == DateTime.Today && x.Line == Data.Name).FirstOrDefault();
            if (CheckDate != null)
            {
                CheckDate.Result = Data.DescriptionInfo;
                db.Entry(CheckDate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                db.SubwayHistory.Add(new SubwayHistory() { Date = DateTime.Today, Line = Data.Name, Result = Data.DescriptionInfo });
            }
        }
        public SubwayGtfs LoadSubway(EntityGTFS Entity)
        {
            var NewModel = new SubwayGtfs()
            {
                Id = Entity.Linea.Trip_Id,
                Id_Route = Entity.Linea.Route_Id,
                Line = Entity.Linea.Route_Id.Replace("Linea", ""),
                Date_Start = Entity.Linea.start_date,
                Time_Start = Entity.Linea.start_time,
                Stations = Entity.Linea.Estaciones
            };
            var NameDirectionFirst = Entity.Linea.Estaciones.First().stop_name + " a " + Entity.Linea.Estaciones.Last().stop_name;
            var NameDirectionSecond = Entity.Linea.Estaciones.Last().stop_name + " a " + Entity.Linea.Estaciones.First().stop_name;
            NewModel.Directions.Add(new Direction() { Id_Direction = Entity.Linea.Direction_ID, NameDirection = NameDirectionFirst });
            NewModel.Directions.Add(new Direction() { Id_Direction = Entity.Linea.Direction_ID == 1 ? 0 : 1, NameDirection = NameDirectionSecond });
            var stationCount = 0;
            foreach (var station in NewModel.Stations)
            {
                station.arrival.Fecha = new DateTime(1970, 1, 1).Add(TimeSpan.FromSeconds(station.arrival.time)).ToLocalTime();
                station.departure.Fecha = new DateTime(1970, 1, 1).Add(TimeSpan.FromSeconds(station.departure.time)).ToLocalTime();
                station.id = stationCount.ToString();
                stationCount += 1;
            }
            return NewModel;
        }

        #endregion
    }
}

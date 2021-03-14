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
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet("[action]")]
        //public Subtes GetSubtes()
        //{
        //    var Url = UrbanConfig.ApiUrl + UrbanConfig.EnumTypeServices.subtes.ToString() + "/serviceAlerts?json=1&client_id=" + UrbanConfig.ClientId + "&client_secret=" + UrbanConfig.ClientSecret;
        //    var client = new RestClient(Url);
        //    var request = new RestRequest(Method.GET);
        //    IRestResponse response = client.Execute(request);
        //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        var JsonData = JsonConvert.DeserializeObject<Subtes>(response.Content);
        //        if (JsonData == null)
        //            return new Subtes(); //or any other error code accordingly. Bad request is a strong candidate also.
        //        return JsonData;
        //    }
        //    else
        //    {
        //        return new Subtes();
        //    }
        //}
        [HttpGet("[action]")]
        public List<SubtesReturn> GetSubtes()
        {
            List<SubtesReturn> NewList = new List<SubtesReturn>();
            var Url = UrbanConfig.ApiUrl + UrbanConfig.EnumTypeServices.subtes.ToString() + "/serviceAlerts?json=1&client_id=" + UrbanConfig.ClientId + "&client_secret=" + UrbanConfig.ClientSecret;
            var client = new RestClient(Url);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var JsonData = JsonConvert.DeserializeObject<Subtes>(response.Content);
                foreach(var md in JsonData.entity)
                {
                    var NewModel = new SubtesReturn()
                    {
                        Id = md.id,
                        Letra = md.alert.informed_entity[0].route_id.Replace("Linea",""),
                        Name = md.alert.informed_entity[0].route_id,
                        DescriptionInfo = md.alert.description_text.translation[0].text,
                        HeaderInfo = md.alert.header_text.translation[0].text,
                        Fecha = new DateTime(1970,1,1).Add(TimeSpan.FromSeconds(JsonData.header.timestamp)).ToLocalTime()
                    };
                    NewList.Add(NewModel);
                }
                if (JsonData == null)
                    return new List<SubtesReturn>(); //or any other error code accordingly. Bad request is a strong candidate also.
                return NewList;
            }
            else
            {
                return new List<SubtesReturn>();
            }
        }



        [HttpGet("[action]")]
        public SubtesGTFS GetSubtesGTFS()
        {
            var Url = UrbanConfig.ApiUrl + UrbanConfig.EnumTypeServices.subtes.ToString() + "/forecastGTFS?client_id=" + UrbanConfig.ClientId + "&client_secret=" + UrbanConfig.ClientSecret;
            var client = new RestClient(Url);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var JsonData = JsonConvert.DeserializeObject<SubtesGTFS>(response.Content);
                if (JsonData == null)
                    return new SubtesGTFS(); //or any other error code accordingly. Bad request is a strong candidate also.
                return JsonData;
            }
            else
            {
                return new SubtesGTFS();
            }
        }

        //[HttpGet("[action]")]
        //public async IAsyncEnumerable<IActionResult> GetSubtes()
        //{
        //    var Url = UrbanConfig.ApiUrl + UrbanConfig.EnumTypeServices.subtes.ToString() + "/serviceAlerts?json=1&client_id=" + UrbanConfig.ClientId + "&client_secret=" + UrbanConfig.ClientSecret;
        //    var client = new RestClient(Url);
        //    var request = new RestRequest(Method.GET);
        //    IRestResponse response = await client.ExecuteAsync(request);
        //    if(response.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        var JsonData = JsonConvert.DeserializeObject<Subtes>(response.Content);
        //        List<Subtes> Subtes = new List<Subtes>();
        //        Subtes.Add(JsonData);
        //        if (JsonData == null)
        //            yield return NotFound(); //or any other error code accordingly. Bad request is a strong candidate also.
        //        yield return Ok(Subtes);
        //    } else
        //    {
        //        yield return NotFound();
        //    }
        //}

        //[HttpGet("[action]")]
        //public async IAsyncEnumerable<IActionResult> GetSubtesGTFS()
        //{
        //    var Url = UrbanConfig.ApiUrl + UrbanConfig.EnumTypeServices.subtes.ToString() + "/forecastGTFS?client_id=" + UrbanConfig.ClientId + "&client_secret=" + UrbanConfig.ClientSecret;
        //    var client = new RestClient(Url);
        //    var request = new RestRequest(Method.GET);
        //    IRestResponse response = await client.ExecuteAsync(request);
        //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        var JsonData = JsonConvert.DeserializeObject<SubtesGTFS>(response.Content);
        //        if (JsonData == null)
        //            yield return NotFound(); //or any other error code accordingly. Bad request is a strong candidate also.
        //        yield return Ok(JsonData);
        //    }
        //    else
        //    {
        //        yield return NotFound();
        //    }

        //}
    }
}

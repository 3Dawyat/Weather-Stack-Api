using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WeatherStack_Api.Models;

namespace WeatherStack_Api
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var jsonData = await Task.Run(() => JsonCallApi("https://countriesnow.space/api/v0.1/countries"));
            Country country = JsonConvert.DeserializeObject<Country>(jsonData);
            HomeModel model = new HomeModel
            {
                Country = country.data.Take(65).ToList()
            };
            return View(model);
        }
        public string JsonCallApi(string url)
        {
            HttpWebRequest request = HttpWebRequest.CreateHttp(url);
            var respons = request.GetResponse();
            StreamReader reader = new StreamReader(respons.GetResponseStream());
            var json = reader.ReadToEnd();
            return json;
        }
        public async Task <IActionResult> Weather(string countryName)
        {
            var jsonWeather = await Task.Run(() => JsonCallApi($"http://api.weatherstack.com/current?access_key=769ee8144d9bc3fa88a52c6c97632fc7&query={countryName}"));
            var jsonCountry = await Task.Run(() => JsonCallApi("https://countriesnow.space/api/v0.1/countries"));
            Country country = JsonConvert.DeserializeObject<Country>(jsonCountry);
            Weather weather = JsonConvert.DeserializeObject<Weather>(jsonWeather);
            HomeModel model = new HomeModel
            {
                Country = country.data.Take(70).ToList(),
                Weather= weather
            };
            return View(model);
        }
    }
}
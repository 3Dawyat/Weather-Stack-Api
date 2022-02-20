using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherStack_Api.Models
{
    public class HomeModel
    {
        public List<Datum> Country { get; set; }
        public string CountryName { get; set; }
        public Weather Weather  { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankData.Model
{
    [JsonObject]
    public class Data
    {
        public Indicator indicator { get; set; }
        public Country country { get; set; }
        public string countryiso3code { get; set; }
        public string date { get; set; }
        public decimal? value { get; set; }
        public string unit { get; set; }
        public string obs_status { get; set; }
        public int? _decimal { get; set; }
    }

    public class Indicator
    {
        public string id { get; set; }
        public string value { get; set; }
    }

    public class Country
    {
        public string id { get; set; }
        public string value { get; set; }
    }
}

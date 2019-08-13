using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankData.Model
{
    public class OutputResponse
    {
        public PagingDetail PagingDetail { get; set; }
        public List<Data> Data { get; set; }
    }



    [JsonObject]
    public class PagingDetail
    {
        public int? page { get; set; }
        public int? pages { get; set; }
        public int? per_page { get; set; }
        public int? total { get; set; }
        public string sourceid { get; set; }
        public string lastupdated { get; set; }
    }
}

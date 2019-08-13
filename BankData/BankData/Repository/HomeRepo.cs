using BankData.Interface;
using BankData.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BankData.Repository
{

    public class HomeRepo : IHomeInterface
    {
        private OutputResponse send { get; set; }

        public HomeRepo()
        { }

        public async Task<OutputResponse> GetList()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.worldbank.org");
                    using (var response = client.GetAsync("v2/country/all/indicator/NY.GDP.MKTP.CD?date=2018&per_page=500&format=json").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            response.EnsureSuccessStatusCode();
                            var result = await response.Content.ReadAsStringAsync();

                            //get the array object
                            var arrayResponse = JsonConvert.DeserializeObject<object[]>(result.ToString());

                            send = new OutputResponse
                            {
                                PagingDetail = JsonConvert.DeserializeObject<PagingDetail>(arrayResponse[0].ToString()),
                                Data = JsonConvert.DeserializeObject<List<Data>>(arrayResponse[1].ToString())
                            };
                        }
                        else if(!response.IsSuccessStatusCode)
                        {
                            throw new Exception((int)response.StatusCode + "-" + response.StatusCode.ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                var p = e.Message;
            }

            return send;
        }
    }
}

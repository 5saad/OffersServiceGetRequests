using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffersServiceGetRequests
{
    class PostRequest
    {
        private HttpClient client;
        private string endpoint;
        private string accessToken;


        public PostRequest(string endpoint, string accessToken)
        {
            this.client = new HttpClient();
            this.endpoint = endpoint;
            this.accessToken = accessToken;
        }

        public async Task PostReq()
        {
            long id = 1000000000000000;

            while (true)
            {

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var body = new
                    {
                        cardAccountId = id.ToString()
                    };

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(body);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(endpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Sucess: " + (int)response.StatusCode);
                    }
                    else
                    {
                        Console.WriteLine("Failed: " + (int)response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);

                }

                id += 1;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OffersServiceGetRequests
{
    class GetRequest
    {

        private HttpClient client;
        private string endpoint;

        public GetRequest(string endpoint)
        {
            this.client = new HttpClient();
            this.endpoint = endpoint;
        }

        public async Task GetReq(int numberOfRequests)
        {

            for (int i = 0; i < numberOfRequests; i++)
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(endpoint);

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
            }
        }

    }
}

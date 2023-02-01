using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OffersServiceGetRequests
{
    class GetRequest
    {

        private HttpClient client;
        private string endpoint;
        private string accessToken;


        public GetRequest(string endpoint, string accessToken)
        {
            this.client = new HttpClient();
            this.endpoint = endpoint;
            this.accessToken = accessToken;
        }

        public async Task GetReq()
        {

            while (true)
            {

                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                  
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

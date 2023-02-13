using System;
using System.Collections.Generic;
using System.Diagnostics;
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

  
            {

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                try
                {
                    var body = new
                    {
                        cardAccountId = "7365010001121626"
                    };

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(body);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    Stopwatch watch = Stopwatch.StartNew();

                    DateTime startTime = DateTime.Now;

                    HttpResponseMessage response = await client.PostAsync(endpoint, content);

                    watch.Stop();
                    var elapsed = watch.ElapsedMilliseconds;


                    

                    if (response.IsSuccessStatusCode)
                    {

                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Sucess: " + (int)response.StatusCode + " - " + startTime + " - " + elapsed + "ms", Console.ForegroundColor);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Failed: " + (int)response.StatusCode + " - " + startTime + " - " + elapsed + "ms", Console.ForegroundColor);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);

                }
            }
        }

        private static Random RNG = new Random();

        public string Create16DigitString()
        {
            var builder = new StringBuilder();
            while (builder.Length < 16)
            {
                builder.Append(RNG.Next(10).ToString());
            }
            return builder.ToString();
        }



    }
}

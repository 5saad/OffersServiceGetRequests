using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffersServiceGetRequests
{
    class GetToken
    {
        private string endpoint;
        private Process process = new Process();

        public GetToken(string endpoint)
        {
            this.endpoint = endpoint;
        }


        public string GrabToken()
        {
            

            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments= "/C az account get-access-token --resource=" + endpoint;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;

            process.Start();

            string output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();

            JObject json = JObject.Parse(output);
            string accessToken = (string)json["accessToken"];

            return accessToken;

        }


    }
}

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MvvmDemo.Core.Models;
using Newtonsoft.Json;

namespace MvvmDemo.Core.Helpers
{
    public class HttpHelper
    {

        public async Task<APIResponse> callAPI(string endpoint)
        {
            APIResponse res = new APIResponse();
            try
            {
                string content = string.Empty;
                var httpClient = new HttpClient();
                HttpResponseMessage httpResponse = null;
                httpResponse = await httpClient.GetAsync(APIHelper.getFormalizedURL(endpoint));
                
                if (httpResponse.IsSuccessStatusCode)
                {
                    content = await httpResponse.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<Root>(content);
                    res.response = data.data.results;
                    res.message = "All right!";
                    res.result = true;
                }
                else
                {
                    res.response = "";
                    res.message = "Invalid Response";
                    res.result = false;
                }

                return res;
            }
            catch (Exception ex)
            {
                res.response = ex.Message.ToString();
                res.message = "Invalid Response";
                res.result = false;
                return res;
            }
        }

    }
}

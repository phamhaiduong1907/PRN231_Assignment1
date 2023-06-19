using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ass1Client.Utilities
{
    class CallAPIUtils
    {
        HttpClient client;
        public CallAPIUtils()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5170/");
        }

        public string Get(string url)
        {
            HttpResponseMessage result = client.GetAsync(url).Result;
            if(result.IsSuccessStatusCode)
                return result.Content.ReadAsStringAsync().Result;
            else
                return string.Empty;
        }

        public string Post(string url, HttpContent httpContent)
        {
            HttpResponseMessage result = client.PostAsync(url, httpContent).Result;
            if (!result.IsSuccessStatusCode)
                return "error";
            return result.Content.ReadAsStringAsync().Result;
        }

        public string Put(string url, HttpContent httpContent)
        {
            HttpResponseMessage result = client.PutAsync(url, httpContent).Result;
            if (!result.IsSuccessStatusCode)
                return "error";
            return result.Content.ReadAsStringAsync().Result;
        }

        public string Delete(string url)
        {
            HttpResponseMessage result = client.DeleteAsync(url).Result;
            if (!result.IsSuccessStatusCode)
                return "error";
            return result.Content.ReadAsStringAsync().Result;
        }
    }
}

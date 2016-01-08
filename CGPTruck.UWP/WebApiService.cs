using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CGPTruck.UWP
{
    public class WebApiService
    {
        public static WebApiService Current { get; set; } = new WebApiService();

        private string token;

        private HttpClient GetClient()
        {
            return new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:8692/"),
                DefaultRequestHeaders =
                {
                    Accept =
                    {
                        new MediaTypeWithQualityHeaderValue("application/json")
                    },
                    Authorization = string.IsNullOrEmpty(token)? null : new AuthenticationHeaderValue("Bearer", token)
                }
            };
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsync("/token", new System.Net.Http.FormUrlEncodedContent(new Dictionary<string, string>
                {
                    ["grant_type"] = "password",
                    ["username"] = username,
                    ["password"] = password
                }));

                if (response.IsSuccessStatusCode)
                {
                    this.token = (JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync()) as dynamic).access_token.ToString();
                }

                return response.IsSuccessStatusCode;
            }
        }

        //static async Task RunAsync()
        //{
        //    using (var client = GetClient())
        //    {
        //        // HTTP GET
        //        HttpResponseMessage response = await client.GetAsync("api/products/1");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            Product product = await response.Content.ReadAsAsync<Product>();
        //            Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
        //        }

        //        // HTTP POST
        //        var gizmo = new Product() { Name = "Gizmo", Price = 100, Category = "Widget" };
        //        response = await client.PostAsJsonAsync("api/products", gizmo);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            Uri gizmoUrl = response.Headers.Location;

        //            // HTTP PUT
        //            gizmo.Price = 80;   // Update price
        //            response = await client.PutAsJsonAsync(gizmoUrl, gizmo);

        //            // HTTP DELETE
        //            response = await client.DeleteAsync(gizmoUrl);
        //        }
        //    }
        //}

    }
}

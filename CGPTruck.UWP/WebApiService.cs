using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CGPTruck.UWP
{
    public static class WebApiService
    {
        private static HttpClient GetClient()
        {
            return new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:8692/"),
                DefaultRequestHeaders =
                {
                    Accept =
                    {
                        new MediaTypeWithQualityHeaderValue("application/json")
                    }
                }
            };
        }

        public static async Task Authenticate(string username, string password)
        {
            using (var client = GetClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/auth", new { Email = username, Password = password });
                if (response.IsSuccessStatusCode)
                {

                }
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

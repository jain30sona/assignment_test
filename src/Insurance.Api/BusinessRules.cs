using System;
using System.Net.Http;
using Insurance.Service.Controllers;
using Newtonsoft.Json;

namespace Insurance.Service
{
    public static class BusinessRules
    {
        public static void GetProductType(string baseAddress, int productID, ref HomeController.InsuranceDto1 insurance)
        {
            HttpClient client = new HttpClient{ BaseAddress = new Uri(baseAddress)};
            string json = client.GetAsync("/product_types").Result.Content.ReadAsStringAsync().Result;
            var collection = JsonConvert.DeserializeObject<dynamic>(json);

            json = client.GetAsync(string.Format("/products/{0:G}", productID)).Result.Content.ReadAsStringAsync().Result;
            var product = JsonConvert.DeserializeObject<dynamic>(json);

            int productTypeId = product.productTypeId;
            string productTypeName = null;
            bool hasInsurance = false;

            insurance = new HomeController.InsuranceDto1();

            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i].id == productTypeId && collection[i].canBeInsured == true)
                {
                    insurance.ProductTypeName = collection[i].name;
                    insurance.ProductTypeHasInsurance = true;
                }
            }
        }

        public static void GetSalesPrice(string baseAddress, int productID, ref HomeController.InsuranceDto1 insurance)
        {
            HttpClient client = new HttpClient{ BaseAddress = new Uri(baseAddress)};
            string json = client.GetAsync(string.Format("/products/{0:G}", productID)).Result.Content.ReadAsStringAsync().Result;
            var product = JsonConvert.DeserializeObject<dynamic>(json);

            insurance.SalesPrice = product.salesPrice;
        }
    }
}
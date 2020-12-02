using System;
using System.Collections.Generic;
using System.Net.Http;
using Insurance.Infrastructure.Abstraction;
using Insurance.Infrastructure.Domain;
using Newtonsoft.Json;

namespace Insurance.Infrastructure
{
    public class DataAccessService : IDataAccessService
    {
        
        private readonly IHttpClientService _httpClientService;

        public DataAccessService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public List<Product> GetProducts(List<int> productIDsList)
        {
            var products = new List<Product>();
            foreach (var productId in productIDsList)
            {
                string url = string.Format("/products/{0:G}", productId);
                string json = _httpClientService.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
                var product = JsonConvert.DeserializeObject<Product>(json);
                products.Add(product);
            }

            return products;

        }

        List<ProductType> IDataAccessService.GetProductTypes()
        {
            string url = "/product_types";
            string json = _httpClientService.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            var productType = JsonConvert.DeserializeObject<List<ProductType>>(json);
            return productType;
        }
    }
}

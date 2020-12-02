using System.Collections.Generic;
using System.Text.Json.Serialization;
using Insurance.Core;
using Insurance.Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Service.Controllers
{
    public class HomeController : Controller
    {
        public readonly IInsuranceManager _insuranceManager;
        public HomeController(IInsuranceManager insuranceManager)
        {
            _insuranceManager = insuranceManager;

        }

        [HttpGet]
        [Route("api/insurance/product")]
        public string test()
        {
            return "Hello";
        }

        //[HttpPost]
        //[Route("api/insurance/product")]
        //public InsuranceDto1 CalculateInsurance([FromBody] InsuranceDto1 toInsure)
        //{
        //    int productId = toInsure.ProductId;

        //    BusinessRules.GetProductType(ProductApi, productId, ref toInsure);
        //    BusinessRules.GetSalesPrice(ProductApi, productId, ref toInsure);

        //    float insurance = 0f;

        //    if (toInsure.SalesPrice < 500)
        //        toInsure.InsuranceValue = 0;
        //    else
        //    {
        //        if (toInsure.SalesPrice > 500 && toInsure.SalesPrice < 2000)
        //            if (toInsure.ProductTypeHasInsurance)
        //                toInsure.InsuranceValue += 1000;
        //        if (toInsure.SalesPrice >= 2000)
        //            if (toInsure.ProductTypeHasInsurance)
        //                toInsure.InsuranceValue += 2000;
        //        if (toInsure.ProductTypeName == "Laptops" || toInsure.ProductTypeName == "Smartphones" && toInsure.ProductTypeHasInsurance)
        //            toInsure.InsuranceValue += 500;
        //    }

        //    return toInsure;
        //}

        [HttpPost]
        [Route("api/insurance")]
        public OrderDto CalculateInsurance([FromBody] List<int> productId)
        {
            OrderDto toInsure = new OrderDto();
            toInsure = _insuranceManager.AddInsuranceDetailByProductId(productId);
            return toInsure;
        }

        public class InsuranceDto1
        {
            public int ProductId { get; set; }
            public float InsuranceValue { get; set; }
            [JsonIgnore]
            public string ProductTypeName { get; set; }
            [JsonIgnore]
            public bool ProductTypeHasInsurance { get; set; }
            [JsonIgnore]
            public float SalesPrice { get; set; }
        }

        private const string ProductApi = "http://localhost:5002";
    }
}
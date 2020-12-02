using System.Collections.Generic;
using System.Linq;
using Insurance.Core.Abstraction;
using Insurance.Core.Dto;
using Insurance.Infrastructure;
using Insurance.Infrastructure.Domain;

namespace Insurance.Core
{
    public class InsuranceManager : IInsuranceManager
    {
        private readonly IDataAccessService _dataAccessService;
        private readonly IProductRuleBuilder _productRuleBuilder;
        private readonly IOrderRuleBuilder _orderRuleBuilder;
        private List<IProductInsurance> _insuranceCalculates;
        private List<IOrderInsurance> _insuranceCalculateOrders;
        public InsuranceManager(IDataAccessService dataAccessService, IOrderRuleBuilder orderRuleBuilder)
        {
            _dataAccessService = dataAccessService;
            _productRuleBuilder = new ProductRuleBuilder();
            _productRuleBuilder.InsuranceValueRules();
            _orderRuleBuilder = orderRuleBuilder;
            _orderRuleBuilder.RegisterOrderBusinessRules();
        }
        public OrderDto AddInsuranceDetailByProductId(List<int> productId)
        {
            List<Product> products = _dataAccessService.GetProducts(productId);
            List<ProductType> productTypes = _dataAccessService.GetProductTypes(); //Get particula producttypeid by



            float insuranceValue = 0;
            var insurances = new List<InsuranceDto>();
            foreach (var product in products)
            {
                var insurance = new InsuranceDto
                {
                    ProductId = product.Id, ProductTypeName = product.Name, SalesPrice = product.SalesPrice
                };
                foreach (var productType in productTypes.Where(productType => product.ProductTypeId == productType.Id))
                {
                    insurance.ProductTypeName = productType.Name;
                    insurance.ProductTypeHasInsurance = productType.CanBeInsured;
                }             
                insuranceValue += CalculateInsuranseValue(insurance);
                insurances.Add(insurance);
            }

            //Calculate insurance per order 

            insuranceValue+=CalculateInsuranceOnOrder(insurances);
           

            //foreach (var _productType in productType)
            //{
            //    if (_productType.Id == productTypeId && _productType.CanBeInsured == true)
            //    {
            //        insurance.ProductTypeName = _productType.Name;
            //        insurance.ProductTypeHasInsurance = true;
            //    }
            //}

            //insurance.SalesPrice = product.SalesPrice;

            //insurance = 0f;

            //if (insurance.SalesPrice < 500)
            //    insurance.InsuranceValue = 0;
            //else
            //{
            //    if (insurance.SalesPrice > 500 && insurance.SalesPrice < 2000)
            //        if (insurance.ProductTypeHasInsurance)
            //            insurance.InsuranceValue += 1000;
            //    if (insurance.SalesPrice >= 2000)
            //        if (insurance.ProductTypeHasInsurance)
            //            insurance.InsuranceValue += 2000;
            //    if (insurance.ProductTypeName == "Laptops" || insurance.ProductTypeName == "Smartphones" && insurance.ProductTypeHasInsurance)
            //        insurance.InsuranceValue += 500;
            //}

            return new OrderDto()
            {
                insuranceDtos = insurances,
                TotalOrderInsuranceCost = insuranceValue
            };
        }

        private float CalculateInsuranseValue(InsuranceDto insurance)
        {
            float insuranceValue = 0;
            _insuranceCalculates = _productRuleBuilder.GetInsuranceValueRules();
            foreach (IProductInsurance insuranceCalculate in _insuranceCalculates)
            {
                insuranceValue += insuranceCalculate.CalculateInsurance(insurance);
            }

            return insuranceValue;
        }
        private float CalculateInsuranceOnOrder(List<InsuranceDto> insurance)
        {
            float insuranceValue = 0;
            _insuranceCalculateOrders = _orderRuleBuilder.GetOrderBusinessRules();
            foreach (IOrderInsurance insuranceCalculateOrder in _insuranceCalculateOrders)
            {
                insuranceValue += insuranceCalculateOrder.CalculateInsurance(insurance);
            }
            return insuranceValue;
        }
    }
}

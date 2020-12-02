using System;
using System.Collections.Generic;
using System.Text;
using Insurance.Core.Abstraction;
using Insurance.Core.Implementation;

namespace Insurance.Core
{
    public class ProductRuleBuilder: IProductRuleBuilder
    {
        private readonly List<IProductInsurance> _insuranceCalculates;
        public ProductRuleBuilder()
        {
            _insuranceCalculates = new List<IProductInsurance>();
        }
        public void InsuranceValueRules()
        {
            _insuranceCalculates.Add(new ProductLessThan500());
            _insuranceCalculates.Add(new ProductBetween500To2000());
            
        }

        public List<IProductInsurance> GetInsuranceValueRules()
        {
            return _insuranceCalculates;
        }
    }
}

using Insurance.Core.Abstraction;
using Insurance.Core.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Core
{
    public class OrderRuleBuilder : IOrderRuleBuilder
    {
        private readonly List<IOrderInsurance> _insuranceCalculateOrders;
        public OrderRuleBuilder()
        {
            _insuranceCalculateOrders = new List<IOrderInsurance>();
        }
        public List<IOrderInsurance> GetOrderBusinessRules()
        {
            return _insuranceCalculateOrders;
        }

        public void RegisterOrderBusinessRules()
        {
            _insuranceCalculateOrders.Add(new OrderHasDigiCam());
        }
    }
}

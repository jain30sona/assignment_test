using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Core.Abstraction
{
    public interface IOrderRuleBuilder
    {
        void RegisterOrderBusinessRules();

        List<IOrderInsurance> GetOrderBusinessRules();
    }
}

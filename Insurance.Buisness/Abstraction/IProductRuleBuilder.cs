using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Core.Abstraction
{
    public interface IProductRuleBuilder
    {
        void InsuranceValueRules();

        List<IProductInsurance> GetInsuranceValueRules();

    }
}

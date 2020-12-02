using System;
using System.Collections.Generic;
using System.Text;
using Insurance.Core.Abstraction;
using Insurance.Core.Dto;

namespace Insurance.Core.Implementation
{
    public class ProductLessThan500 : IProductInsurance
    {
        public float CalculateInsurance(InsuranceDto insuranceDto)
        {
            if (insuranceDto.ProductTypeHasInsurance)
                if (insuranceDto.SalesPrice < 500)
                    insuranceDto.InsuranceValue = 0;
            return insuranceDto.InsuranceValue;
        }
    }
}

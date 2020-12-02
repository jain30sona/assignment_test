using System;
using System.Collections.Generic;
using System.Text;
using Insurance.Core.Abstraction;
using Insurance.Core.Dto;

namespace Insurance.Core.Implementation
{
    public class ProductBetween500To2000 : IProductInsurance
    {
        public float CalculateInsurance(InsuranceDto insuranceDto)
        {
            if (insuranceDto.SalesPrice > 500 && insuranceDto.SalesPrice < 2000)
                        if (insuranceDto.ProductTypeHasInsurance)
                            insuranceDto.InsuranceValue += 1000;
                return insuranceDto.InsuranceValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Insurance.Core.Abstraction;
using Insurance.Core.Dto;

namespace Insurance.Core.Implementation
{
    class ProductMoreThan2000 : IProductInsurance
    {
        public float CalculateInsurance(InsuranceDto insuranceDto)
        {
            throw new NotImplementedException();
        }
    }
}

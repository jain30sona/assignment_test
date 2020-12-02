using System;
using System.Collections.Generic;
using System.Text;
using Insurance.Core.Dto;

namespace Insurance.Core.Abstraction
{
    public interface IProductInsurance
    {
        float CalculateInsurance(InsuranceDto insuranceDto);
    }
}

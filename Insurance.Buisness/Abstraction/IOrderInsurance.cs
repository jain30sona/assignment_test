using Insurance.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Core.Abstraction
{
    public interface IOrderInsurance
    {
        float CalculateInsurance(List<InsuranceDto> insuranceDto);
    }
}

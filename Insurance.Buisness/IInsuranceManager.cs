using System.Collections.Generic;
using Insurance.Core.Dto;

namespace Insurance.Core
{
    public interface IInsuranceManager
    {
        OrderDto AddInsuranceDetailByProductId(List<int> productId);
    }
}
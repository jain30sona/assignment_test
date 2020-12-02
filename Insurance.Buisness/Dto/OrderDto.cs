using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Core.Dto
{
    public class OrderDto
    {
        public List<InsuranceDto> insuranceDtos { get; set; }

        public float TotalOrderInsuranceCost { get; set; }
    }
}

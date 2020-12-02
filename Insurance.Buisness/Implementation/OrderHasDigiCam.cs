using System;
using System.Collections.Generic;
using System.Text;
using Insurance.Core.Abstraction;
using Insurance.Core.Dto;

namespace Insurance.Core.Implementation
{
    public class OrderHasDigiCam : IOrderInsurance
    {
        public float CalculateInsurance(List<InsuranceDto> insurances)
        {
            float additionalInsuranceCost=0; bool hasDigiCam = false; ;
            if (!hasDigiCam)
            {
                foreach (var item in insurances)
                {
                    if (item.ProductTypeName == "Digital cameras")
                    {
                        hasDigiCam = true;
                        additionalInsuranceCost = 500;
                    }
                }
            }
            return additionalInsuranceCost;
        }      
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class PackagingAndDelivery : IPackagingAndDelivery
    {
        public async Task<ProcessResponse> GetPackagingDeliveryCharge(DefectiveComponentDetail defectiveComponentDetail)
        {
            IDictionary<string, int> packagingItems = new Dictionary<string, int>();
            packagingItems.Add("Integral", 100);
            packagingItems.Add("Accessory", 50);
            packagingItems.Add("ProtectiveSheath", 50);
            
            IDictionary<string, int> deliveryCharge = new Dictionary<string, int>();
            deliveryCharge.Add("Integral",200);
            deliveryCharge.Add("Accessory",100);
            
            IDictionary<string, int> processingCharge = new Dictionary<string, int>();
            processingCharge.Add("Integral",500);
            processingCharge.Add("Accessory",300);
            
            ProcessResponse processResponse = new ProcessResponse();
            
            if (defectiveComponentDetail != null)
            {
                if (defectiveComponentDetail.ComponentType == "Integral")
                {
                    processResponse.PackagingAndDeliveryCharge =
                        (packagingItems["Integral"] + deliveryCharge["Integral"]) * defectiveComponentDetail
                        .Quantity;

                    processResponse.ProcessingCharge = processingCharge["Integral"];
                    processResponse.DateOfDelivery = DateTime.Now.AddDays(5);
                }
                else
                {
                    processResponse.PackagingAndDeliveryCharge =
                        (packagingItems["Accessory"] + deliveryCharge["Accessory"])* defectiveComponentDetail.Quantity;

                    processResponse.ProcessingCharge = processingCharge["Accessory"]; 
                    processResponse.DateOfDelivery = DateTime.Now.AddDays(2);
                }
            }

            return processResponse;
        }
    }
}
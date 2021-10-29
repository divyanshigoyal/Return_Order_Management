using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProcessResponse : BaseEntity
    {
        public decimal ProcessingCharge { get; set; }
        public decimal PackagingAndDeliveryCharge { get; set; }
        public DateTime DateOfDelivery { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.DTOs
{
    public class ProcessRequestToReturnDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ContactNumber { get; set; }
        public string ComponentType { get; set; }
        public string ComponentName { get; set; }
        public int Quantity { get; set; }
    }
}
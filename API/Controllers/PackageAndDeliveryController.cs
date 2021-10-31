using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PackageAndDeliveryController : BaseApiController
    {
        private readonly IProcessRequestRepository _repo;
        public PackageAndDeliveryController(IProcessRequestRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<decimal> GetPackagingDeliveryCharge(int componentTypeId){
            var processRequests = await _repo.GetProcessRequestsAsync();
            return 179;
        }
    }
}
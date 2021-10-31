using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProcessRequestController : BaseApiController
    {
        private readonly IProcessRequestRepository _repo;
        public ProcessRequestController(IProcessRequestRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]

        public async Task<ActionResult<ProcessRequest>> AddProcessRequest(ProcessRequest processRequest){

            await _repo.AddProcessRequest(processRequest);
            return processRequest;
        }        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IGenericRepository<ProcessRequest> _requestRepo;
        private readonly IGenericRepository<ProcessResponse> _responseRepo;

        public AdminController(IGenericRepository<ProcessRequest> requestRepo,
         IGenericRepository<ProcessResponse> responseRepo)
        {
            _responseRepo = responseRepo;
            _requestRepo = requestRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProcessRequest>>> GetAllProcessRequests(){
            var spec = new ProcessRequestWithDefectiveComponentDetail();
            var processRequests = await _requestRepo.ListAsync(spec);
            return Ok(processRequests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProcessRequest>> GetProcessRequest(int id){
            var spec = new ProcessRequestWithDefectiveComponentDetail(id);
            var processRequest = await _requestRepo.GetEntityWithSpec(spec);
            return processRequest;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IProcessRequestRepository _repo;
        public AdminController(IProcessRequestRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProcessRequest>>> GetAllProcessRequests(){
            var processRequests = await _repo.GetProcessRequestsAsync();
            return Ok(processRequests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProcessRequest>> GetProcessRequest(int id){
            var processRequest = await _repo.GetProcessRequestByIdAsync(id);
            return processRequest;
        }
    }
}
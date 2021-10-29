using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly RomDbContext _context;
        public AdminController(RomDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProcessRequest>>> GetAllProcessRequests(){
            var processRequests = await _context.ProcessRequests.ToListAsync();
            return processRequests;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProcessRequest>> GetProcessRequest(int id){
            var processRequest = await _context.ProcessRequests.FindAsync(id);
            return processRequest;
        }
    }
}
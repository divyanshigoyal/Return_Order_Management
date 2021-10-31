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
using API.DTOs;

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
        public async Task<ActionResult<IReadOnlyList<ProcessRequestToReturnDto>>> GetAllProcessRequests(){
            var spec = new ProcessRequestWithDefectiveComponentDetail();
            var processRequests = await _requestRepo.ListAsync(spec);
            return processRequests.Select(Request => new ProcessRequestToReturnDto{
                Id = Request.id,
                UserName = Request.UserName,
                ContactNumber = Request.ContactNumber,
                ComponentType = Request.ComponentDetail.ComponentType,
                ComponentName = Request.ComponentDetail.ComponentName,
                Quantity = (int)Request.ComponentDetail.Quantity
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProcessRequestToReturnDto>> GetProcessRequest(int id){
            var spec = new ProcessRequestWithDefectiveComponentDetail(id);
            var processRequest = await _requestRepo.GetEntityWithSpec(spec);
            return new ProcessRequestToReturnDto{
                Id = processRequest.id,
                UserName = processRequest.UserName,
                ContactNumber = processRequest.ContactNumber,
                ComponentType = processRequest.ComponentDetail.ComponentType,
                ComponentName = processRequest.ComponentDetail.ComponentName,
                Quantity = (int)processRequest.ComponentDetail.Quantity
            };
        }
    }
}
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
using AutoMapper;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IGenericRepository<ProcessRequest> _requestRepo;
        private readonly IGenericRepository<ProcessResponse> _responseRepo;
        private readonly IMapper _mapper;

        public AdminController(IGenericRepository<ProcessRequest> requestRepo,
         IGenericRepository<ProcessResponse> responseRepo, IMapper mapper)
        {
            _mapper = mapper;
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
            return _mapper.Map<ProcessRequest, ProcessRequestToReturnDto>(processRequest);
            
        }
    }
}
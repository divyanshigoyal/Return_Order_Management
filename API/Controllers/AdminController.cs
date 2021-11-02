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
using API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class AdminController : BaseApiController
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
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProcessRequestToReturnDto>>> GetAllProcessRequests(){
            var spec = new ProcessRequestWithDefectiveComponentDetail();
            var processRequests = await _requestRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<ProcessRequest>, IReadOnlyList<ProcessRequestToReturnDto>>(processRequests));
        }
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse) ,StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProcessRequestToReturnDto>> GetProcessRequest(int id){
            var spec = new ProcessRequestWithDefectiveComponentDetail(id);
            var processRequest = await _requestRepo.GetEntityWithSpec(spec);
            if(processRequest == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<ProcessRequest, ProcessRequestToReturnDto>(processRequest);
            
        }
    }
}
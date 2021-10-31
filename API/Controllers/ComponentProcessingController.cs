using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentProcessingController : ControllerBase
    {
        private readonly IProcessRequestRepository _repo;
        public ComponentProcessingController(IProcessRequestRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ProcessResponse> ProcessDetail(ProcessRequest processRequest){
            return await _repo.ProcessDetail(processRequest);
        }

        [HttpPost]
        public string CompleteProcessing(Billing billing){
            return "Completed!";
        }
    }
}
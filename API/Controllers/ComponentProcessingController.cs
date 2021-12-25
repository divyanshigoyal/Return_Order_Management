using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ComponentProcessingController : BaseApiController
    {
        private readonly IProcessRequestRepository _repo;
        public ComponentProcessingController(IProcessRequestRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult<ProcessResponse>> ProcessDetail([FromBody]ProcessRequest processRequest){
            return await _repo.ProcessDetail(processRequest);
        }

        // [HttpPost]
        // public string CompleteProcessing(Billing billing){
        //     return "Completed!";
        // }
    }
}
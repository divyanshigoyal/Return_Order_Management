using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentProcessingController : ControllerBase
    {
        private readonly RomDbContext _context;
        public ComponentProcessingController(RomDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public string ProcessDeatil(){
            return "ProcessDeatil() called";
        }

        [HttpPost]
        public string CompleteProcessing(){
            return "CompleteProcessing() called";
        }
    }
}
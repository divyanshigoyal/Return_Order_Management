using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProcessRequestReporsitory : IProcessRequestRepository
    {
        private readonly RomDbContext _context;
        public ProcessRequestReporsitory(RomDbContext context)
        {
            _context = context;
        }

        public async Task<ProcessRequest> AddProcessRequest(ProcessRequest processRequest)
        {
            
            await _context.ProcessRequests.AddAsync(processRequest);
            await _context.DefectiveComponentDetails.AddRangeAsync(processRequest.ComponentDetail);
            await _context.SaveChangesAsync();
            return processRequest;
        }

        public async Task<ProcessRequest> GetProcessRequestByIdAsync(int id)
        {
            return await _context.ProcessRequests
            .Include(p => p.ComponentDetail) //eager loading of nav property 
            .FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<IReadOnlyList<ProcessRequest>> GetProcessRequestsAsync()
        {
            return await _context.ProcessRequests
            .Include(p => p.ComponentDetail) //eager loading of nav property 
            .ToListAsync();
        }

        public async Task<ProcessResponse> ProcessDetail(ProcessRequest processRequest)
        {
            await _context.ProcessRequests.AddAsync(processRequest);
            var processResponse = new ProcessResponse();
            processResponse.PackagingAndDeliveryCharge = 100;
            processResponse.DateOfDelivery = DateTime.UtcNow;
            processResponse.ProcessingCharge = 200;
            await _context.ProcessResponse.AddAsync(processResponse);
            return processResponse;

        }

        public string CompleteProcessing(Billing billing)
        {
            
            return "Completed Billing Process";

        }
    }
}
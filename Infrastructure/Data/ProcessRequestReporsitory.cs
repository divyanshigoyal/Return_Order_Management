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

        public async Task<ProcessRequest> GetProcessRequestByIdAsync(int id)
        {
            return await _context.ProcessRequests
            .Include(p => p.ComponentDetail)
            .FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<IReadOnlyList<ProcessRequest>> GetProcessRequestsAsync()
        {
            return await _context.ProcessRequests
            .Include(p => p.ComponentDetail)
            .ToListAsync();
        }
    }
}
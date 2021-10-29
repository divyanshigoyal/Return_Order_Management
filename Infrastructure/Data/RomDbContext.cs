using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class RomDbContext : DbContext
    {
        public RomDbContext(DbContextOptions<RomDbContext> options) : base(options)
        {
        }

        public DbSet<ProcessRequest> ProcessRequests { get; set; }
    }
}
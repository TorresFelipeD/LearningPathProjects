using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_NetCore.Models;

namespace API_NetCore.Data
{
    public class API_NetCoreContext : DbContext
    {
        public API_NetCoreContext (DbContextOptions<API_NetCoreContext> options) : base(options)
        {
        }

        public DbSet<API_NetCore.Models.Book> Book { get; set; }
    }
}

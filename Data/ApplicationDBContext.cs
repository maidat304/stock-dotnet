using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace api_dotnet.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Stock> Stock { get; set; }

        public DbSet<Comment> Comments { get; set; }

    }
}
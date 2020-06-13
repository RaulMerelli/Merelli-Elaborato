using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imgAPI.Models
{
    public class PCXcontainerContext : DbContext
    {
        public PCXcontainerContext(DbContextOptions<PCXcontainerContext> options)
            : base(options)
        {
        }

        public DbSet<PCXcontainer> PCXcontainers { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imgAPI.Models
{
    public class TGAcontainerContext : DbContext
    {
        public TGAcontainerContext(DbContextOptions<TGAcontainerContext> options)
            : base(options)
        {
        }

        public DbSet<TGAcontainer> TGAcontainers { get; set; }
    }
}

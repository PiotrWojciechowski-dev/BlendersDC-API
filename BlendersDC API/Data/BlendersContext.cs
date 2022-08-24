using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlendersDC_API.Models;

namespace BlendersDC_API.Data
{
    public class BlendersContext : DbContext
    {
        public BlendersContext(DbContextOptions<BlendersContext> options) : base(options) { }

        public DbSet<Oil> Oils { get; set; }
        public DbSet<Egg> Eggs { get; set; }
    }
}

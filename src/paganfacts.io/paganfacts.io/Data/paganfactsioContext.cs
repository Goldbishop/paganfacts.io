using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace paganfacts.io.Models
{
    public class paganfactsioContext : DbContext
    {
        public paganfactsioContext (DbContextOptions<paganfactsioContext> options)
            : base(options)
        {
        }

        public DbSet<paganfacts.io.Models.Deities> Deities { get; set; }
    }
}

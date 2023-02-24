using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stories.Models;

namespace Stories.Data
{
    public class StoriesContext : DbContext
    {
        public StoriesContext (DbContextOptions<StoriesContext> options)
            : base(options)
        {
        }

        public DbSet<Stories.Models.StoriesTable> StoriesTable { get; set; } = default!;
    }
}

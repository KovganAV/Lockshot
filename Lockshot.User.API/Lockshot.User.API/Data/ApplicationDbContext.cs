using Lockshot.User.API.Class;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lockshot.User.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Lockshot.User.API.Class.User> Users { get; set; }

        public DbSet<Hit> Hits { get; set; }

        public DbSet<Gun> Guns { get; set; }
    }
}

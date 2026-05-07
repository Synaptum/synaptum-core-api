using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Synaptum.Core.Domain.Entities;

namespace Synaptum.Core.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
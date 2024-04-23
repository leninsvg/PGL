using Microsoft.EntityFrameworkCore;
using PGL.Persistence.Entities;

namespace PGL.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<PersonEntity> People { get; set; }
}
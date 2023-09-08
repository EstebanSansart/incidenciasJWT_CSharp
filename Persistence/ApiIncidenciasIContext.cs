using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class ApiIncidenciasIContext : DbContext
{
    public ApiIncidenciasIContext(DbContextOptions<ApiIncidenciasIContext> options) : base(options)
    {
    }
    public DbSet<Area> Areas { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ContactCategory> ContactCategories { get; set; }
    public DbSet<ContactType> ContactTypes { get; set; }
    public DbSet<DocType> DocTypes { get; set; }
    public DbSet<Incidence> Incidences { get; set; }
    public DbSet<IncidenceDetail> IncidenceDetails { get; set; }
    public DbSet<IncidenceLevel> IncidenceLevels { get; set; }
    public DbSet<IncidenceType> IncidenceTypes { get; set; }
    public DbSet<Place> Places { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<UserArea> UserAreas { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<WorkTool> WorkTools { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserArea>().HasKey(r => new{r.IdUserFk, r.IdAreaFk});
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
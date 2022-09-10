using KodlamaIO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KodlamaIO.Persistence.Context;

public class BaseDbContext : DbContext
{
    public IConfiguration Configuration { get; set; }
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProgrammingLanguage>(p =>
        {
            p.ToTable("ProgrammingLanguage").HasKey(k => k.Id);
            p.Property(p => p.Id).HasColumnName("Id");
            p.Property(p => p.Name).HasColumnName("Name");
        });

        ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C#"), new(2, "Java"), new(3, "Php"), };
        modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);
    }
}
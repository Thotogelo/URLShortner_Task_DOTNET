using Microsoft.EntityFrameworkCore;
using URL_Shortner_Task.Model;

namespace URL_Shortner_Task.Data;

public class DataContext : DbContext
{
    public DbSet<Url> Urls { get; set; }

    protected DataContext()
    {
    }

    protected DataContext(DbSet<Url> urls)
    {
        Urls = urls;
    }

    public DataContext(DbContextOptions options, DbSet<Url> urls) : base(options)
    {
        Urls = urls;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder.UseNpgsql("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder.Entity<Url>(entity =>
        {
            entity.ToTable("urls").HasKey("Id").HasName("Id");

            entity.Property(e => e.OriginalUrl);

            entity.Property(e => e.ShortUrl);

            entity.Property(e => e.Clicked);
        }));
    }
}
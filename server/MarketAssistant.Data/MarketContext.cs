using MarketAssistant.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace MarketAssistant.Data;

public class MarketContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();

    public DbSet<Author> Authors => Set<Author>();

    public DbSet<Event> Events => Set<Event>();

    public DbSet<EventType> EventTypes => Set<EventType>();

    public DbSet<Format> Formats => Set<Format>();

    public DbSet<Marketer> Marketers => Set<Marketer>();

    public DbSet<MarketerAssignment> MarketerAssignments => Set<MarketerAssignment>();

    public DbSet<MarketMaterial> MarketMaterials => Set<MarketMaterial>();

    public DbSet<MarketMaterialType> MarketMaterialTypes => Set<MarketMaterialType>();

    public MarketContext(DbContextOptions<MarketContext> options)
    : base(options)
    {
    }
}

using Microsoft.EntityFrameworkCore;

namespace Athena.Models;

class AthenaDb : DbContext
{
    public AthenaDb(DbContextOptions options) : base(options) { }
    public DbSet<Archive> Archives { get; set; } = null!;
    public DbSet<ArchiveTask> ArchiveTasks { get; set; } = null!;
}

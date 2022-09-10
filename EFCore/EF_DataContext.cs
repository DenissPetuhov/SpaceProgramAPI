using Microsoft.EntityFrameworkCore;

namespace SpaceProgram.EFCore
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options): base(options)
        {

        }
      
        public DbSet<SpaceObject> SpaceObjects { get; set; }
        public DbSet<SpaceSystem> SpaceSystems { get; set; }

    }
}

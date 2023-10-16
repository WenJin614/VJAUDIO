using Microsoft.EntityFrameworkCore;
using VJAUDIO.Models;

namespace VJAUDIO
{
    public partial class MariaDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public MariaDbContext(DbContextOptions<MariaDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<HeadsetColor> HeadsetColor { get; set; }
    }
}

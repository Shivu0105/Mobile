using Ef_3.Model;
using Microsoft.EntityFrameworkCore;

namespace Ef_3.Repository
{
    public class MobileDB : DbContext
    {
        public MobileDB(DbContextOptions<MobileDB> options) : base(options)
        {

        }

        public DbSet<Mobiles> MobilesTable { get; set; }
    }
}

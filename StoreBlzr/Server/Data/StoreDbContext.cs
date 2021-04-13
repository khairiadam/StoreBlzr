using Microsoft.EntityFrameworkCore;

namespace Server.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }
    }
}
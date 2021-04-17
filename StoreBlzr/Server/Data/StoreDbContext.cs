using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shared;

namespace StoreBlzr.Server.Data
{
    public class StoreDbContext : ApiAuthorizationDbContext<AppClient>
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Images> Images { get; set; }

        // public virtual DbSet<Category> Categories { get; set; }
        public StoreDbContext(DbContextOptions<StoreDbContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }
    }
}
using Ambrosia.Data.Concrete.EntityFramework.Mappings;
using Ambrosia.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ambrosia.Data.Concrete.EntityFramework.Context
{
    public class AmbrosiaContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbSet<Basket> Basket { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Log> Logs { get; set; }
        
        public AmbrosiaContext(DbContextOptions<AmbrosiaContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BasketMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new CommentMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new LogMap());
            builder.ApplyConfiguration(new RoleClaimMap());
            builder.ApplyConfiguration(new RoleMap());
            builder.ApplyConfiguration(new UserClaimMap());
            builder.ApplyConfiguration(new UserLoginMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new UserRoleMap());
            builder.ApplyConfiguration(new UserTokenMap());
        }
    }
}

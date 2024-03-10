using Microsoft.EntityFrameworkCore;
using crud.Models;

namespace crud.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> User { get; set; } = default!;
    }
}

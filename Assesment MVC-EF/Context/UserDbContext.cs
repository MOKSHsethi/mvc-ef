using Assesment_MVC_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Assesment_MVC_EF.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext() { }

       public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Batch> Batches { get; set; }

        public DbSet<LoginViewModel> LoginViewModel { get; set; }

        public DbSet<Request> Request { get; set; }
    }
}

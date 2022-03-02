using Microsoft.EntityFrameworkCore;
using StatesTest.Data.Models;

namespace StatesTest.Data
{
    public class StatesTestDbContext : DbContext
    {

        public StatesTestDbContext(DbContextOptions<StatesTestDbContext> options)
        : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<StateEntity> State { get; set; }
        public DbSet<TestResult> TestResult { get; set; }
    }
}

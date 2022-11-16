using Microsoft.EntityFrameworkCore;
using project_management_api.Models;

namespace project_management_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }

        public DbSet<Issue> Issues { get; set; }
        public DbSet<User> Users { get; set; }

    }
}

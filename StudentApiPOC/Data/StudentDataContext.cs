using Microsoft.EntityFrameworkCore;
using StudentApiPOC.Model;
using StudentApiPOC.ModelConfiguration;

namespace StudentApiPOC.Data
{
    public class StudentDataContext : DbContext
    {

        public StudentDataContext(DbContextOptions options) : base(options)
        {
          
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfigcs());
        }
        public DbSet<Student> Students { get; set; }

    }

}

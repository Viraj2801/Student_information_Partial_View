using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NewForPartialView.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Stud> Studs { get; set; }
        public DbSet<ApplicationUser>ApplicationUsers { get; set; }
        public List<StudentImage> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Stud>()
                .HasMany(s => s.ImageUrl)
                .WithOne(i => i.Student)
                .HasForeignKey(i => i.StudentId);
        }

        internal void Save()
        {
            throw new NotImplementedException();
        }
    }
}

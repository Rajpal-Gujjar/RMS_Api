using Microsoft.EntityFrameworkCore;
using RMSApi.Data.Models;

namespace RMSApi.Data.Context
{
    public class RMSDbContext : DbContext
    {
        public RMSDbContext(DbContextOptions<RMSDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<JobApplied> JobApplied { get; set; }
        public DbSet<JobPost> JobPost { get; set; }
        public DbSet<JobSeeker> JobSeeker { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Name).HasMaxLength(50);
                x.Property(x => x.HRContact).HasMaxLength(10);
                x.Property(x => x.Location).HasMaxLength(50);
            });

            modelBuilder.Entity<JobApplied>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasOne(x => x.JobSeeker);
                x.HasOne(x => x.JobPost);
            });

            modelBuilder.Entity<JobPost>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.NoOfPosts).HasMaxLength(1000);
                x.Property(x => x.Salary).HasMaxLength(500000);
                x.Property(x => x.IsDeleted);
                x.Property(x => x.Category).HasMaxLength(20);
                x.Property(x => x.Experience).HasMaxLength(5);
                x.Property(x => x.Location).HasMaxLength(50);
                x.Property(x => x.Qualification).HasMaxLength(20);
                x.HasOne(x => x.Company);
                x.Property(x => x.RequiredDate);
                x.Property(x => x.CreatedDate);
                x.Property(x => x.ModifyDate);
                x.Property(x => x.DeletedDate);
            });

            modelBuilder.Entity<JobSeeker>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.State).HasMaxLength(50);
                x.Property(x => x.City).HasMaxLength(50);
                x.Property(x => x.PassingYear).HasMaxLength(2024);
                x.Property(x => x.Password).HasMaxLength(50);
                x.Property(x => x.ConfirmPassword).HasMaxLength(50);
                x.Property(x => x.Phone).HasMaxLength(10);
                x.Property(x => x.Category).HasMaxLength(20);
                x.Property(x => x.DateOfBirth);
                x.Property(x => x.CreatedDate);
                x.Property(x => x.Email).HasMaxLength(50);
                x.Property(x => x.Gender).HasMaxLength(6);
                x.Property(x => x.Language).HasMaxLength(20);
                x.Property(x => x.Name).HasMaxLength(20);
                x.Property(x => x.ModifyDate);
                x.Property(x => x.Exprience).HasMaxLength(5);
                x.Property(x => x.Qualification).HasMaxLength(20);
            });

            List<Company> companies = new()
            {
                new Company() { Id=1, Name = "Step2gen", HRContact = 9998887776, Location = "Mohali" },
                new Company() { Id=2,Name = "Infosys", HRContact = 9988857776, Location = "Chandigarh" },
                new Company() { Id=3,Name = "HCL", HRContact = 9398887776, Location = "Delhi" },
                new Company() { Id=4,Name = "Airtel", HRContact = 9993287776, Location = "Mumbai" },
                new Company() { Id=5,Name = "Reebok", HRContact = 9998854776, Location = "Pune" }
            };

            modelBuilder.Entity<Company>().HasData(companies);
        }
    }
}

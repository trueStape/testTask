using DAL.Entities.Entities;
using Microsoft.EntityFrameworkCore;


namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
            
        }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<UserInformationEntity> UserInformation { get; set; }
        public DbSet<DepartmentEntity> Department { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserInformationEntity>()
                .HasOne(x => x.Department)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.DepartmentId);


            modelBuilder.Entity<UserEntity>()
                .HasOne(x => x.UserInformation)
                .WithOne(x => x.User)
                .HasForeignKey<UserInformationEntity>(x => x.UserId);
        }
    }
}
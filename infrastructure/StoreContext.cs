using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<BranchEntity> Branches{ get; set; }
        public DbSet<ProductEntity> Products{ get; set; }
        public DbSet<SizeEntity> Sizes{ get; set; }
        public DbSet<MedicalHouseEntity> MedicalHouses{ get; set; }
        public DbSet<ProductCombinationEntity> ProductCombinations { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<ProfileEntity> Profile { get; set; }
        public DbSet<OperationTypeEntity> OperationType { get; set; }
        public DbSet<ProductMovementEntity> ProductMovement { get; set; }
        public DbSet<SatisfactionSurveyEntity> SatisfactionSurveyEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

﻿using Core.Entities;
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
        public DbSet<SatisfactionSurveyEntity> SatisfactionSurveyEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
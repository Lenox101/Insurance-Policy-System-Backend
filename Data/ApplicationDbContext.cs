using Microsoft.EntityFrameworkCore;
using InsurancePolicyAPI.Models;

namespace InsurancePolicyAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<InsurancePolicy> InsurancePolicies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the InsurancePolicy entity
        modelBuilder.Entity<InsurancePolicy>()
            .Property(p => p.CoverageAmount)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<InsurancePolicy>()
            .Property(p => p.PremiumAmount)
            .HasColumnType("decimal(18,2)");

        // Add some sample data
        modelBuilder.Entity<InsurancePolicy>().HasData(
            new InsurancePolicy
            {
                Id = 1,
                PolicyNumber = "POL-001",
                HolderName = "John Doe",
                PolicyType = "Life",
                CoverageAmount = 100000M,
                PremiumAmount = 150M,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1),
                Status = "Active"
            },
            new InsurancePolicy
            {
                Id = 2,
                PolicyNumber = "POL-002",
                HolderName = "Jane Smith",
                PolicyType = "Health",
                CoverageAmount = 50000M,
                PremiumAmount = 100M,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddYears(1),
                Status = "Active"
            }
        );
    }
} 
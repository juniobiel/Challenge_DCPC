using DCPC.Challenge.Escola.Api.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DCPC.Challenge.Escola.Api.Data;

public class ApplicationIdentityDbContext : IdentityDbContext<AppUser>
{
    public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> dbContextOptions) : base(dbContextOptions) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Seed de roles
        var userRoleId = "8e7d2a8d-6b49-4d1b-8b9d-2a62a8f7f001";
        var adminRoleId = "a4c3f2b1-9d88-4c7e-9f4a-3b2c1d0e0f02";

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = userRoleId,
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = userRoleId
            },
            new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = adminRoleId
            }
        );
    }
}

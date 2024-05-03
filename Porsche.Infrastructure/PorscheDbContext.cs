using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Porsche.Domain.Entities;

namespace Porsche.Infrastructure;
public class PorscheDbContext : IdentityDbContext<UserEntity, RoleEntity, Guid>
{
    public PorscheDbContext(DbContextOptions<PorscheDbContext> options)
        : base(options)
    {
    }

    public DbSet<CarEntity> Cars { get; set; }
    public DbSet<PhotoEntity> CarPhotos { get; set; }
    public DbSet<PorscheCenterEntity> PorscheCenters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<RoleEntity>()
            .HasData(
                new RoleEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new RoleEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = "User",
                    NormalizedName = "USER"
                });

        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.HasMany(u => u.SavedCars)
                .WithMany(c => c.Users)
                .UsingEntity<UserCarEntity>(
                    j => j.HasOne(uc => uc.Car)
                        .WithMany(c => c.UsersCars),
                    j => j.HasOne(uc => uc.User)
                        .WithMany(u => u.UsersCars),
                    j =>
                    {
                        j.HasKey(uc => new { uc.UserId, uc.CarId });
                        j.ToTable("UsersCars");
                    }
                );
        });

        modelBuilder.Entity<CarEntity>()
            .HasMany(c => c.Photos)
            .WithOne(p => p.Car)
            .HasForeignKey(p => p.CarId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PorscheCenterEntity>()
            .HasMany(p => p.Cars)
            .WithOne(c => c.PorscheCenter)
            .HasForeignKey(c => c.PorscheCenterId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
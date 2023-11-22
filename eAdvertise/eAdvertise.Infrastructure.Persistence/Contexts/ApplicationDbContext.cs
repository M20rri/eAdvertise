using eAdvertise.Application.Interfaces;
using eAdvertise.Domain.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System;
using eAdvertise.Domain.Entities;
using eAdvertise.Application.ViewModels.Advertise;

namespace eAdvertise.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        private readonly IDateTimeService _dateTime;
        private readonly ILoggerFactory _loggerFactory;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IDateTimeService dateTime,
            ILoggerFactory loggerFactory
            ) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _loggerFactory = loggerFactory;
        }

        public DbSet<Image> Images { get; set; }
        public DbSet<Advertise> Advertises { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Advertise>().ToTable("Advertises")
              .HasDiscriminator<int>("Discriminator")
              .HasValue<Car>(1)
              .HasValue<Misc>(2)
              .HasValue<Mobile>(3);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            IdentityDataInitializer(builder);
        }

        private void IdentityDataInitializer(ModelBuilder modelBuilder)
        {
            string[] roles = new string[] { "Owner", "Administrator", "Manager" };

            var hasher = new PasswordHasher<ApplicationUser>();

            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "m.eltorri@boutiqaat.com",
                NormalizedEmail = "m.eltorri@boutiqaat.com".ToUpper(),
                UserName = "M2ri",
                NormalizedUserName = "M2ri".ToUpper(),
                PhoneNumber = "01159313034",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
            };

            user.UltraData("Mahmoud", "El Torri", true);

            modelBuilder.Entity<ApplicationUser>().HasData(user);


            foreach (string role in roles)
            {
                string RoleId = Guid.NewGuid().ToString();

                modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = RoleId, Name = role, NormalizedName = role.ToUpper() });

                modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = RoleId,
                        UserId = user.Id
                    }
                );
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
    }
}
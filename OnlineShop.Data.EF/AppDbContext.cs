using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using OnlineShop.Data.EF.Configurations;
using OnlineShop.Data.EF.Extensions;
using OnlineShop.Data.Entities;
using OnlineShop.Data.Interfaces;
using System.IO;

namespace OnlineShop.Data.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Indentity config

            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(n => n.Id);

            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(n => n.Id);

            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(n=>n.UserId);

            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(n => new {n.UserId, n.RoleId});

            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserToken").HasKey(n => n.UserId);

            #endregion

            builder.AddConfiguration(new AdvertistmentPositionConfiguration());
            builder.AddConfiguration(new BlogTagConfiguration());
            builder.AddConfiguration(new ContactDetailConfiguration());
            builder.AddConfiguration(new FooterConfiguration());
            builder.AddConfiguration(new FunctionConfiguration());
            builder.AddConfiguration(new PageConfiguration());
            builder.AddConfiguration(new ProductTagConfiguration());
            builder.AddConfiguration(new SystemConfigConfiguration());
            builder.AddConfiguration(new TagConfiguration());

            OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries()
                .Where(n => n.State == EntityState.Added || n.State == EntityState.Modified);
            foreach (var entity in modified)
            {
                var changeOrUpdate = entity as IDateTracking;
                if (changeOrUpdate != null)
                {
                    DateTime now = DateTime.Now;
                    if (entity.State == EntityState.Modified)
                        changeOrUpdate.DateModified = now;
                    if (entity.State == EntityState.Added)
                        changeOrUpdate.DateCreated = now;
                }
            }
            return base.SaveChanges();
        }

        public DbSet<Language> Languages { set; get; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Function> Functions { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Announcement> Announcements { set; get; }
        public DbSet<AnnouncementUser> AnnouncementUsers { set; get; }

        public DbSet<Blog> Bills { set; get; }
        public DbSet<BillDetail> BillDetails { set; get; }
        public DbSet<Blog> Blogs { set; get; }
        public DbSet<BlogTag> BlogTags { set; get; }
        public DbSet<Color> Colors { set; get; }
        public DbSet<Contact> Contacts { set; get; }
        public DbSet<Feedback> Feedbacks { set; get; }
        public DbSet<Footer> Footers { set; get; }
        public DbSet<Page> Pages { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<ProductImage> ProductImages { set; get; }
        public DbSet<ProductQuantity> ProductQuantities { set; get; }
        public DbSet<ProductTag> ProductTags { set; get; }

        public DbSet<Size> Sizes { set; get; }
        public DbSet<Slide> Slides { set; get; }

        public DbSet<Tag> Tags { set; get; }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<WholePrice> WholePrices { get; set; }

        public DbSet<AdvertistmentPage> AdvertistmentPages { get; set; }
        public DbSet<Advertistment> Advertistments { get; set; }
        public DbSet<AdvertistmentPosition> AdvertistmentPositions { get; set; }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new AppDbContext(builder.Options);
        }
    }
}
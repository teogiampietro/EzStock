using EzStock.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EzStock.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //
        //    string ADMIN_ID = "cac43a6e-f7bb-4448-baaf-1add431ccbbf";
        //    string ROLE_ID = "b8633e2d-a33b-45e6-8329-1958b3252bbd";
        //
        //    //seed admin role
        //    builder.Entity<IdentityRole>().HasData(new IdentityRole
        //    {
        //        Name = "SuperAdmin",
        //        NormalizedName = "SuperAdmin".ToUpper(),
        //        Id = ROLE_ID,
        //        ConcurrencyStamp = ROLE_ID
        //    });
        //
        //    //create user
        //    var appUser = new IdentityUser
        //    {
        //        Id = ADMIN_ID,
        //        Email = "superAdmin@gmail.com",
        //        EmailConfirmed = true,
        //        UserName = "admin",
        //        NormalizedUserName = "admin".ToUpper()
        //    };
        //
        //    //set user password
        //    PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
        //    appUser.PasswordHash = ph.HashPassword(appUser, "asdqwe123");
        //
        //    //seed user
        //    builder.Entity<IdentityUser>().HasData(appUser);
        //
        //    //set user role to admin
        //    builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        //    {
        //        RoleId = ROLE_ID,
        //        UserId = ADMIN_ID
        //    });
        //}
    }
}

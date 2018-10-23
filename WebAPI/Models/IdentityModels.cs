using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebAPI.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class ApplicationDBContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //AspNetUsers to Users
            modelBuilder.Entity<ApplicationUser>().ToTable("User");

            //IdentityRole to Role
            modelBuilder.Entity<IdentityRole>().ToTable("Role");

            //IdentityUserRole to UserRole
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");

            //IdentityUserClaim to UserClaims
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");

            //IdentityUserLogin to UserLogin
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
        }

    }
}
using FinalProjectDB.Models;
using FinalProjectModels.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectModels.Models
{
    public class FinalProjectEntity : IdentityDbContext<WebUsers>
    {
        public virtual DbSet<البضاعه> البضاعه { get; set; }
        public virtual DbSet<الحسابات> الحسابات { get; set; }
        public virtual DbSet<الخزنه> الخزنه { get; set; }
        public virtual DbSet<الفواتير> الفواتير { get; set; }
        public virtual DbSet<الحركة> الحركة { get; set; }

        public FinalProjectEntity()
        {

        }

        public FinalProjectEntity(DbContextOptions<FinalProjectEntity> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string ADMIN_ID = "9ca51c3e-25d3-4c68-aa9a-705dc1484108";
            string ROLE_ID = "18725df9-46e2-4376-876c-63057dfc5f3c";

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });


            var webUser = new WebUsers
            {
                Id = ADMIN_ID,
                FirstName = "Ahmed",
                LastName = "Mokhtar",
                Email = "ahmed@gmail.com",
                NormalizedEmail = "AHMED@GMAIL.COM",
                UserName = "ahmed@gmail.com",
                NormalizedUserName = "AHMED@GMAIL.COM",
                PhoneNumber = "01065086511"
            };

            PasswordHasher<WebUsers> ph = new PasswordHasher<WebUsers>();
            webUser.PasswordHash = ph.HashPassword(webUser, "246810Rr#");

            builder.Entity<WebUsers>().HasData(webUser);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }

    }
}

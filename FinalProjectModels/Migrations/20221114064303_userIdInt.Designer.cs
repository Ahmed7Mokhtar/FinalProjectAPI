// <auto-generated />
using System;
using FinalProjectModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalProjectModels.Migrations
{
    [DbContext(typeof(FinalProjectEntity))]
    [Migration("20221114064303_userIdInt")]
    partial class userIdInt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FinalProjectDB.Models.البضاعه", b =>
                {
                    b.Property<int>("رقم_الصنف")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("رقم_الصنف"), 1L, 1);

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("اجمالي_الكميه")
                        .HasColumnType("int");

                    b.Property<string>("اسم_الصنف")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("الوصف")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("سعر_البيع")
                        .HasColumnType("float");

                    b.Property<double>("سعر_الشراء")
                        .HasColumnType("float");

                    b.Property<string>("نوع_الصنف")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("رقم_الصنف");

                    b.ToTable("البضاعه");
                });

            modelBuilder.Entity("FinalProjectDB.Models.الحسابات", b =>
                {
                    b.Property<int>("رقم_الحساب")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("رقم_الحساب"), 1L, 1);

                    b.Property<string>("اسم_الحساب")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("التصنيف")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("التليفون")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("العنوان")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("دائن")
                        .HasColumnType("float");

                    b.Property<string>("طبيعه_الحساب")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("كود_الحساب")
                        .HasColumnType("int");

                    b.Property<double?>("مدين")
                        .HasColumnType("float");

                    b.HasKey("رقم_الحساب");

                    b.ToTable("الحسابات");
                });

            modelBuilder.Entity("FinalProjectDB.Models.الخزنه", b =>
                {
                    b.Property<int>("رقم_المسلسل")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("رقم_المسلسل"), 1L, 1);

                    b.Property<DateTime>("التاريخ")
                        .HasColumnType("datetime2");

                    b.Property<string>("الحركه")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("الحساب")
                        .HasColumnType("float");

                    b.Property<double>("رصيد")
                        .HasColumnType("float");

                    b.Property<double?>("منصرف")
                        .HasColumnType("float");

                    b.Property<double?>("وارد")
                        .HasColumnType("float");

                    b.HasKey("رقم_المسلسل");

                    b.ToTable("الخزنه");
                });

            modelBuilder.Entity("FinalProjectDB.Models.الفواتير", b =>
                {
                    b.Property<int>("رقم_الفاتوره")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("رقم_الفاتوره"), 1L, 1);

                    b.Property<DateTime>("التاريخ")
                        .HasColumnType("datetime2");

                    b.Property<string>("الحساب")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("الخصم")
                        .HasColumnType("float");

                    b.Property<int>("الكميه")
                        .HasColumnType("int");

                    b.Property<double>("النهائي")
                        .HasColumnType("float");

                    b.Property<double>("درج_النقديه")
                        .HasColumnType("float");

                    b.Property<int>("رقم_الحركة")
                        .HasColumnType("int");

                    b.Property<string>("طريقه_الحساب")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("رقم_الفاتوره");

                    b.HasIndex("رقم_الحركة");

                    b.ToTable("الفواتير");
                });

            modelBuilder.Entity("FinalProjectModels.Models.WebUsers", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("FinalProjectModels.Models.الحركة", b =>
                {
                    b.Property<int>("رقم_الحركة")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("رقم_الحركة"), 1L, 1);

                    b.Property<double>("المبلغ")
                        .HasColumnType("float");

                    b.Property<DateTime>("تاريخ_الحركة")
                        .HasColumnType("datetime2");

                    b.Property<string>("نوع_الحركة")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("رقم_الحركة");

                    b.ToTable("الحركة");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("البضاعهالفواتير", b =>
                {
                    b.Property<int>("البضاعهرقم_الصنف")
                        .HasColumnType("int");

                    b.Property<int>("الفواتيررقم_الفاتوره")
                        .HasColumnType("int");

                    b.HasKey("البضاعهرقم_الصنف", "الفواتيررقم_الفاتوره");

                    b.HasIndex("الفواتيررقم_الفاتوره");

                    b.ToTable("البضاعهالفواتير");
                });

            modelBuilder.Entity("FinalProjectDB.Models.الفواتير", b =>
                {
                    b.HasOne("FinalProjectModels.Models.الحركة", "حركة")
                        .WithMany()
                        .HasForeignKey("رقم_الحركة")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("حركة");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FinalProjectModels.Models.WebUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FinalProjectModels.Models.WebUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProjectModels.Models.WebUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FinalProjectModels.Models.WebUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("البضاعهالفواتير", b =>
                {
                    b.HasOne("FinalProjectDB.Models.البضاعه", null)
                        .WithMany()
                        .HasForeignKey("البضاعهرقم_الصنف")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProjectDB.Models.الفواتير", null)
                        .WithMany()
                        .HasForeignKey("الفواتيررقم_الفاتوره")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

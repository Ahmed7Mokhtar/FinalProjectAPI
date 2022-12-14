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
    [Migration("20221104032331_AddActions")]
    partial class AddActions
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("التصنيف")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("التليفون")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("العنوان")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("دائن")
                        .HasColumnType("float");

                    b.Property<string>("طبيعه_الحساب")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("كود_الحساب")
                        .HasColumnType("int");

                    b.Property<double>("مدين")
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

                    b.Property<double>("منصرف")
                        .HasColumnType("float");

                    b.Property<double>("وارد")
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

                    b.Property<string>("طريقه_الحساب")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("رقم_الفاتوره");

                    b.ToTable("الفواتير");
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

                    b.Property<int?>("فاتورةرقم_الفاتوره")
                        .HasColumnType("int");

                    b.Property<string>("نوع_الحركة")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("رقم_الحركة");

                    b.HasIndex("فاتورةرقم_الفاتوره");

                    b.ToTable("الحركة");
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

            modelBuilder.Entity("FinalProjectModels.Models.الحركة", b =>
                {
                    b.HasOne("FinalProjectDB.Models.الفواتير", "فاتورة")
                        .WithMany()
                        .HasForeignKey("فاتورةرقم_الفاتوره");

                    b.Navigation("فاتورة");
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

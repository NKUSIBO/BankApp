﻿// <auto-generated />
using System;
using Inocrea.CodaBox.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inocrea.CodaBox.Web.Migrations
{
    [DbContext(typeof(CodaBoxContext))]
    [Migration("20190923125105_IdentitySchema")]
    partial class IdentitySchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Inocrea.CodaBox.ApiModel.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName");

                    b.Property<string>("Tva");

                    b.HasKey("CompanyId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Inocrea.CodaBox.ApiModel.Models.CompteBancaire", b =>
                {
                    b.Property<int>("CompteBancaireId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bic");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("CurrencyCode");

                    b.Property<string>("Iban");

                    b.Property<string>("IdentificationNumber");

                    b.HasKey("CompteBancaireId");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompteBancaire");
                });

            modelBuilder.Entity("Inocrea.CodaBox.ApiModel.Models.SepaDirectDebit", b =>
                {
                    b.Property<int>("SepaDirectDebitId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreditorIdentificationCode");

                    b.Property<string>("MandateReference");

                    b.Property<int>("PaidReason");

                    b.Property<int>("Scheme");

                    b.Property<int>("TransactionId");

                    b.Property<int>("Type");

                    b.HasKey("SepaDirectDebitId");

                    b.HasIndex("TransactionId")
                        .IsUnique();

                    b.ToTable("SepaDirectDebits");
                });

            modelBuilder.Entity("Inocrea.CodaBox.ApiModel.Models.Statements", b =>
                {
                    b.Property<int>("StatementId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompteBancaireId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("InformationalMessage");

                    b.Property<double>("InitialBalance");

                    b.Property<double>("NewBalance");

                    b.HasKey("StatementId");

                    b.HasIndex("CompteBancaireId");

                    b.ToTable("Statements");
                });

            modelBuilder.Entity("Inocrea.CodaBox.ApiModel.Models.Transactions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<int>("CompteBancaireId");

                    b.Property<string>("Message");

                    b.Property<int>("StatementId");

                    b.Property<string>("StructuredMessage");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<DateTime>("ValueDate");

                    b.HasKey("Id");

                    b.HasIndex("CompteBancaireId");

                    b.HasIndex("StatementId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Inocrea.CodaBox.Web.Models.CodaBoxUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("CompanyId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .HasMaxLength(200);

                    b.Property<string>("LastName")
                        .HasMaxLength(250);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Inocrea.CodaBox.ApiModel.Models.CompteBancaire", b =>
                {
                    b.HasOne("Inocrea.CodaBox.ApiModel.Models.Company", "Company")
                        .WithMany("CompteBancaire")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Inocrea.CodaBox.ApiModel.Models.SepaDirectDebit", b =>
                {
                    b.HasOne("Inocrea.CodaBox.ApiModel.Models.Transactions", "Transactions")
                        .WithOne("SepaDirectDebit")
                        .HasForeignKey("Inocrea.CodaBox.ApiModel.Models.SepaDirectDebit", "TransactionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Inocrea.CodaBox.ApiModel.Models.Statements", b =>
                {
                    b.HasOne("Inocrea.CodaBox.ApiModel.Models.CompteBancaire", "CompteBancaire")
                        .WithMany("Statements")
                        .HasForeignKey("CompteBancaireId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Inocrea.CodaBox.ApiModel.Models.Transactions", b =>
                {
                    b.HasOne("Inocrea.CodaBox.ApiModel.Models.CompteBancaire", "CompteBancaire")
                        .WithMany("Transactions")
                        .HasForeignKey("CompteBancaireId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Inocrea.CodaBox.ApiModel.Models.Statements", "Statement")
                        .WithMany("Transactions")
                        .HasForeignKey("StatementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Inocrea.CodaBox.Web.Models.CodaBoxUser", b =>
                {
                    b.HasOne("Inocrea.CodaBox.ApiModel.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Inocrea.CodaBox.Web.Models.CodaBoxUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Inocrea.CodaBox.Web.Models.CodaBoxUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Inocrea.CodaBox.Web.Models.CodaBoxUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Inocrea.CodaBox.Web.Models.CodaBoxUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

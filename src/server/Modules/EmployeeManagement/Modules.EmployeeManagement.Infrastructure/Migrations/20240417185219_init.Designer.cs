﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Modules.EmployeeManagement.Infrastructure.Persistence;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Modules.EmployeeManagement.Infrastructure.Migrations
{
    [DbContext(typeof(EmployeeManagementDbContext))]
    [Migration("20240417185219_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("StaffManagement")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Modules.EmployeeManagement.Core.Entities.StaffMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EmployeedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("StaffMembers", "StaffManagement");
                });

            modelBuilder.Entity("Modules.EmployeeManagement.Core.Entities.StaffTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Due")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StaffMemberId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("StaffMemberId");

                    b.ToTable("StaffTask", "StaffManagement");
                });

            modelBuilder.Entity("Modules.EmployeeManagement.Core.Entities.StaffTask", b =>
                {
                    b.HasOne("Modules.EmployeeManagement.Core.Entities.StaffMember", "StaffMember")
                        .WithMany("StaffTasks")
                        .HasForeignKey("StaffMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaffMember");
                });

            modelBuilder.Entity("Modules.EmployeeManagement.Core.Entities.StaffMember", b =>
                {
                    b.Navigation("StaffTasks");
                });
#pragma warning restore 612, 618
        }
    }
}

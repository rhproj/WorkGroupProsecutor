﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkGroupProsecutor.Server.Data.Context;

#nullable disable

namespace WorkGroupProsecutor.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221109093217_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WorkGroupProsecutor.Shared.Models.Appeal.NoSolutionAppealModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppealClassificationId")
                        .HasColumnType("int");

                    b.Property<string>("ApplicantFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecisionBasis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentAssessment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentResolution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeriodInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearInfo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppealClassificationId");

                    b.ToTable("NoSolutionAppeal");
                });

            modelBuilder.Entity("WorkGroupProsecutor.Shared.Models.Appeal.RedirectedAppealModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppealClassificationId")
                        .HasColumnType("int");

                    b.Property<string>("ApplicantFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecisionBasis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentAssessment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeriodInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientAgency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearInfo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppealClassificationId");

                    b.ToTable("RedirectedAppeal");
                });

            modelBuilder.Entity("WorkGroupProsecutor.Shared.Models.Appeal.SatisfiedAppealModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppealClassificationId")
                        .HasColumnType("int");

                    b.Property<string>("ApplicantFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicantNotification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentAssessment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvestigationResults")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeriodInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProsecutorAction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightsRestoration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearInfo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppealClassificationId");

                    b.ToTable("SatisfiedAppeal");
                });

            modelBuilder.Entity("WorkGroupProsecutor.Shared.Models.Participants.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DepartmentIndex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("WorkGroupProsecutor.Shared.Models.Appeal.NoSolutionAppealModel", b =>
                {
                    b.HasOne("WorkGroupProsecutor.Shared.Models.Participants.Department", "AppealClassification")
                        .WithMany()
                        .HasForeignKey("AppealClassificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppealClassification");
                });

            modelBuilder.Entity("WorkGroupProsecutor.Shared.Models.Appeal.RedirectedAppealModel", b =>
                {
                    b.HasOne("WorkGroupProsecutor.Shared.Models.Participants.Department", "AppealClassification")
                        .WithMany()
                        .HasForeignKey("AppealClassificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppealClassification");
                });

            modelBuilder.Entity("WorkGroupProsecutor.Shared.Models.Appeal.SatisfiedAppealModel", b =>
                {
                    b.HasOne("WorkGroupProsecutor.Shared.Models.Participants.Department", "AppealClassification")
                        .WithMany()
                        .HasForeignKey("AppealClassificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppealClassification");
                });
#pragma warning restore 612, 618
        }
    }
}

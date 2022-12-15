﻿// <auto-generated />
using System;
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
    [Migration("20221215125216_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WorkGroupProsecutor.Shared.Authentication.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserAccount");

                    b.HasData(
                        new
                        {
                            Id = 53,
                            Password = "7",
                            Role = "Department",
                            UserDescription = "Управление по надзору за исполнением федерального законодательства",
                            UserName = "7"
                        },
                        new
                        {
                            Id = 54,
                            Password = "8",
                            Role = "Department",
                            UserDescription = "Обеспечение участия прокуроров в гражданском и арбитражном процессе",
                            UserName = "8"
                        },
                        new
                        {
                            Id = 55,
                            Password = "9",
                            Role = "Department",
                            UserDescription = "Отдел общего и особого делопроизводства",
                            UserName = "9"
                        },
                        new
                        {
                            Id = 56,
                            Password = "12",
                            Role = "Department",
                            UserDescription = "Уголовно-судебное управление",
                            UserName = "12"
                        },
                        new
                        {
                            Id = 57,
                            Password = "15",
                            Role = "Department",
                            UserDescription = "Надзор за следствием, дознанием и ОРД",
                            UserName = "15"
                        },
                        new
                        {
                            Id = 58,
                            Password = "17",
                            Role = "Department",
                            UserDescription = "Надзор за законностью исполнения уголовных наказаний",
                            UserName = "17"
                        },
                        new
                        {
                            Id = 59,
                            Password = "21",
                            Role = "Department",
                            UserDescription = "Надзор за исполнением законов о несовершеннолетних и молодежи",
                            UserName = "21"
                        },
                        new
                        {
                            Id = 60,
                            Password = "25",
                            Role = "Department",
                            UserDescription = "Старший помощник прокурора по рассмотрению обращений и приему граждан",
                            UserName = "25"
                        },
                        new
                        {
                            Id = 61,
                            Password = "27",
                            Role = "Department",
                            UserDescription = "Надзор за исполнением законов в федеральной безопасности",
                            UserName = "27"
                        },
                        new
                        {
                            Id = 62,
                            Password = "86",
                            Role = "Department",
                            UserDescription = "Надзор за исполнением законодательства о противодействии корупции",
                            UserName = "86"
                        },
                        new
                        {
                            Id = 63,
                            Password = "88",
                            Role = "Department",
                            UserDescription = "Надзор за исполнением законов в сфере ОПК",
                            UserName = "88"
                        },
                        new
                        {
                            Id = 1,
                            Password = "123",
                            Role = "District",
                            UserDescription = "г. Казань",
                            UserName = "kazan"
                        },
                        new
                        {
                            Id = 2,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Авиастроительный район",
                            UserName = "av"
                        },
                        new
                        {
                            Id = 3,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Кировский район",
                            UserName = "kir"
                        },
                        new
                        {
                            Id = 4,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Московский район",
                            UserName = "msk"
                        },
                        new
                        {
                            Id = 5,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Заинский район",
                            UserName = "zainsk"
                        },
                        new
                        {
                            Id = 6,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Зеленодольский район",
                            UserName = "zel"
                        },
                        new
                        {
                            Id = 7,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Вахитовский район",
                            UserName = "vah"
                        },
                        new
                        {
                            Id = 8,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Ново-Савиновский район",
                            UserName = "nvs"
                        },
                        new
                        {
                            Id = 9,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Приволжский район",
                            UserName = "priv"
                        },
                        new
                        {
                            Id = 10,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Советский район",
                            UserName = "sov"
                        },
                        new
                        {
                            Id = 11,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Агрызский район",
                            UserName = "agr"
                        },
                        new
                        {
                            Id = 12,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Азнакаевский район",
                            UserName = "azn"
                        },
                        new
                        {
                            Id = 13,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Аксубаевский район",
                            UserName = "aks"
                        },
                        new
                        {
                            Id = 14,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Актанышский район",
                            UserName = "aktan"
                        },
                        new
                        {
                            Id = 15,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Алексеевский район",
                            UserName = "al"
                        },
                        new
                        {
                            Id = 16,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Алькеевский район",
                            UserName = "alk"
                        },
                        new
                        {
                            Id = 17,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Альметьевский район",
                            UserName = "alm"
                        },
                        new
                        {
                            Id = 18,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Апастовский район",
                            UserName = "ap"
                        },
                        new
                        {
                            Id = 19,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Арский район",
                            UserName = "arsk"
                        },
                        new
                        {
                            Id = 20,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Атнинский район",
                            UserName = "atn"
                        },
                        new
                        {
                            Id = 21,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Бавлинский район",
                            UserName = "bavl"
                        },
                        new
                        {
                            Id = 22,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Балтасинский район",
                            UserName = "bal"
                        },
                        new
                        {
                            Id = 23,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Бугульминский район",
                            UserName = "bg"
                        },
                        new
                        {
                            Id = 24,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Буинский район",
                            UserName = "buinsk"
                        },
                        new
                        {
                            Id = 25,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Верхнеуслонский район",
                            UserName = "uslon"
                        },
                        new
                        {
                            Id = 26,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Высокогорский район",
                            UserName = "vis"
                        },
                        new
                        {
                            Id = 27,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Дрожжановский район",
                            UserName = "dr"
                        },
                        new
                        {
                            Id = 28,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Елабужский район",
                            UserName = "ybg"
                        },
                        new
                        {
                            Id = 29,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Кайбицкий район",
                            UserName = "kb"
                        },
                        new
                        {
                            Id = 30,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Камско-Устьинский район",
                            UserName = "kamsk"
                        },
                        new
                        {
                            Id = 31,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Кукморский район",
                            UserName = "kukm"
                        },
                        new
                        {
                            Id = 32,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Лаишеский район",
                            UserName = "lai"
                        },
                        new
                        {
                            Id = 33,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Лениногорский район",
                            UserName = "len"
                        },
                        new
                        {
                            Id = 34,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Мамадышский район",
                            UserName = "mam"
                        },
                        new
                        {
                            Id = 35,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Менделеевский район",
                            UserName = "mend"
                        },
                        new
                        {
                            Id = 36,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Мензелинский район",
                            UserName = "menz"
                        },
                        new
                        {
                            Id = 37,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Муслюмовский район",
                            UserName = "musl"
                        },
                        new
                        {
                            Id = 38,
                            Password = "123",
                            Role = "District",
                            UserDescription = "г. Набережные Челны",
                            UserName = "nab"
                        },
                        new
                        {
                            Id = 39,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Нижнекамский район",
                            UserName = "nk"
                        },
                        new
                        {
                            Id = 40,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Новошешминский район",
                            UserName = "nsh"
                        },
                        new
                        {
                            Id = 41,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Нурлатский район",
                            UserName = "nurlat"
                        },
                        new
                        {
                            Id = 42,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Пестречинский район",
                            UserName = "pes"
                        },
                        new
                        {
                            Id = 43,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Рыбно-Слободской район",
                            UserName = "rb"
                        },
                        new
                        {
                            Id = 44,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Сабинский район",
                            UserName = "sab"
                        },
                        new
                        {
                            Id = 45,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Сармановский район",
                            UserName = "sarmanovo"
                        },
                        new
                        {
                            Id = 46,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Спасский район",
                            UserName = "spassk"
                        },
                        new
                        {
                            Id = 47,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Тетюшский район",
                            UserName = "tet"
                        },
                        new
                        {
                            Id = 48,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Тукаевский район",
                            UserName = "tk"
                        },
                        new
                        {
                            Id = 49,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Тюлячинский район",
                            UserName = "tl"
                        },
                        new
                        {
                            Id = 50,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Черемшанский район",
                            UserName = "ch"
                        },
                        new
                        {
                            Id = 51,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Чистопольский район",
                            UserName = "chist"
                        },
                        new
                        {
                            Id = 52,
                            Password = "123",
                            Role = "District",
                            UserDescription = "Ютазинский район",
                            UserName = "ytz"
                        });
                });

            modelBuilder.Entity("WorkGroupProsecutor.Shared.Models.Appeal.NoSolutionAppealModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicantFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecisionBasis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentAssessment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("DepartmentResolution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<string>("NadzorHyperlink")
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

                    b.HasIndex("DepartmentId");

                    b.ToTable("NoSolutionAppeal");
                });

            modelBuilder.Entity("WorkGroupProsecutor.Shared.Models.Appeal.RedirectedAppealModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicantFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecisionBasis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentAssessment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<string>("NadzorHyperlink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeriodInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientAgency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearInfo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("RedirectedAppeal");
                });

            modelBuilder.Entity("WorkGroupProsecutor.Shared.Models.Appeal.SatisfiedAppealModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicantFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicantNotification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentAssessment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvestigationResults")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<string>("NadzorHyperlink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeriodInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProsecutorAction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightsRestoration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearInfo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentIndex = "7",
                            DepartmentName = "7 Управление по надзору за исполнением федерального законодательства"
                        },
                        new
                        {
                            Id = 2,
                            DepartmentIndex = "8",
                            DepartmentName = "8 Обеспечение участия прокуроров в гражданском и арбитражном процессе"
                        },
                        new
                        {
                            Id = 3,
                            DepartmentIndex = "9",
                            DepartmentName = "9 Отдел общего и особого делопроизводства"
                        },
                        new
                        {
                            Id = 4,
                            DepartmentIndex = "12",
                            DepartmentName = "12 Уголовно-судебное управление"
                        },
                        new
                        {
                            Id = 5,
                            DepartmentIndex = "15",
                            DepartmentName = "15 Надзор за следствием, дознанием и ОРД"
                        },
                        new
                        {
                            Id = 6,
                            DepartmentIndex = "17",
                            DepartmentName = "17 Надзор за законностью исполнения уголовных наказаний"
                        },
                        new
                        {
                            Id = 7,
                            DepartmentIndex = "21",
                            DepartmentName = "21 Надзор за исполнением законов о несовершеннолетних и молодежи"
                        },
                        new
                        {
                            Id = 8,
                            DepartmentIndex = "25",
                            DepartmentName = "25 Старший помощник прокурора по рассмотрению обращений и приему граждан"
                        },
                        new
                        {
                            Id = 9,
                            DepartmentIndex = "27",
                            DepartmentName = "27 Надзор за исполнением законов в федеральной безопасности"
                        },
                        new
                        {
                            Id = 10,
                            DepartmentIndex = "86",
                            DepartmentName = "86 Отдел по надзору за исполнением законодательства о противодействии корупции"
                        },
                        new
                        {
                            Id = 11,
                            DepartmentIndex = "88",
                            DepartmentName = "88 Надзор за исполнением законов в сфере ОПК"
                        });
                });

            modelBuilder.Entity("WorkGroupProsecutor.Shared.Models.Appeal.NoSolutionAppealModel", b =>
                {
                    b.HasOne("WorkGroupProsecutor.Shared.Models.Participants.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("WorkGroupProsecutor.Shared.Models.Appeal.RedirectedAppealModel", b =>
                {
                    b.HasOne("WorkGroupProsecutor.Shared.Models.Participants.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("WorkGroupProsecutor.Shared.Models.Appeal.SatisfiedAppealModel", b =>
                {
                    b.HasOne("WorkGroupProsecutor.Shared.Models.Participants.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}

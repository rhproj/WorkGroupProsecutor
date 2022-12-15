using Microsoft.EntityFrameworkCore;
using System.Data;
using WorkGroupProsecutor.Server.Authentication;
using WorkGroupProsecutor.Shared.Authentication;
using WorkGroupProsecutor.Shared.Models;
using WorkGroupProsecutor.Shared.Models.Appeal;
using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Server.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //public DbSet<DistrictRegisterModel> DistrictRegister { get; set; }
        public DbSet<NoSolutionAppealModel> NoSolutionAppeal { get; set; }
        public DbSet<RedirectedAppealModel> RedirectedAppeal { get; set; }
        public DbSet<SatisfiedAppealModel> SatisfiedAppeal { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; } //auth

        //public DbSet<RecipientAgency> RecipientAgency { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().HasData(
            #region DEPARTMENT
                new UserAccount
                {
                    Id = 53,
                    UserName = "7",
                    Password = "7",
                    Role = "Department",
                    UserDescription = "Управление по надзору за исполнением федерального законодательства"
                },
                new UserAccount
                {
                    Id = 54,
                    UserName = "8",
                    Password = "8",
                    Role = "Department",
                    UserDescription = "Обеспечение участия прокуроров в гражданском и арбитражном процессе"
                },
                new UserAccount
                {
                    Id = 55,
                    UserName = "9",
                    Password = "9",
                    Role = "Department",
                    UserDescription = "Отдел общего и особого делопроизводства"
                },
                new UserAccount
                {
                    Id = 56,
                    UserName = "12",
                    Password = "12",
                    Role = "Department",
                    UserDescription = "Уголовно-судебное управление"
                },
                new UserAccount
                {
                    Id = 57,
                    UserName = "15",
                    Password = "15",
                    Role = "Department",
                    UserDescription = "Надзор за следствием, дознанием и ОРД"
                },
                new UserAccount
                {
                    Id = 58,
                    UserName = "17",
                    Password = "17",
                    Role = "Department",
                    UserDescription = "Надзор за законностью исполнения уголовных наказаний"
                },
                new UserAccount
                {
                    Id = 59,
                    UserName = "21",
                    Password = "21",
                    Role = "Department",
                    UserDescription = "Надзор за исполнением законов о несовершеннолетних и молодежи"
                },
                new UserAccount
                {
                    Id = 60,
                    UserName = "25",
                    Password = "25",
                    Role = "Department",
                    UserDescription = "Старший помощник прокурора по рассмотрению обращений и приему граждан"
                },
                new UserAccount
                {
                    Id = 61,
                    UserName = "27",
                    Password = "27",
                    Role = "Department",
                    UserDescription = "Надзор за исполнением законов в федеральной безопасности"
                },
                new UserAccount
                {
                    Id = 62,
                    UserName = "86",
                    Password = "86",
                    Role = "Department",
                    UserDescription = "Надзор за исполнением законодательства о противодействии корупции"
                },
                new UserAccount
                {
                    Id = 63,
                    UserName = "88",
                    Password = "88",
                    Role = "Department",
                    UserDescription = "Надзор за исполнением законов в сфере ОПК"
                }, 
            #endregion
                //Districts
            #region DISTRICTS
                new UserAccount
                {
                    Id = 1,
                    UserName = "kazan",
                    Password = "123",
                    Role = "District",
                    UserDescription = "г. Казань"
                },
                new UserAccount
                {
                    Id = 2,
                    UserName = "av",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Авиастроительный район"
                },
                new UserAccount
                {
                    Id = 3,
                    UserName = "kir",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Кировский район"
                },
                new UserAccount
                {
                    Id = 4,
                    UserName = "msk",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Московский район"
                },
                new UserAccount
                {
                    Id = 5,
                    UserName = "zainsk",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Заинский район"
                },
                new UserAccount
                {
                    Id = 6,
                    UserName = "zel",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Зеленодольский район"
                },
                new UserAccount
                {
                    Id = 7,
                    UserName = "vah",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Вахитовский район"
                },
                new UserAccount
                {
                    Id = 8,
                    UserName = "nvs",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Ново-Савиновский район"
                },
                new UserAccount
                {
                    Id = 9,
                    UserName = "priv",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Приволжский район"
                },
                new UserAccount
                {
                    Id = 10,
                    UserName = "sov",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Советский район"
                },
                new UserAccount
                {
                    Id = 11,
                    UserName = "agr",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Агрызский район"
                },
                new UserAccount
                {
                    Id = 12,
                    UserName = "azn",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Азнакаевский район"
                },
                new UserAccount
                {
                    Id = 13,
                    UserName = "aks",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Аксубаевский район"
                },
                new UserAccount
                {
                    Id = 14,
                    UserName = "aktan",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Актанышский район"
                },
                new UserAccount
                {
                    Id = 15,
                    UserName = "al",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Алексеевский район"
                },
                new UserAccount
                {
                    Id = 16,
                    UserName = "alk",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Алькеевский район"
                },
                new UserAccount
                {
                    Id = 17,
                    UserName = "alm",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Альметьевский район"
                },
                new UserAccount
                {
                    Id = 18,
                    UserName = "ap",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Апастовский район"
                },
                new UserAccount
                {
                    Id = 19,
                    UserName = "arsk",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Арский район"
                },
                new UserAccount
                {
                    Id = 20,
                    UserName = "atn",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Атнинский район"
                },
                new UserAccount
                {
                    Id = 21,
                    UserName = "bavl",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Бавлинский район"
                },
                new UserAccount
                {
                    Id = 22,
                    UserName = "bal",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Балтасинский район"
                },
                new UserAccount
                {
                    Id = 23,
                    UserName = "bg",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Бугульминский район"
                },
                new UserAccount
                {
                    Id = 24,
                    UserName = "buinsk",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Буинский район"
                },
                new UserAccount
                {
                    Id = 25,
                    UserName = "uslon",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Верхнеуслонский район"
                },
                new UserAccount
                {
                    Id = 26,
                    UserName = "vis",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Высокогорский район"
                },
                new UserAccount
                {
                    Id = 27,
                    UserName = "dr",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Дрожжановский район"
                },
                new UserAccount
                {
                    Id = 28,
                    UserName = "ybg",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Елабужский район"
                },
                new UserAccount
                {
                    Id = 29,
                    UserName = "kb",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Кайбицкий район"
                },
                new UserAccount
                {
                    Id = 30,
                    UserName = "kamsk",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Камско-Устьинский район"
                },
                new UserAccount
                {
                    Id = 31,
                    UserName = "kukm",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Кукморский район"
                },
                new UserAccount
                {
                    Id = 32,
                    UserName = "lai",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Лаишеский район"
                },
                new UserAccount
                {
                    Id = 33,
                    UserName = "len",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Лениногорский район"
                },
                new UserAccount
                {
                    Id = 34,
                    UserName = "mam",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Мамадышский район"
                },
                new UserAccount
                {
                    Id = 35,
                    UserName = "mend",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Менделеевский район"
                },
                new UserAccount
                {
                    Id = 36,
                    UserName = "menz",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Мензелинский район"
                },
                new UserAccount
                {
                    Id = 37,
                    UserName = "musl",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Муслюмовский район"
                },
                new UserAccount
                {
                    Id = 38,
                    UserName = "nab",
                    Password = "123",
                    Role = "District",
                    UserDescription = "г. Набережные Челны"
                },
                new UserAccount
                {
                    Id = 39,
                    UserName = "nk",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Нижнекамский район"
                },
                new UserAccount
                {
                    Id = 40,
                    UserName = "nsh",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Новошешминский район"
                },
                new UserAccount
                {
                    Id = 41,
                    UserName = "nurlat",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Нурлатский район"
                },
                new UserAccount
                {
                    Id = 42,
                    UserName = "pes",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Пестречинский район"
                },
                new UserAccount
                {
                    Id = 43,
                    UserName = "rb",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Рыбно-Слободской район"
                },
                new UserAccount
                {
                    Id = 44,
                    UserName = "sab",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Сабинский район"
                },
                new UserAccount
                {
                    Id = 45,
                    UserName = "sarmanovo",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Сармановский район"
                },
                new UserAccount
                {
                    Id = 46,
                    UserName = "spassk",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Спасский район"
                },
                new UserAccount
                {
                    Id = 47,
                    UserName = "tet",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Тетюшский район"
                },
                new UserAccount
                {
                    Id = 48,
                    UserName = "tk",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Тукаевский район"
                },
                new UserAccount
                {
                    Id = 49,
                    UserName = "tl",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Тюлячинский район"
                },
                new UserAccount
                {
                    Id = 50,
                    UserName = "ch",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Черемшанский район"
                },
                new UserAccount
                {
                    Id = 51,
                    UserName = "chist",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Чистопольский район"
                },
                new UserAccount
                {
                    Id = 52,
                    UserName = "ytz",
                    Password = "123",
                    Role = "District",
                    UserDescription = "Ютазинский район"
                }); 
            #endregion


            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    DepartmentIndex = "7",
                    DepartmentName = "7 Управление по надзору за исполнением федерального законодательства"
                },
                new Department
                {
                    Id = 2,
                    DepartmentIndex = "8",
                    DepartmentName = "8 Обеспечение участия прокуроров в гражданском и арбитражном процессе"
                },
                new Department
                {
                    Id = 3,
                    DepartmentIndex = "9",
                    DepartmentName = "9 Отдел общего и особого делопроизводства"
                },
                new Department
                {
                    Id = 4,
                    DepartmentIndex = "12",
                    DepartmentName = "12 Уголовно-судебное управление"
                },
                new Department
                {
                    Id = 5,
                    DepartmentIndex = "15",
                    DepartmentName = "15 Надзор за следствием, дознанием и ОРД"
                },
                new Department
                {
                    Id = 6,
                    DepartmentIndex = "17",
                    DepartmentName = "17 Надзор за законностью исполнения уголовных наказаний"
                },
                new Department
                {
                    Id = 7,
                    DepartmentIndex = "21",
                    DepartmentName = "21 Надзор за исполнением законов о несовершеннолетних и молодежи"
                },
                new Department
                {
                    Id = 8,
                    DepartmentIndex = "25",
                    DepartmentName = "25 Старший помощник прокурора по рассмотрению обращений и приему граждан"
                },
                new Department
                {
                    Id = 9,
                    DepartmentIndex = "27",
                    DepartmentName = "27 Надзор за исполнением законов в федеральной безопасности"
                },
                new Department
                {
                    Id = 10,
                    DepartmentIndex = "86",
                    DepartmentName = "86 Отдел по надзору за исполнением законодательства о противодействии корупции"
                },
                new Department
                {
                    Id = 11,
                    DepartmentIndex = "88",
                    DepartmentName = "88 Надзор за исполнением законов в сфере ОПК"
                });

        }
    }
}

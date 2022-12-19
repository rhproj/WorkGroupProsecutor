using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkGroupProsecutor.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentIndex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoSolutionAppeal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentResolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionBasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NadzorHyperlink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    DepartmentAssessment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearInfo = table.Column<int>(type: "int", nullable: false),
                    PeriodInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasNoAppeals = table.Column<bool>(type: "bit", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoSolutionAppeal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoSolutionAppeal_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RedirectedAppeal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipientAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionBasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NadzorHyperlink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    DepartmentAssessment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearInfo = table.Column<int>(type: "int", nullable: false),
                    PeriodInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasNoAppeals = table.Column<bool>(type: "bit", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedirectedAppeal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RedirectedAppeal_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SatisfiedAppeal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProsecutorAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestigationResults = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RightsRestoration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantNotification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NadzorHyperlink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    DepartmentAssessment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearInfo = table.Column<int>(type: "int", nullable: false),
                    PeriodInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasNoAppeals = table.Column<bool>(type: "bit", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatisfiedAppeal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SatisfiedAppeal_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "DepartmentIndex", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "7", "Управление по надзору за исполнением федерального законодательства" },
                    { 2, "8", "Обеспечение участия прокуроров в гражданском и арбитражном процессе" },
                    { 3, "9", "Отдел общего и особого делопроизводства" },
                    { 4, "12", "Уголовно-судебное управление" },
                    { 5, "15", "Надзор за следствием, дознанием и ОРД" },
                    { 6, "17", "Надзор за законностью исполнения уголовных наказаний" },
                    { 7, "21", "Надзор за исполнением законов о несовершеннолетних и молодежи" },
                    { 8, "25", "Старший помощник прокурора по рассмотрению обращений и приему граждан" },
                    { 9, "27", "Надзор за исполнением законов в федеральной безопасности" },
                    { 10, "86", "Отдел по надзору за исполнением законодательства о противодействии корупции" },
                    { 11, "88", "Надзор за исполнением законов в сфере ОПК" }
                });

            migrationBuilder.InsertData(
                table: "UserAccount",
                columns: new[] { "Id", "Password", "Role", "UserDescription", "UserName" },
                values: new object[,]
                {
                    { 1, "123", "District", "Казань", "kazan" },
                    { 2, "123", "District", "Авиастроительный район", "av" },
                    { 3, "123", "District", "Кировский район", "kir" },
                    { 4, "123", "District", "Московский район", "msk" },
                    { 5, "123", "District", "Заинский район", "zainsk" },
                    { 6, "123", "District", "Зеленодольский район", "zel" },
                    { 7, "123", "District", "Вахитовский район", "vah" },
                    { 8, "123", "District", "Ново-Савиновский район", "nvs" },
                    { 9, "123", "District", "Приволжский район", "priv" },
                    { 10, "123", "District", "Советский район", "sov" },
                    { 11, "123", "District", "Агрызский район", "agr" },
                    { 12, "123", "District", "Азнакаевский район", "azn" },
                    { 13, "123", "District", "Аксубаевский район", "aks" },
                    { 14, "123", "District", "Актанышский район", "aktan" },
                    { 15, "123", "District", "Алексеевский район", "al" },
                    { 16, "123", "District", "Алькеевский район", "alk" },
                    { 17, "123", "District", "Альметьевский район", "alm" },
                    { 18, "123", "District", "Апастовский район", "ap" },
                    { 19, "123", "District", "Арский район", "arsk" },
                    { 20, "123", "District", "Атнинский район", "atn" },
                    { 21, "123", "District", "Бавлинский район", "bavl" },
                    { 22, "123", "District", "Балтасинский район", "bal" },
                    { 23, "123", "District", "Бугульминский район", "bg" },
                    { 24, "123", "District", "Буинский район", "buinsk" },
                    { 25, "123", "District", "Верхнеуслонский район", "uslon" },
                    { 26, "123", "District", "Высокогорский район", "vis" },
                    { 27, "123", "District", "Дрожжановский район", "dr" },
                    { 28, "123", "District", "Елабужский район", "ybg" },
                    { 29, "123", "District", "Кайбицкий район", "kb" },
                    { 30, "123", "District", "Камско-Устьинский район", "kamsk" },
                    { 31, "123", "District", "Кукморский район", "kukm" },
                    { 32, "123", "District", "Лаишеский район", "lai" },
                    { 33, "123", "District", "Лениногорский район", "len" },
                    { 34, "123", "District", "Мамадышский район", "mam" },
                    { 35, "123", "District", "Менделеевский район", "mend" },
                    { 36, "123", "District", "Мензелинский район", "menz" },
                    { 37, "123", "District", "Муслюмовский район", "musl" },
                    { 38, "123", "District", "Набережные Челны", "nab" },
                    { 39, "123", "District", "Нижнекамский район", "nk" },
                    { 40, "123", "District", "Новошешминский район", "nsh" },
                    { 41, "123", "District", "Нурлатский район", "nurlat" },
                    { 42, "123", "District", "Пестречинский район", "pes" },
                    { 43, "123", "District", "Рыбно-Слободской район", "rb" },
                    { 44, "123", "District", "Сабинский район", "sab" },
                    { 45, "123", "District", "Сармановский район", "sarmanovo" },
                    { 46, "123", "District", "Спасский район", "spassk" },
                    { 47, "123", "District", "Тетюшский район", "tet" },
                    { 48, "123", "District", "Тукаевский район", "tk" },
                    { 49, "123", "District", "Тюлячинский район", "tl" },
                    { 50, "123", "District", "Черемшанский район", "ch" },
                    { 51, "123", "District", "Чистопольский район", "chist" },
                    { 52, "123", "District", "Ютазинский район", "ytz" },
                    { 53, "7", "Department", "Управление по надзору за исполнением федерального законодательства", "7" },
                    { 54, "8", "Department", "Обеспечение участия прокуроров в гражданском и арбитражном процессе", "8" },
                    { 55, "9", "Department", "Отдел общего и особого делопроизводства", "9" },
                    { 56, "12", "Department", "Уголовно-судебное управление", "12" },
                    { 57, "15", "Department", "Надзор за следствием, дознанием и ОРД", "15" },
                    { 58, "17", "Department", "Надзор за законностью исполнения уголовных наказаний", "17" },
                    { 59, "21", "Department", "Надзор за исполнением законов о несовершеннолетних и молодежи", "21" },
                    { 60, "25", "Department", "Старший помощник прокурора по рассмотрению обращений и приему граждан", "25" },
                    { 61, "27", "Department", "Надзор за исполнением законов в федеральной безопасности", "27" },
                    { 62, "86", "Department", "Надзор за исполнением законодательства о противодействии корупции", "86" },
                    { 63, "88", "Department", "Надзор за исполнением законов в сфере ОПК", "88" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoSolutionAppeal_DepartmentId",
                table: "NoSolutionAppeal",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RedirectedAppeal_DepartmentId",
                table: "RedirectedAppeal",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SatisfiedAppeal_DepartmentId",
                table: "SatisfiedAppeal",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoSolutionAppeal");

            migrationBuilder.DropTable(
                name: "RedirectedAppeal");

            migrationBuilder.DropTable(
                name: "SatisfiedAppeal");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}

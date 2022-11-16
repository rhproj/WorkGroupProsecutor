using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkGroupProsecutor.Server.Migrations
{
    /// <inheritdoc />
    public partial class withId : Migration
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
                name: "NoSolutionAppeal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentResolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionBasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicantFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    DepartmentAssessment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearInfo = table.Column<int>(type: "int", nullable: true),
                    PeriodInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    ApplicantFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    DepartmentAssessment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearInfo = table.Column<int>(type: "int", nullable: true),
                    PeriodInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    ApplicantFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    DepartmentAssessment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearInfo = table.Column<int>(type: "int", nullable: true),
                    PeriodInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Department");
        }
    }
}

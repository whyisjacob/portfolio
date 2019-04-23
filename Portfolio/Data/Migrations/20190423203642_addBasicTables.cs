using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Data.Migrations
{
    public partial class addBasicTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogModel",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostName = table.Column<string>(nullable: true),
                    PostDate = table.Column<DateTime>(nullable: false),
                    PostDesc = table.Column<string>(nullable: true),
                    Post = table.Column<string>(nullable: true),
                    PostImg = table.Column<string>(nullable: true),
                    PostUrl1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogModel", x => x.PostId);
                });

            migrationBuilder.CreateTable(
                name: "EducationModel",
                columns: table => new
                {
                    InstitutionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Institution = table.Column<string>(nullable: true),
                    InstitutionDescription = table.Column<string>(nullable: true),
                    InstitutionContributions = table.Column<string>(nullable: true),
                    InstitutionStart = table.Column<DateTime>(nullable: false),
                    InstitutionEnd = table.Column<DateTime>(nullable: false),
                    InstitutionPhoto = table.Column<string>(nullable: true),
                    InstitutionUrl = table.Column<string>(nullable: true),
                    InstitutionUrl2 = table.Column<string>(nullable: true),
                    InstitutionAccolade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationModel", x => x.InstitutionId);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentModel",
                columns: table => new
                {
                    EmploymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Employment = table.Column<string>(nullable: true),
                    EmploymentDescription = table.Column<string>(nullable: true),
                    EmploymentContributions = table.Column<string>(nullable: true),
                    EmploymentStart = table.Column<DateTime>(nullable: false),
                    EmploymentEnd = table.Column<DateTime>(nullable: false),
                    EmploymentPhoto = table.Column<string>(nullable: true),
                    EmploymentUrl = table.Column<string>(nullable: true),
                    EmploymentAccolade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentModel", x => x.EmploymentId);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioModel",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectName = table.Column<string>(nullable: true),
                    ProjectDesc = table.Column<string>(nullable: true),
                    ProjectTech = table.Column<string>(nullable: true),
                    ProjectRole = table.Column<string>(nullable: true),
                    ProjectDate = table.Column<DateTime>(nullable: false),
                    DataEdited = table.Column<DateTime>(nullable: false),
                    ProjectAccolade = table.Column<string>(nullable: true),
                    ProjectImage = table.Column<string>(nullable: true),
                    ProjectUrl1 = table.Column<string>(nullable: true),
                    ProjectUrl2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioModel", x => x.ProjectId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogModel");

            migrationBuilder.DropTable(
                name: "EducationModel");

            migrationBuilder.DropTable(
                name: "EmploymentModel");

            migrationBuilder.DropTable(
                name: "PortfolioModel");
        }
    }
}

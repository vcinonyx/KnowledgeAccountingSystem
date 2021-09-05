using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KnowledgeAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSkillsCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkillsCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KnowledgeAreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_KnowledgeAreas_KnowledgeAreaId",
                        column: x => x.KnowledgeAreaId,
                        principalTable: "KnowledgeAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEvaluetedSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserSkillsCardId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvaluetedSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEvaluetedSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEvaluetedSkills_UserSkillsCards_UserSkillsCardId",
                        column: x => x.UserSkillsCardId,
                        principalTable: "UserSkillsCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_KnowledgeAreaId",
                table: "Skills",
                column: "KnowledgeAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvaluetedSkills_SkillId",
                table: "UserEvaluetedSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvaluetedSkills_UserSkillsCardId",
                table: "UserEvaluetedSkills",
                column: "UserSkillsCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEvaluetedSkills");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "UserSkillsCards");

            migrationBuilder.DropTable(
                name: "KnowledgeAreas");
        }
    }
}

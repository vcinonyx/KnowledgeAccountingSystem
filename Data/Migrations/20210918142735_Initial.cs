using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Initial : Migration
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
                });

            migrationBuilder.InsertData(
                table: "KnowledgeAreas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Programming Languages" },
                    { 2, "Source Control" },
                    { 3, "IDEs (Integrated Development Environment)" },
                    { 4, "Databases" },
                    { 5, "Operating Systems" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "KnowledgeAreaId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "C#" },
                    { 20, 3, "NetBeans" },
                    { 21, 3, "Xcode" },
                    { 22, 4, "SQL" },
                    { 23, 4, "T-SQL" },
                    { 24, 4, "MySQL" },
                    { 25, 4, "Oracle" },
                    { 19, 3, "Rider" },
                    { 26, 4, "PostgreSQL" },
                    { 28, 4, "NoSQL" },
                    { 29, 4, "MongoDB" },
                    { 30, 4, "Redis" },
                    { 31, 5, "Linux" },
                    { 32, 5, "MacOS" },
                    { 33, 5, "Windows" },
                    { 27, 4, "Microsoft SQL Server" },
                    { 34, 5, "iOS" },
                    { 18, 3, "PyCharm" },
                    { 16, 3, "Visual Studio Code" },
                    { 2, 1, "C/C++" },
                    { 3, 1, "Java" },
                    { 4, 1, "Python" },
                    { 5, 1, "JavaScript" },
                    { 6, 1, "TypeScript" },
                    { 7, 1, "PHP" },
                    { 17, 3, "Android Studio" },
                    { 8, 1, "Go" },
                    { 10, 1, "Swift" },
                    { 11, 2, "Git" },
                    { 12, 2, "Mercurial" },
                    { 13, 2, "Perforce Helix Core" },
                    { 14, 3, "Visual Studio" },
                    { 15, 3, "Eclipse" },
                    { 9, 1, "Kotlin" },
                    { 35, 5, "Android" }
                });

            migrationBuilder.InsertData(
                table: "UserEvaluetedSkills",
                columns: new[] { "Id", "Grade", "SkillId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, "7f171733-5277-434f-88f2-6ee032e600c4" },
                    { 2, 2, 2, "7f171733-5277-434f-88f2-6ee032e600c4" },
                    { 3, 3, 3, "7f171733-5277-434f-88f2-6ee032e600c4" },
                    { 4, 4, 4, "7f171733-5277-434f-88f2-6ee032e600c4" },
                    { 5, 2, 5, "878614e6-8390-4a03-938b-bfd081dbf944" },
                    { 6, 5, 6, "878614e6-8390-4a03-938b-bfd081dbf944" },
                    { 7, 4, 7, "878614e6-8390-4a03-938b-bfd081dbf944" },
                    { 8, 1, 8, "878614e6-8390-4a03-938b-bfd081dbf944" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_KnowledgeAreaId",
                table: "Skills",
                column: "KnowledgeAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvaluetedSkills_SkillId",
                table: "UserEvaluetedSkills",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEvaluetedSkills");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "KnowledgeAreas");
        }
    }
}

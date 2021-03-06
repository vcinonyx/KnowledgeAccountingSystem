// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(AccountingSystemDbContext))]
    [Migration("20210918142735_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.KnowledgeArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KnowledgeAreas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Programming Languages"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Source Control"
                        },
                        new
                        {
                            Id = 3,
                            Name = "IDEs (Integrated Development Environment)"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Databases"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Operating Systems"
                        });
                });

            modelBuilder.Entity("DAL.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KnowledgeAreaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KnowledgeAreaId");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            KnowledgeAreaId = 1,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 2,
                            KnowledgeAreaId = 1,
                            Name = "C/C++"
                        },
                        new
                        {
                            Id = 3,
                            KnowledgeAreaId = 1,
                            Name = "Java"
                        },
                        new
                        {
                            Id = 4,
                            KnowledgeAreaId = 1,
                            Name = "Python"
                        },
                        new
                        {
                            Id = 5,
                            KnowledgeAreaId = 1,
                            Name = "JavaScript"
                        },
                        new
                        {
                            Id = 6,
                            KnowledgeAreaId = 1,
                            Name = "TypeScript"
                        },
                        new
                        {
                            Id = 7,
                            KnowledgeAreaId = 1,
                            Name = "PHP"
                        },
                        new
                        {
                            Id = 8,
                            KnowledgeAreaId = 1,
                            Name = "Go"
                        },
                        new
                        {
                            Id = 9,
                            KnowledgeAreaId = 1,
                            Name = "Kotlin"
                        },
                        new
                        {
                            Id = 10,
                            KnowledgeAreaId = 1,
                            Name = "Swift"
                        },
                        new
                        {
                            Id = 11,
                            KnowledgeAreaId = 2,
                            Name = "Git"
                        },
                        new
                        {
                            Id = 12,
                            KnowledgeAreaId = 2,
                            Name = "Mercurial"
                        },
                        new
                        {
                            Id = 13,
                            KnowledgeAreaId = 2,
                            Name = "Perforce Helix Core"
                        },
                        new
                        {
                            Id = 14,
                            KnowledgeAreaId = 3,
                            Name = "Visual Studio"
                        },
                        new
                        {
                            Id = 15,
                            KnowledgeAreaId = 3,
                            Name = "Eclipse"
                        },
                        new
                        {
                            Id = 16,
                            KnowledgeAreaId = 3,
                            Name = "Visual Studio Code"
                        },
                        new
                        {
                            Id = 17,
                            KnowledgeAreaId = 3,
                            Name = "Android Studio"
                        },
                        new
                        {
                            Id = 18,
                            KnowledgeAreaId = 3,
                            Name = "PyCharm"
                        },
                        new
                        {
                            Id = 19,
                            KnowledgeAreaId = 3,
                            Name = "Rider"
                        },
                        new
                        {
                            Id = 20,
                            KnowledgeAreaId = 3,
                            Name = "NetBeans"
                        },
                        new
                        {
                            Id = 21,
                            KnowledgeAreaId = 3,
                            Name = "Xcode"
                        },
                        new
                        {
                            Id = 22,
                            KnowledgeAreaId = 4,
                            Name = "SQL"
                        },
                        new
                        {
                            Id = 23,
                            KnowledgeAreaId = 4,
                            Name = "T-SQL"
                        },
                        new
                        {
                            Id = 24,
                            KnowledgeAreaId = 4,
                            Name = "MySQL"
                        },
                        new
                        {
                            Id = 25,
                            KnowledgeAreaId = 4,
                            Name = "Oracle"
                        },
                        new
                        {
                            Id = 26,
                            KnowledgeAreaId = 4,
                            Name = "PostgreSQL"
                        },
                        new
                        {
                            Id = 27,
                            KnowledgeAreaId = 4,
                            Name = "Microsoft SQL Server"
                        },
                        new
                        {
                            Id = 28,
                            KnowledgeAreaId = 4,
                            Name = "NoSQL"
                        },
                        new
                        {
                            Id = 29,
                            KnowledgeAreaId = 4,
                            Name = "MongoDB"
                        },
                        new
                        {
                            Id = 30,
                            KnowledgeAreaId = 4,
                            Name = "Redis"
                        },
                        new
                        {
                            Id = 31,
                            KnowledgeAreaId = 5,
                            Name = "Linux"
                        },
                        new
                        {
                            Id = 32,
                            KnowledgeAreaId = 5,
                            Name = "MacOS"
                        },
                        new
                        {
                            Id = 33,
                            KnowledgeAreaId = 5,
                            Name = "Windows"
                        },
                        new
                        {
                            Id = 34,
                            KnowledgeAreaId = 5,
                            Name = "iOS"
                        },
                        new
                        {
                            Id = 35,
                            KnowledgeAreaId = 5,
                            Name = "Android"
                        });
                });

            modelBuilder.Entity("DAL.Entities.UserEvaluetedSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.ToTable("UserEvaluetedSkills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Grade = 1,
                            SkillId = 1,
                            UserId = "7f171733-5277-434f-88f2-6ee032e600c4"
                        },
                        new
                        {
                            Id = 2,
                            Grade = 2,
                            SkillId = 2,
                            UserId = "7f171733-5277-434f-88f2-6ee032e600c4"
                        },
                        new
                        {
                            Id = 3,
                            Grade = 3,
                            SkillId = 3,
                            UserId = "7f171733-5277-434f-88f2-6ee032e600c4"
                        },
                        new
                        {
                            Id = 4,
                            Grade = 4,
                            SkillId = 4,
                            UserId = "7f171733-5277-434f-88f2-6ee032e600c4"
                        },
                        new
                        {
                            Id = 5,
                            Grade = 2,
                            SkillId = 5,
                            UserId = "878614e6-8390-4a03-938b-bfd081dbf944"
                        },
                        new
                        {
                            Id = 6,
                            Grade = 5,
                            SkillId = 6,
                            UserId = "878614e6-8390-4a03-938b-bfd081dbf944"
                        },
                        new
                        {
                            Id = 7,
                            Grade = 4,
                            SkillId = 7,
                            UserId = "878614e6-8390-4a03-938b-bfd081dbf944"
                        },
                        new
                        {
                            Id = 8,
                            Grade = 1,
                            SkillId = 8,
                            UserId = "878614e6-8390-4a03-938b-bfd081dbf944"
                        });
                });

            modelBuilder.Entity("DAL.Entities.Skill", b =>
                {
                    b.HasOne("DAL.Entities.KnowledgeArea", "KnowledgeArea")
                        .WithMany("Skills")
                        .HasForeignKey("KnowledgeAreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KnowledgeArea");
                });

            modelBuilder.Entity("DAL.Entities.UserEvaluetedSkill", b =>
                {
                    b.HasOne("DAL.Entities.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("DAL.Entities.KnowledgeArea", b =>
                {
                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}

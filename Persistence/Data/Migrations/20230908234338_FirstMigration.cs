using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_area", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contact_category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact_category", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contact_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact_type", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "doc_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abbreviation = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doc_type", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "incidence_level",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incidence_level", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "incidence_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incidence_type", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "work_tool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work_tool", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "place",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdAreaFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_place", x => x.Id);
                    table.ForeignKey(
                        name: "FK_place_area_IdAreaFk",
                        column: x => x.IdAreaFk,
                        principalTable: "area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDocTypeFk = table.Column<int>(type: "int", nullable: false),
                    IdRoleFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_doc_type_IdDocTypeFk",
                        column: x => x.IdDocTypeFk,
                        principalTable: "doc_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_role_IdRoleFk",
                        column: x => x.IdRoleFk,
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdUserFk = table.Column<int>(type: "int", nullable: false),
                    IdContactTypeFk = table.Column<int>(type: "int", nullable: false),
                    IdContactCategoryFk = table.Column<int>(type: "int", nullable: false),
                    DocTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contact_contact_category_IdContactCategoryFk",
                        column: x => x.IdContactCategoryFk,
                        principalTable: "contact_category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contact_contact_type_IdContactTypeFk",
                        column: x => x.IdContactTypeFk,
                        principalTable: "contact_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contact_doc_type_DocTypeId",
                        column: x => x.DocTypeId,
                        principalTable: "doc_type",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_contact_user_IdUserFk",
                        column: x => x.IdUserFk,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "incidence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdStateFk = table.Column<int>(type: "int", nullable: false),
                    IdUserFk = table.Column<int>(type: "int", nullable: false),
                    IdAreaFk = table.Column<int>(type: "int", nullable: false),
                    IdPlaceFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incidence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_incidence_area_IdAreaFk",
                        column: x => x.IdAreaFk,
                        principalTable: "area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_incidence_place_IdPlaceFk",
                        column: x => x.IdPlaceFk,
                        principalTable: "place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_incidence_state_IdStateFk",
                        column: x => x.IdStateFk,
                        principalTable: "state",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_incidence_user_IdUserFk",
                        column: x => x.IdUserFk,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserAreas",
                columns: table => new
                {
                    IdUserFk = table.Column<int>(type: "int", nullable: false),
                    IdAreaFk = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAreas", x => new { x.IdUserFk, x.IdAreaFk });
                    table.ForeignKey(
                        name: "FK_UserAreas_area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "area",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAreas_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "incidence_detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdWorkToolFk = table.Column<int>(type: "int", nullable: false),
                    IdIncidenceTypeFk = table.Column<int>(type: "int", nullable: false),
                    IdIncidenceLevelFk = table.Column<int>(type: "int", nullable: false),
                    IdStateFk = table.Column<int>(type: "int", nullable: false),
                    IncidenceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incidence_detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_incidence_detail_incidence_IncidenceId",
                        column: x => x.IncidenceId,
                        principalTable: "incidence",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_incidence_detail_incidence_level_IdIncidenceLevelFk",
                        column: x => x.IdIncidenceLevelFk,
                        principalTable: "incidence_level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_incidence_detail_incidence_type_IdIncidenceTypeFk",
                        column: x => x.IdIncidenceTypeFk,
                        principalTable: "incidence_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_incidence_detail_state_IdStateFk",
                        column: x => x.IdStateFk,
                        principalTable: "state",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_incidence_detail_work_tool_IdWorkToolFk",
                        column: x => x.IdWorkToolFk,
                        principalTable: "work_tool",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_contact_DocTypeId",
                table: "contact",
                column: "DocTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_contact_IdContactCategoryFk",
                table: "contact",
                column: "IdContactCategoryFk");

            migrationBuilder.CreateIndex(
                name: "IX_contact_IdContactTypeFk",
                table: "contact",
                column: "IdContactTypeFk");

            migrationBuilder.CreateIndex(
                name: "IX_contact_IdUserFk",
                table: "contact",
                column: "IdUserFk");

            migrationBuilder.CreateIndex(
                name: "IX_incidence_IdAreaFk",
                table: "incidence",
                column: "IdAreaFk");

            migrationBuilder.CreateIndex(
                name: "IX_incidence_IdPlaceFk",
                table: "incidence",
                column: "IdPlaceFk");

            migrationBuilder.CreateIndex(
                name: "IX_incidence_IdStateFk",
                table: "incidence",
                column: "IdStateFk");

            migrationBuilder.CreateIndex(
                name: "IX_incidence_IdUserFk",
                table: "incidence",
                column: "IdUserFk");

            migrationBuilder.CreateIndex(
                name: "IX_incidence_detail_IdIncidenceLevelFk",
                table: "incidence_detail",
                column: "IdIncidenceLevelFk");

            migrationBuilder.CreateIndex(
                name: "IX_incidence_detail_IdIncidenceTypeFk",
                table: "incidence_detail",
                column: "IdIncidenceTypeFk");

            migrationBuilder.CreateIndex(
                name: "IX_incidence_detail_IdStateFk",
                table: "incidence_detail",
                column: "IdStateFk");

            migrationBuilder.CreateIndex(
                name: "IX_incidence_detail_IdWorkToolFk",
                table: "incidence_detail",
                column: "IdWorkToolFk");

            migrationBuilder.CreateIndex(
                name: "IX_incidence_detail_IncidenceId",
                table: "incidence_detail",
                column: "IncidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_place_IdAreaFk",
                table: "place",
                column: "IdAreaFk");

            migrationBuilder.CreateIndex(
                name: "IX_user_IdDocTypeFk",
                table: "user",
                column: "IdDocTypeFk");

            migrationBuilder.CreateIndex(
                name: "IX_user_IdRoleFk",
                table: "user",
                column: "IdRoleFk");

            migrationBuilder.CreateIndex(
                name: "IX_UserAreas_AreaId",
                table: "UserAreas",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAreas_UserId",
                table: "UserAreas",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contact");

            migrationBuilder.DropTable(
                name: "incidence_detail");

            migrationBuilder.DropTable(
                name: "UserAreas");

            migrationBuilder.DropTable(
                name: "contact_category");

            migrationBuilder.DropTable(
                name: "contact_type");

            migrationBuilder.DropTable(
                name: "incidence");

            migrationBuilder.DropTable(
                name: "incidence_level");

            migrationBuilder.DropTable(
                name: "incidence_type");

            migrationBuilder.DropTable(
                name: "work_tool");

            migrationBuilder.DropTable(
                name: "place");

            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "area");

            migrationBuilder.DropTable(
                name: "doc_type");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}

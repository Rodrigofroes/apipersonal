using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api_personal.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Academia",
                columns: table => new
                {
                    Aca_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Aca_nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Aca_latitude = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Aca_longitude = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Aca_endereco = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Aca_telefone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Aca_email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Aca_logo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academia", x => x.Aca_id);
                });

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    Per_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Per_nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Per_cref = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Per_telefone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Per_especialidade = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Per_ativo = table.Column<bool>(type: "boolean", maxLength: 255, nullable: false),
                    Per_foto = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Per_cpf = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.Per_id);
                });

            migrationBuilder.CreateTable(
                name: "AcademiaPersonal",
                columns: table => new
                {
                    Acp_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Acp_aca_id = table.Column<int>(type: "integer", nullable: false),
                    Acp_per_id = table.Column<int>(type: "integer", nullable: false),
                    Acp_data_inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Acp_valor = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademiaPersonal", x => x.Acp_id);
                    table.ForeignKey(
                        name: "FK_AcademiaPersonal_Academia_Acp_aca_id",
                        column: x => x.Acp_aca_id,
                        principalTable: "Academia",
                        principalColumn: "Aca_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademiaPersonal_Personal_Acp_per_id",
                        column: x => x.Acp_per_id,
                        principalTable: "Personal",
                        principalColumn: "Per_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademiaPersonal_Acp_aca_id",
                table: "AcademiaPersonal",
                column: "Acp_aca_id");

            migrationBuilder.CreateIndex(
                name: "IX_AcademiaPersonal_Acp_per_id",
                table: "AcademiaPersonal",
                column: "Acp_per_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademiaPersonal");

            migrationBuilder.DropTable(
                name: "Academia");

            migrationBuilder.DropTable(
                name: "Personal");
        }
    }
}

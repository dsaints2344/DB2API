using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectAPI.Migrations
{
    public partial class CreateSchoolDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    IdEstado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "Maestros",
                columns: table => new
                {
                    IdMaestro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMaestro = table.Column<string>(nullable: true),
                    ApellidoMaestro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maestros", x => x.IdMaestro);
                });

            migrationBuilder.CreateTable(
                name: "TipoGrados",
                columns: table => new
                {
                    IdTipoGrado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoGrados", x => x.IdTipoGrado);
                });

            migrationBuilder.CreateTable(
                name: "RegistroGrados",
                columns: table => new
                {
                    IdRegistroGrado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaestroIdMaestro = table.Column<int>(nullable: true),
                    Curso = table.Column<string>(nullable: true),
                    TblTipoGradoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroGrados", x => x.IdRegistroGrado);
                    table.ForeignKey(
                        name: "FK_RegistroGrados_Maestros_MaestroIdMaestro",
                        column: x => x.MaestroIdMaestro,
                        principalTable: "Maestros",
                        principalColumn: "IdMaestro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistroGrados_TipoGrados_TblTipoGradoId",
                        column: x => x.TblTipoGradoId,
                        principalTable: "TipoGrados",
                        principalColumn: "IdTipoGrado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    IdAlumno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAlumno = table.Column<string>(nullable: true),
                    ApellidoAlumno = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "Date", nullable: false),
                    tblRegistroGradoId = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "Date", nullable: false),
                    TblEstadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.IdAlumno);
                    table.ForeignKey(
                        name: "FK_Alumnos_Estados_TblEstadoId",
                        column: x => x.TblEstadoId,
                        principalTable: "Estados",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alumnos_RegistroGrados_tblRegistroGradoId",
                        column: x => x.tblRegistroGradoId,
                        principalTable: "RegistroGrados",
                        principalColumn: "IdRegistroGrado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_TblEstadoId",
                table: "Alumnos",
                column: "TblEstadoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_tblRegistroGradoId",
                table: "Alumnos",
                column: "tblRegistroGradoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroGrados_MaestroIdMaestro",
                table: "RegistroGrados",
                column: "MaestroIdMaestro");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroGrados_TblTipoGradoId",
                table: "RegistroGrados",
                column: "TblTipoGradoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "RegistroGrados");

            migrationBuilder.DropTable(
                name: "Maestros");

            migrationBuilder.DropTable(
                name: "TipoGrados");
        }
    }
}

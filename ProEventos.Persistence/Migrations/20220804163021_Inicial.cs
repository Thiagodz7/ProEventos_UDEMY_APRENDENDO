﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProEventos.Persistence.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtEveneto = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Tema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdPessoas = table.Column<int>(type: "int", nullable: false),
                    ImagemURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Palestrantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagemUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palestrantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DtInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lotes_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PalestrantesEventos",
                columns: table => new
                {
                    PalestranteId = table.Column<int>(type: "int", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalestrantesEventos", x => new { x.PalestranteId, x.EventoId });
                    table.ForeignKey(
                        name: "FK_PalestrantesEventos_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PalestrantesEventos_Palestrantes_PalestranteId",
                        column: x => x.PalestranteId,
                        principalTable: "Palestrantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RedeSociais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventoId = table.Column<int>(type: "int", nullable: false),
                    PalestranteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedeSociais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RedeSociais_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RedeSociais_Palestrantes_PalestranteId",
                        column: x => x.PalestranteId,
                        principalTable: "Palestrantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_EventoId",
                table: "Lotes",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_PalestrantesEventos_EventoId",
                table: "PalestrantesEventos",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_RedeSociais_EventoId",
                table: "RedeSociais",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_RedeSociais_PalestranteId",
                table: "RedeSociais",
                column: "PalestranteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lotes");

            migrationBuilder.DropTable(
                name: "PalestrantesEventos");

            migrationBuilder.DropTable(
                name: "RedeSociais");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Palestrantes");
        }
    }
}

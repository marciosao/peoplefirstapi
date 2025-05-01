using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleFirst.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DominioAgilidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Dominio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DominioAgilidade", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "perfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    perfil = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pilarhappiness",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    pilar = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descricaoPilar = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ativo = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pilarhappiness", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "time",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ativo = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_time", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipoCompetencia",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoCompetencia", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipofeedback",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipofeedback", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PilarDominio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Pilar = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DominioAgilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilarDominio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PilarDominio_DominioAgilidade_DominioAgilidadeId",
                        column: x => x.DominioAgilidadeId,
                        principalTable: "DominioAgilidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "colaborador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SenhaHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    datanascimento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    cargo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ativo = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    foto = table.Column<byte[]>(type: "longblob", nullable: true),
                    idPerfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colaborador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_colaborador_perfil_idPerfil",
                        column: x => x.idPerfil,
                        principalTable: "perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HealthCheck",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TimeId = table.Column<int>(type: "int", nullable: false),
                    IdFacilitador = table.Column<int>(type: "int", nullable: true),
                    DataExecucao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    NotaGeral = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    ConsideracoesFinais = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCheck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthCheck_time_TimeId",
                        column: x => x.TimeId,
                        principalTable: "time",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PilarCompetencia",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Pilar = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PerfilId = table.Column<int>(type: "int", nullable: false),
                    TipoCompetenciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilarCompetencia", x => x.id);
                    table.ForeignKey(
                        name: "FK_PilarCompetencia_perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PilarCompetencia_tipoCompetencia_TipoCompetenciaId",
                        column: x => x.TipoCompetenciaId,
                        principalTable: "tipoCompetencia",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "QuestaoPilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Questao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PilarDominioId = table.Column<int>(type: "int", nullable: false),
                    DominioAgilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestaoPilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestaoPilar_PilarDominio_PilarDominioId",
                        column: x => x.PilarDominioId,
                        principalTable: "PilarDominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "avaliacaocolaborador",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idColaborador = table.Column<int>(type: "int", nullable: true),
                    idLider = table.Column<int>(type: "int", nullable: true),
                    data = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    percepcao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    comentarioGeral = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    planoAcao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    avaliacaoColaboradorcol = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    finalizada = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    colaborador_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avaliacaocolaborador", x => x.id);
                    table.ForeignKey(
                        name: "FK_avaliacaocolaborador_colaborador_colaborador_id",
                        column: x => x.colaborador_id,
                        principalTable: "colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "feedback",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idColaborador = table.Column<int>(type: "int", nullable: false),
                    idLider = table.Column<int>(type: "int", nullable: false),
                    idTipoFeedback = table.Column<int>(type: "int", nullable: true),
                    observacoes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    percepcao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    planoAcao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    colaborador_id = table.Column<int>(type: "int", nullable: false),
                    tipoFeedback_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback", x => x.id);
                    table.ForeignKey(
                        name: "FK_feedback_colaborador_colaborador_id",
                        column: x => x.colaborador_id,
                        principalTable: "colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_feedback_tipofeedback_tipoFeedback_id",
                        column: x => x.tipoFeedback_id,
                        principalTable: "tipofeedback",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "happiness",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idColaborador = table.Column<int>(type: "int", nullable: true),
                    data = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    NotaGeral = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    avaliacaoGeral = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    colaborador_id = table.Column<int>(type: "int", nullable: false),
                    colaborador_perfil_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_happiness", x => x.id);
                    table.ForeignKey(
                        name: "FK_happiness_colaborador_colaborador_id",
                        column: x => x.colaborador_id,
                        principalTable: "colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "timecolaborador",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idTime = table.Column<int>(type: "int", nullable: true),
                    idColaborador = table.Column<int>(type: "int", nullable: true),
                    time_id = table.Column<int>(type: "int", nullable: false),
                    colaborador_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timecolaborador", x => x.id);
                    table.ForeignKey(
                        name: "FK_timecolaborador_colaborador_colaborador_id",
                        column: x => x.colaborador_id,
                        principalTable: "colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_timecolaborador_time_time_id",
                        column: x => x.time_id,
                        principalTable: "time",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "itempilar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    item = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPilarCompetencia = table.Column<int>(type: "int", nullable: false),
                    PilarCompetenciaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itempilar", x => x.id);
                    table.ForeignKey(
                        name: "FK_itempilar_PilarCompetencia_IdPilarCompetencia",
                        column: x => x.IdPilarCompetencia,
                        principalTable: "PilarCompetencia",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_itempilar_PilarCompetencia_PilarCompetenciaId",
                        column: x => x.PilarCompetenciaId,
                        principalTable: "PilarCompetencia",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AvaliacaoHealthCheck",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HealthCheckId = table.Column<int>(type: "int", nullable: false),
                    TimeId = table.Column<int>(type: "int", nullable: false),
                    QuestaoPilarId = table.Column<int>(type: "int", nullable: false),
                    PilarDominioId = table.Column<int>(type: "int", nullable: false),
                    DominioAgilidadeId = table.Column<int>(type: "int", nullable: false),
                    NotaFinal = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Observacoes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoHealthCheck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacaoHealthCheck_HealthCheck_HealthCheckId",
                        column: x => x.HealthCheckId,
                        principalTable: "HealthCheck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvaliacaoHealthCheck_QuestaoPilar_QuestaoPilarId",
                        column: x => x.QuestaoPilarId,
                        principalTable: "QuestaoPilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OpiniaoPilarHappiness",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idHappiness = table.Column<int>(type: "int", nullable: true),
                    idPilarHappiness = table.Column<int>(type: "int", nullable: true),
                    nota = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    comentario = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    happiness_id = table.Column<int>(type: "int", nullable: false),
                    pilarHappiness_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpiniaoPilarHappiness", x => x.id);
                    table.ForeignKey(
                        name: "FK_OpiniaoPilarHappiness_happiness_happiness_id",
                        column: x => x.happiness_id,
                        principalTable: "happiness",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpiniaoPilarHappiness_pilarhappiness_pilarHappiness_id",
                        column: x => x.pilarHappiness_id,
                        principalTable: "pilarhappiness",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "avalicaocolaboradoritempilar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idAvaliacaoColaborador = table.Column<int>(type: "int", nullable: true),
                    idItemPilar = table.Column<int>(type: "int", nullable: true),
                    nota = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    avaliacaoColaborador_id = table.Column<int>(type: "int", nullable: false),
                    itemPilar_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avalicaocolaboradoritempilar", x => x.id);
                    table.ForeignKey(
                        name: "FK_avalicaocolaboradoritempilar_avaliacaocolaborador_avaliacaoC~",
                        column: x => x.avaliacaoColaborador_id,
                        principalTable: "avaliacaocolaborador",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_avalicaocolaboradoritempilar_itempilar_itemPilar_id",
                        column: x => x.itemPilar_id,
                        principalTable: "itempilar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_avaliacaocolaborador_colaborador_id",
                table: "avaliacaocolaborador",
                column: "colaborador_id");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoHealthCheck_HealthCheckId",
                table: "AvaliacaoHealthCheck",
                column: "HealthCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoHealthCheck_QuestaoPilarId",
                table: "AvaliacaoHealthCheck",
                column: "QuestaoPilarId");

            migrationBuilder.CreateIndex(
                name: "IX_avalicaocolaboradoritempilar_avaliacaoColaborador_id",
                table: "avalicaocolaboradoritempilar",
                column: "avaliacaoColaborador_id");

            migrationBuilder.CreateIndex(
                name: "IX_avalicaocolaboradoritempilar_itemPilar_id",
                table: "avalicaocolaboradoritempilar",
                column: "itemPilar_id");

            migrationBuilder.CreateIndex(
                name: "IX_colaborador_idPerfil",
                table: "colaborador",
                column: "idPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_colaborador_id",
                table: "feedback",
                column: "colaborador_id");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_tipoFeedback_id",
                table: "feedback",
                column: "tipoFeedback_id");

            migrationBuilder.CreateIndex(
                name: "IX_happiness_colaborador_id",
                table: "happiness",
                column: "colaborador_id");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCheck_TimeId",
                table: "HealthCheck",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_itempilar_IdPilarCompetencia",
                table: "itempilar",
                column: "IdPilarCompetencia");

            migrationBuilder.CreateIndex(
                name: "IX_itempilar_PilarCompetenciaId",
                table: "itempilar",
                column: "PilarCompetenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_OpiniaoPilarHappiness_happiness_id",
                table: "OpiniaoPilarHappiness",
                column: "happiness_id");

            migrationBuilder.CreateIndex(
                name: "IX_OpiniaoPilarHappiness_pilarHappiness_id",
                table: "OpiniaoPilarHappiness",
                column: "pilarHappiness_id");

            migrationBuilder.CreateIndex(
                name: "IX_PilarCompetencia_PerfilId",
                table: "PilarCompetencia",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_PilarCompetencia_TipoCompetenciaId",
                table: "PilarCompetencia",
                column: "TipoCompetenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_PilarDominio_DominioAgilidadeId",
                table: "PilarDominio",
                column: "DominioAgilidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestaoPilar_PilarDominioId",
                table: "QuestaoPilar",
                column: "PilarDominioId");

            migrationBuilder.CreateIndex(
                name: "IX_timecolaborador_colaborador_id",
                table: "timecolaborador",
                column: "colaborador_id");

            migrationBuilder.CreateIndex(
                name: "IX_timecolaborador_time_id",
                table: "timecolaborador",
                column: "time_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliacaoHealthCheck");

            migrationBuilder.DropTable(
                name: "avalicaocolaboradoritempilar");

            migrationBuilder.DropTable(
                name: "feedback");

            migrationBuilder.DropTable(
                name: "OpiniaoPilarHappiness");

            migrationBuilder.DropTable(
                name: "timecolaborador");

            migrationBuilder.DropTable(
                name: "HealthCheck");

            migrationBuilder.DropTable(
                name: "QuestaoPilar");

            migrationBuilder.DropTable(
                name: "avaliacaocolaborador");

            migrationBuilder.DropTable(
                name: "itempilar");

            migrationBuilder.DropTable(
                name: "tipofeedback");

            migrationBuilder.DropTable(
                name: "happiness");

            migrationBuilder.DropTable(
                name: "pilarhappiness");

            migrationBuilder.DropTable(
                name: "time");

            migrationBuilder.DropTable(
                name: "PilarDominio");

            migrationBuilder.DropTable(
                name: "PilarCompetencia");

            migrationBuilder.DropTable(
                name: "colaborador");

            migrationBuilder.DropTable(
                name: "DominioAgilidade");

            migrationBuilder.DropTable(
                name: "tipoCompetencia");

            migrationBuilder.DropTable(
                name: "perfil");
        }
    }
}

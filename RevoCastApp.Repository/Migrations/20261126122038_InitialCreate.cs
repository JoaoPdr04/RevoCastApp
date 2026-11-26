using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RevoCastApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Convidado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    especialidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    vinculo_institucional = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convidado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Episodio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numero_ep = table.Column<int>(type: "integer", nullable: false),
                    titulo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    formato = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    data_gravacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    patrimonio = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    categoria = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    local_armazenamento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EtapaDeProducao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    etapa = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ordem = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtapaDeProducao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Membro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    curso = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    prontuario = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParticipacaoDoConvidado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    episodioId = table.Column<int>(type: "integer", nullable: false),
                    convidadoId = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    confirmado = table.Column<bool>(type: "boolean", nullable: false),
                    tema_abordado = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EpisodioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipacaoDoConvidado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipacaoDoConvidado_Convidado_convidadoId",
                        column: x => x.convidadoId,
                        principalTable: "Convidado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipacaoDoConvidado_Episodio_EpisodioId",
                        column: x => x.EpisodioId,
                        principalTable: "Episodio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParticipacaoDoConvidado_Episodio_episodioId",
                        column: x => x.episodioId,
                        principalTable: "Episodio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsoDeEquipamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    episodioId = table.Column<int>(type: "integer", nullable: false),
                    equipamentoId = table.Column<int>(type: "integer", nullable: false),
                    observacao = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    EpisodioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsoDeEquipamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsoDeEquipamento_Episodio_EpisodioId",
                        column: x => x.EpisodioId,
                        principalTable: "Episodio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsoDeEquipamento_Episodio_episodioId",
                        column: x => x.episodioId,
                        principalTable: "Episodio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsoDeEquipamento_Equipamento_equipamentoId",
                        column: x => x.equipamentoId,
                        principalTable: "Equipamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Corte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    titulo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    episodioId = table.Column<int>(type: "integer", nullable: false),
                    membroId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Corte_Episodio_episodioId",
                        column: x => x.episodioId,
                        principalTable: "Episodio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Corte_Membro_membroId",
                        column: x => x.membroId,
                        principalTable: "Membro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipeDoEpisodio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    episodioId = table.Column<int>(type: "integer", nullable: false),
                    membroId = table.Column<int>(type: "integer", nullable: false),
                    funcao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipeDoEpisodio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipeDoEpisodio_Episodio_episodioId",
                        column: x => x.episodioId,
                        principalTable: "Episodio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipeDoEpisodio_Membro_membroId",
                        column: x => x.membroId,
                        principalTable: "Membro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    etapaId = table.Column<int>(type: "integer", nullable: false),
                    descricao = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    prazo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_conclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    episodioId = table.Column<int>(type: "integer", nullable: false),
                    membroId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefa_Episodio_episodioId",
                        column: x => x.episodioId,
                        principalTable: "Episodio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarefa_EtapaDeProducao_etapaId",
                        column: x => x.etapaId,
                        principalTable: "EtapaDeProducao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarefa_Membro_membroId",
                        column: x => x.membroId,
                        principalTable: "Membro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Corte_episodioId",
                table: "Corte",
                column: "episodioId");

            migrationBuilder.CreateIndex(
                name: "IX_Corte_membroId",
                table: "Corte",
                column: "membroId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeDoEpisodio_episodioId",
                table: "EquipeDoEpisodio",
                column: "episodioId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeDoEpisodio_membroId",
                table: "EquipeDoEpisodio",
                column: "membroId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipacaoDoConvidado_convidadoId",
                table: "ParticipacaoDoConvidado",
                column: "convidadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipacaoDoConvidado_episodioId",
                table: "ParticipacaoDoConvidado",
                column: "episodioId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipacaoDoConvidado_EpisodioId",
                table: "ParticipacaoDoConvidado",
                column: "EpisodioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_episodioId",
                table: "Tarefa",
                column: "episodioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_etapaId",
                table: "Tarefa",
                column: "etapaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_membroId",
                table: "Tarefa",
                column: "membroId");

            migrationBuilder.CreateIndex(
                name: "IX_UsoDeEquipamento_episodioId",
                table: "UsoDeEquipamento",
                column: "episodioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsoDeEquipamento_EpisodioId",
                table: "UsoDeEquipamento",
                column: "EpisodioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsoDeEquipamento_equipamentoId",
                table: "UsoDeEquipamento",
                column: "equipamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corte");

            migrationBuilder.DropTable(
                name: "EquipeDoEpisodio");

            migrationBuilder.DropTable(
                name: "ParticipacaoDoConvidado");

            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropTable(
                name: "UsoDeEquipamento");

            migrationBuilder.DropTable(
                name: "Convidado");

            migrationBuilder.DropTable(
                name: "EtapaDeProducao");

            migrationBuilder.DropTable(
                name: "Membro");

            migrationBuilder.DropTable(
                name: "Episodio");

            migrationBuilder.DropTable(
                name: "Equipamento");
        }
    }
}

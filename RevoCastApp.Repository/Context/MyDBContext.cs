using Microsoft.EntityFrameworkCore;
using RevoCastApp.Domain.Entities;

namespace RevoCastApp.Repository.Context
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        // Cada DbSet vira uma tabela no PostgreSQL
        public DbSet<Membro> Membros { get; set; }
        public DbSet<Episodio> Episodios { get; set; }
        public DbSet<EquipeEpisodio> EquipeEpisodios { get; set; }
        public DbSet<Convidado> Convidados { get; set; }
        public DbSet<ParticipacaoConvidado> ParticipacaoConvidados { get; set; }
        public DbSet<EtapaProducao> EtapaProducoes { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Corte> Cortes { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<UsoEquipamento> UsoEquipamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Aplica automaticamente todas as classes da pasta Mapping que implementam IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDBContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Aqui vai o endereço do seu PostgreSQL local
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=RevoCastDB;Username=postgres;Password=ifsp");
            }
        }
    }
}
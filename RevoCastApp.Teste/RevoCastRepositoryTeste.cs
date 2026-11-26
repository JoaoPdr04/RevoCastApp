using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevoCastApp.Domain.Entities;
using RevoCastApp.Repository.Base;
using RevoCastApp.Repository.Context;

namespace RevoCastApp.Teste
{
    [TestClass]
    public class TestRevoCastRepository
    {
        private MyDBContext _context = null!;
        private BaseRepository<Membro> _membroRepo = null!;
        private BaseRepository<Episodio> _episodioRepo = null!;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MyDBContext>()
                .UseNpgsql("Host=localhost;Port=5432;Database=RevoCastDB;Username=postgres;Password=ifsp")
                .Options;

            _context = new MyDBContext(options);
            _membroRepo = new BaseRepository<Membro>(_context);
            _episodioRepo = new BaseRepository<Episodio>(_context);
        }

        [TestMethod]
        public void Deve_Inserir_E_Consultar_Episodio_Com_Include_De_Equipe()
        {
            var membro = new Membro { nome = "Laura Riitano", curso = "Eng. Computação", prontuario = "BI3000001" };
            _membroRepo.Insert(membro);

            var episodio = new Episodio
            {
                numero_ep = 7,
                titulo = "Projetando Saberes: O Valor da Iniciação Científica",
                data_gravacao = DateTime.UtcNow,
                descricao = "Episódio com a coordenação de pesquisa",
                formato = "Presencial",
                status = "Publicado",
                EquipeEpisodios = new List<EquipeEpisodio>
                {
                    new EquipeEpisodio { funcao = "Host e Design", membro = membro }
                }
            };
            _episodioRepo.Insert(episodio);

            // Busca usando includes encadeados para confirmar o JOIN do EF Core
            var includes = new List<string> { "EquipeEpisodios", "EquipeEpisodios.membro" };
            var episodioBuscado = _episodioRepo.Select(episodio.Id, includes);

            Assert.IsNotNull(episodioBuscado);
            Assert.AreEqual(1, episodioBuscado.EquipeEpisodios.Count);
            Assert.AreEqual("Laura Riitano", episodioBuscado.EquipeEpisodios[0].membro!.nome);
        }
    }
}
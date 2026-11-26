using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevoCastApp.Domain.Entities;
using RevoCastApp.Repository.Base;
using RevoCastApp.Repository.Context;
using RevoCastApp.Service.Base;
using RevoCastApp.Service.Validators;

namespace RevoCastApp.Teste
{
    [TestClass]
    public class EpisodioTest
    {
        private BaseService<Membro> _membroService = null!;
        private BaseService<Episodio> _episodioService = null!;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MyDBContext>()
                .UseNpgsql("Host=localhost;Port=5432;Database=RevoCastDB;Username=postgres;Password=ifsp")
                .Options;

            var context = new MyDBContext(options);

            _membroService = new BaseService<Membro>(new BaseRepository<Membro>(context));
            _episodioService = new BaseService<Episodio>(new BaseRepository<Episodio>(context));
        }

        [TestMethod]
        public void Deve_Cadastrar_Episodio_Com_Equipe_No_Banco()
        {
            var membro = new Membro
            {
                nome = "João Pedro",
                curso = "Engenharia da Computação",
                prontuario = "BI3033988"
            };
            _membroService.Add<MembroValidator>(membro);

            var episodio = new Episodio
            {
                numero_ep = 9,
                titulo = "Mundo Tech: Estágio e Mercado de Trabalho",
                data_gravacao = DateTime.UtcNow,
                descricao = "Episódio especial sobre carreira em tecnologia",
                formato = "Presencial",
                status = "Gravado",
                EquipeEpisodios = new List<EquipeEpisodio>
                {
                    new EquipeEpisodio
                    {
                        funcao = "Direção Geral",
                        membro = membro
                    }
                }
            };

            var resultado = _episodioService.Add<EpisodioValidator>(episodio);

            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Id > 0);
            Assert.IsTrue(resultado.EquipeEpisodios[0].Id > 0);
        }

        [TestMethod]
        public void Nao_Deve_Cadastrar_Episodio_Com_Numero_Zero()
        {
            var episodioInvalido = new Episodio
            {
                numero_ep = 0,
                titulo = "Episódio Inválido",
                data_gravacao = DateTime.UtcNow,
                formato = "Presencial",
                status = "Planejado"
            };

            Assert.Throws<ValidationException>(() =>
            {
                _episodioService.Add<EpisodioValidator>(episodioInvalido);
            });
        }
    }
}
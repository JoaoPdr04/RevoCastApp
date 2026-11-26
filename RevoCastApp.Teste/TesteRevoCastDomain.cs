using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevoCastApp.Domain.Entities;

namespace RevoCastApp.Teste
{
    [TestClass]
    public class TestRevoCastDomain
    {
        [TestMethod]
        public void Deve_Instanciar_Episodio_Com_Lista_De_Equipe_Inicializada()
        {
            var membro = new Membro { Id = 1, nome = "João Pedro", curso = "Eng. Computação", prontuario = "BI3033988" };
            var episodio = new Episodio
            {
                Id = 1,
                numero_ep = 9,
                titulo = "Mundo Tech: Estágio e Mercado de Trabalho",
                data_gravacao = DateTime.UtcNow,
                formato = "Presencial",
                status = "Gravado"
            };

            episodio.EquipeEpisodios.Add(new EquipeEpisodio
            {
                funcao = "Direção Geral",
                membro = membro,
                episodio = episodio
            });

            Assert.IsNotNull(episodio.EquipeEpisodios);
            Assert.AreEqual(1, episodio.EquipeEpisodios.Count);
            Assert.AreEqual("João Pedro", episodio.EquipeEpisodios[0].membro.nome);
        }
    }
}
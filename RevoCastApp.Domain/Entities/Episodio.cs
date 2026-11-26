using System;
using System.Collections.Generic;
using System.Text;
using RevoCastApp.Domain.Base;

namespace RevoCastApp.Domain.Entities
{
        public class Episodio : BaseEntity
    {
        public int numero_ep { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public string formato { get; set; }
        public DateTime data_gravacao { get; set; }
        public string status { get; set; }

        public List<EquipeEpisodio> EquipeEpisodios { get; set; } = new List<EquipeEpisodio>();
        public List<ParticipacaoConvidado> Participacoes { get; set; }
        public List<UsoEquipamento> UsoEquipamentos { get; set; }
    }
}

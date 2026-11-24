using System;
using System.Collections.Generic;
using System.Text;
using RevoCastApp.Domain.Base;

namespace RevoCastApp.Domain.Entities
{
    public class Tarefa : BaseEntity
    {
        public EtapaProducao etapa { get; set; }
        public string descricao { get; set; }
        public string status { get; set; }
        public DateTime prazo { get; set; }
        public DateTime? data_conclusao { get; set; }
        public Episodio episodio { get; set; }
        public Membro membro { get; set; }
    }
}

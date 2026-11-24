using System;
using System.Collections.Generic;
using System.Text;
using RevoCastApp.Domain.Base;

namespace RevoCastApp.Domain.Entities
{
    public class ParticipacaoConvidado : BaseEntity
    {
        public Episodio episodio { get; set; }
        public Convidado convidado { get; set; }
        public string status { get; set; }
        public bool confirmado { get; set; }
        public string tema_abordado { get; set; }
    }
}
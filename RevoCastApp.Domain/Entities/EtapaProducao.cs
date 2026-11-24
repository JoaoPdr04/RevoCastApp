using System;
using System.Collections.Generic;
using System.Text;
using RevoCastApp.Domain.Base;

namespace RevoCastApp.Domain.Entities
{
    public class EtapaProducao : BaseEntity
    {
        public string etapa { get; set; }
        public int ordem { get; set; }
    }
}

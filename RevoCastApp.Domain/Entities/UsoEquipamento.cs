using System;
using System.Collections.Generic;
using System.Text;
using RevoCastApp.Domain.Base;

namespace RevoCastApp.Domain.Entities
{
    public class UsoEquipamento : BaseEntity
    {
        public Episodio episodio { get; set; }
        public Equipamento equipamento { get; set; }
        public string observacao { get; set; }
    }
}

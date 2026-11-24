using System;
using System.Collections.Generic;
using System.Text;
using RevoCastApp.Domain.Base;


namespace RevoCastApp.Domain.Entities
{
    public class Equipamento : BaseEntity
    {
        public string patrimonio { get; set; }
        public string nome { get; set; }
        public string categoria { get; set; }
        public string local_armazenamento { get; set; }
        public string status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using RevoCastApp.Domain.Base;

namespace RevoCastApp.Domain.Entities
{
    public class Convidado : BaseEntity
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string especialidade { get; set; }
        public string vinculo_institucional { get; set; }


    }
}

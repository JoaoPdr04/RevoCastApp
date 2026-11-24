using System;
using System.Collections.Generic;
using System.Text;
using RevoCastApp.Domain.Base;

namespace RevoCastApp.Domain.Entities
{
    public class Membro : BaseEntity
    {
        public string nome { get; set; }
        public string curso { get; set; }
        public string prontuario { get; set; }
    }
}

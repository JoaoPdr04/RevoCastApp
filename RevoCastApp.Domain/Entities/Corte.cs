using System;
using System.Collections.Generic;
using System.Text;
using RevoCastApp.Domain.Base;

namespace RevoCastApp.Domain.Entities
{
    public class Corte : BaseEntity
    {
        public string titulo { get; set; }
        public string status { get; set; }
        public Episodio episodio { get; set; }
        public Membro membro { get; set; }
    }
}
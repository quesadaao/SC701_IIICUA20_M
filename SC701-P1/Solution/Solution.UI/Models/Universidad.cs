using System;
using System.Collections.Generic;

namespace Solution.UI.Models
{
    public partial class Universidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? Fundacion { get; set; }
        public string Dominio { get; set; }
    }
}

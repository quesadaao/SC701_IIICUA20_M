using System;
using System.Collections.Generic;

#nullable disable

namespace Solution.APIW2.Models
{
    public partial class Universidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? Fundacion { get; set; }
        public string Dominio { get; set; }
    }
}

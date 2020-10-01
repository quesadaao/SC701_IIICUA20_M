using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solution.DO.Objects
{
    public class Pais
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}

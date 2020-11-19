using System;
using System.Collections.Generic;

#nullable disable

namespace UI.Relationships.Models
{
    public partial class RegistrationToken
    {
        public int RegistrationTokenId { get; set; }
        public Guid Token { get; set; }
        public string Role { get; set; }
    }
}

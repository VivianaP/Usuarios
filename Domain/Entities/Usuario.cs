using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario : AuditableBaseEntity
    {
        public string Nombre { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public string Username { get; set; }
        
    }
}

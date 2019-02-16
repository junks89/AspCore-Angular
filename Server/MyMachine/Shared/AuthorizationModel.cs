using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class AuthorizationModel
    {
        public bool IsAuthorized { get; set; }
        public string Role { get; set; }
        public string MyAdditionalInfo { get; set; }
    }
}

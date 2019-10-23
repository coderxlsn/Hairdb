using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hairdb.Areas.API.Model
{
    public class LoginModel
    {
        public string AccessToken { get; set; }
        public string Username { get; set; }
    }
}

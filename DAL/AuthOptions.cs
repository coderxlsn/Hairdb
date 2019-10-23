﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hairdb.DAL
{
    public class AuthOptions
    {
        public const string ISSUER = "HairAuthServer"; // издатель токена
        public const string AUDIENCE = "http://localhost:52572/"; // потребитель токена
        const string KEY = "hair_secretkey!123";   // ключ для шифрации
        public const int LIFETIME = 3600; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}

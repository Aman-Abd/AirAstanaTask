using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAstana
{
    public class AuthOptions
    {
        public const string ISSURE = "AuthServer";
        public const string AUDIENCE = "AuthClient";
        const string KEY = "QwErTY123!REwqedsadwWQESDA";
        public const int LIFETIME = 60;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}

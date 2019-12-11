using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApiRH.Models.ViewModel
{
    public class AuthModel
    {
        public const string ISSUER = "AuthServer"; // издатель токена
        public const string AUDIENCE = "http://192.168.43.80:5000/"; 
        const string KEY = "*-*MySuperSecret!0909!";   // ключ для шифрации
        public const int LIFETIME = 60*24; // время жизни токена - 1 день
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}

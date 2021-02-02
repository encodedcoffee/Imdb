using System;
using System.Security.Cryptography;
using System.Text;

namespace GlobalUtils
{
    public static class Criptografia
    {
        public static string Criptografar(this string texto)
        {
            var shaManaged = new SHA512Managed();
            var hash = BitConverter.ToString(shaManaged.ComputeHash(Encoding.UTF8.GetBytes(texto)));
            return hash;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CommonComponents
{
    public static class GetHashSenha
    {
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        private static byte[] salt = new byte[16];

        public static string GetSenha(string senha)
        {
            
            MD5 md5Hash = MD5.Create();
            byte[] hash = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));
            StringBuilder hashBytes = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                hashBytes.Append(hash[i].ToString("x2"));
            }
            return hashBytes.ToString();
        }
        
    }
}

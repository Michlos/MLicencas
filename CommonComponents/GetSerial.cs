using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GeradorHash
{
    public partial class GetSerial
    {
        //private static RNGCryptoServiceProvider rNGCrypto = new RNGCryptoServiceProvider();
        private static SHA256Managed hA256Managed = new SHA256Managed();

        private static byte[] salt = new byte[16];
        private static Random random = new Random();
        private const string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// 
        ///        string cnpj = "20548056000192";
        ///
        ///        string[] valoresAleatorios = GetSerial.Get(0, 4);
        ///        string valorParaHash = string.Empty;
        ///            foreach (var item in valoresAleatorios)
        ///            {
        ///                valorParaHash += item.ToString();
        ///            }
        ///
        ///    Console.WriteLine("CHAVE: " + valorParaHash);
        ///            Console.WriteLine("HASH MD5: "+GetSerial.GetHash(valorParaHash+cnpj.Substring(0,8)+cnpj.Substring(12,2)));
        ///            Console.WriteLine("HASH SHA256:" +GetSerial.GetHashSha(valorParaHash+cnpj.Substring(0,8)+cnpj.Substring(12,2)));
        ///            Console.WriteLine("HASH CLIENTE MD5: "+GetSerial.GetHash(cnpj.Substring(0,8)+cnpj.Substring(12,2)));
        ///            Console.WriteLine("HASH CLIENTE SHA: "+GetSerial.GetHashSha(cnpj.Substring(0,8)+cnpj.Substring(12,2)));
        /// </summary>
        /// <param name="tamnhoNumero"></param>
        /// <param name="casas"></param>
        /// <returns></returns>
        /// 


        public static string[] Get(int casas)
        {
            string[] valoresRetornaveis = new string[casas];
            for (int i = 0; i < casas; i++)
            {
                
                valoresRetornaveis[i] = GetLetra() + random.Next(10000, 99999).ToString();

            }

            return valoresRetornaveis;
            
        }

        private static string GetLetra()
        {
            int min = 0;
            int max = letras.Length - 1;
            int intLetra = random.Next(min, max);
            string stringLetra = letras.Substring(intLetra, 1);
            return stringLetra;

        }

        public static string GetHash(string parametro)
        {

            MD5 md5Hash = MD5.Create();
            byte[] hash = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(parametro));
            StringBuilder hashBytes = new StringBuilder();

            foreach (var item in hash)
            {
                hashBytes.Append(item.ToString("x2"));
            }

            return hashBytes.ToString();
        }
        public static string GetHashSha(string parametro)
        {
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            
            byte[] UcMessage = unicodeEncoding.GetBytes(parametro);
            byte[] HashVelue = hA256Managed.ComputeHash(UcMessage);
           
            string hash = string.Empty;
            foreach (var b in HashVelue)
            {
                hash += b.ToString("x2");
            }
            return hash;
        }
    }
}   

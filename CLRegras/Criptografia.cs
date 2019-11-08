using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CLRegras
{
    public static class Criptografia
    {
       
        /// <summary>
        /// Consulta o código MD5 de uma string
        /// </summary>
        /// <param name="md5Hash"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        /// <summary>
        /// Gerar a senha codificada
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string CriarSenha(string source)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string md5completa = GetMd5Hash(md5Hash, source);
                string part1 = md5completa.Substring(2, 4);
                string part2 = md5completa.Substring(6, 9);
                string senha = part2 + part1;
                return senha;
            }
        }
    }
}

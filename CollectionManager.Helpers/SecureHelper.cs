using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManager.Helpers
{
    public static class SecureHelper
    {
        public static string LoginSalt { get { return "PanacheP@ssw0rd"; } }
        public static string EncryptSha512(this string value)
        {
            return Encrypt(value, LoginSalt, SHA512.Create());
        }

        private static string Encrypt(string value, string salt, HashAlgorithm hashAlgorithm)
        {
            var valueBytes = Encoding.UTF8.GetBytes(value);
            var saltBytes = Encoding.UTF8.GetBytes(salt);

            var toHash = new byte[valueBytes.Length + saltBytes.Length];
            Array.Copy(valueBytes, 0, toHash, 0, valueBytes.Length);
            Array.Copy(saltBytes, 0, toHash, valueBytes.Length, saltBytes.Length);

            var hash = hashAlgorithm.ComputeHash(toHash);
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}

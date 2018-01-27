using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Security
{
    public class Sha256Encryption
    {
        private string _salt;

        public Sha256Encryption()
        {
            _salt = "ubMD6pinTzpLYAf6A2FYgNjsdEs9CKJbZfICqZaF0";
        }



        public string GenerateSha256Hash(string input)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + _salt);
            SHA256Managed sha256hashString = new SHA256Managed();
            byte[] hash = sha256hashString.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }

    }
}

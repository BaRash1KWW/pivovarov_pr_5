using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace pr5_PasswordSecurity
{
    public class PasswordHasher
    {
        public string ComputeHash(string inputPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(inputPassword);
                byte[] hashBytes = sha256.ComputeHash(sourceBytes);

                string hashString = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                return hashString;
            }
        }
    }
}

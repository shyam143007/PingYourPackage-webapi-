using System;
using System.Security.Cryptography;
using System.Text;

namespace PingYourPackage.API.BusinessLogic.CryptoService
{
    public class CryptoService : ICryptoService
    {
        public string EncryptPassword(string password, string salt)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");
            if (string.IsNullOrEmpty(salt))
                throw new ArgumentNullException("salt");

            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = $"{salt}{password}";
                byte[] saltPwdBytes = Encoding.UTF8.GetBytes(saltedPassword);

                return Convert.ToBase64String(sha256.ComputeHash(saltPwdBytes));
            }
        }

        public string GenerateSalt()
        {
            var data = new Byte[0x10];

            using (var cryptoProvider = new RNGCryptoServiceProvider())
            {
                cryptoProvider.GetBytes(data);
                return Convert.ToBase64String(data);
            }
        }
    }
}

using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace SmartBankUi.Models.Util
{
    public class CryptographyUtils
    {
        public static Tuple<String, String> GenerateHashAndSalt(String password)
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var hashed = Hash(password, salt);
            return new Tuple<String, String>(hashed, Convert.ToBase64String(salt));
        }

        public static String GenerateHash(String password, String salt)
        {
            return Hash(password, Convert.FromBase64String(salt));
        }

        private static String Hash(String text, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: text,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 4));
        }
    }
}
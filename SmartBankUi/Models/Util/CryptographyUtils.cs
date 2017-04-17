using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace SmartBankUi.Models.Util
{
    public static class CryptographyUtils
    {
        public static Tuple<string, string> GenerateHashAndSalt(string password)
        {
            // generate a 128-bit salt using a secure PRNG
            var salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var hashed = Hash(password, salt);
            return new Tuple<string, string>(hashed, Convert.ToBase64String(salt));
        }

        public static string GenerateHash(string password, string salt)
        {
            return Hash(password, Convert.FromBase64String(salt));
        }

        private static string Hash(string text, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                text,
                salt,
                KeyDerivationPrf.HMACSHA1,
                10000,
                256 / 4));
        }

        public static bool HaveTheSamePassword(BankUser newUser, BankUser originalUser)
        {
            return HaveTheSamePassword(originalUser.Password, newUser.Password,
                originalUser.Salt);
        }

        public static bool HaveTheSamePassword(string originalPassword, string newPassword,
            string salt)
        {
            return
                Hash(newPassword, Convert.FromBase64String(salt)).Equals(originalPassword);
        }
    }
}
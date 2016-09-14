using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.Helper
{
    public static class PasswordValidator
    {
        public static void ValidatePassword(string password)
        {
            if(password?.Length < 8)
                FoutMelding.Maak("Paswoord moet minimum 8 karakters lang zijn!");

            if (new Regex("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,64})").Matches(password).Count == 0)
                FoutMelding.Maak("Paswoord moet kleine, grote letters en cijfers bevatten!");

        }


        public static string HashPassword(string password, string salt)
        {
            byte[] passwordSaltBytes = Encoding.UTF8.GetBytes($"{password}{salt}");

            HashAlgorithm hasher = new SHA512Managed();

            byte[] hashBytes = hasher.ComputeHash(passwordSaltBytes);

            return Encoding.UTF8.GetString(hashBytes);
        }

        public static bool VerifyPassword(string hash, string password, string salt)
        {
            string compareHash = HashPassword(password, salt);

            if (compareHash != hash)
                return false;

            return true;
        }

        public static string GenerateSalt()
        {
            byte[] salt = new byte[32];

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            rng.GetNonZeroBytes(salt);

            return Encoding.UTF8.GetString(salt);
        }


    }
}

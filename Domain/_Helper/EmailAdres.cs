using System;
using System.Text.RegularExpressions;

namespace Domain.Helper
{
    public static class EmailAdres
    {
        public static bool IsValid(string eMail)
        {
            if (string.IsNullOrEmpty(eMail))
                return false;
            var rgx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return rgx.IsMatch(eMail);
        }

        public static void IsValid(string veldNaam, string email)
        {
            if (IsValid(email))
                FoutMelding.Maak($"{veldNaam} is ongeldig E-mail adres!");
        }

        public static string Format(string email)
        {
            return email.ToLower();
        }
    }
}

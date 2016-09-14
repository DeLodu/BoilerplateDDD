using System;
using Domain.Generic;
using Domain.Helper;

namespace Domain.ApplicationModule
{
    public class Gebruiker : Entiteit
    {
        [Obsolete("Constructor niet toegestaan!", true)]
        public Gebruiker() {}

        public Gebruiker(string login)
        {
            NieuwUID();
            SetLogin(login);
        }

        public string Naam { get; private set; }

        public void SetNaam(string naam)
        {
            TekstValidator.IsNietLangerDan("Naam", naam, 100);

            Naam = naam;
        }

        public string Login { get; private set; }

        public void SetLogin(string naam)
        {
            TekstValidator.IsNietLangerDan("Login", naam, 50);

            TekstValidator.IsNietKorterDan("Login", naam, 3);

            Login = naam.ToLower();
        }

        public string Salt { get; private set; }

        private void SetSalt()
        {
            Salt = PasswordValidator.GenerateSalt();
        }

        public string PasswordHash { get; private set; }

        public void SetPassword(string newPassword)
        {
            PasswordValidator.ValidatePassword(newPassword);

            SetSalt();
            PasswordHash = PasswordValidator.HashPassword(newPassword, Salt);
        }

        public bool VerifyPassword(string password)
        {
            return PasswordValidator.VerifyPassword(PasswordHash, password, Salt);
        }


    }
}

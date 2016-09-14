using System;
using Domain.Generic;
using Domain.Helper;

namespace Domain.ApplicationModule.Logger
{
    public class LogItem : Entiteit
    {
        public LogItem(string melding, string gebruiker)
        {
            NieuwUID();

            TekstValidator.IsNietLangerDan("Melding", melding, 150);
            TekstValidator.IsVerplicht("Melding", melding);
            Melding = melding;

            TekstValidator.IsNietLangerDan("LoginNaam", gebruiker, 50);
            TekstValidator.IsVerplicht("LoginNaam", gebruiker);
            LoginNaam = gebruiker;

            Datum = DateTime.Now;
            
        }

        public string Melding { get; private set; }

        public DateTime Datum { get; private set; }

        public string LoginNaam { get; private set; }
    }
}

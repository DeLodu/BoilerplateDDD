using System;

namespace Domain.Helper
{
    static class TekstValidator
    {

        public static bool IsNietKorterDan(string tekst, int lengte)
        {
            return string.IsNullOrEmpty(tekst) || tekst?.Length <= lengte;
        }

        public static void IsNietKorterDan(string naamVeld, string tekst, int lengte)
        {
            if(IsNietKorterDan(tekst, lengte))
                FoutMelding.Maak($"{naamVeld} moet minstens {lengte.ToString()} karakters bevatten!");
        }

        public static bool IsNietLangerDan(string tekst, int lengte)
        {
            return tekst?.Length >= lengte;
        }

        public static void IsNietLangerDan(string naamVeld, string tekst, int lengte)
        {
            if(IsNietLangerDan(tekst, lengte))
                FoutMelding.Maak($"{naamVeld} mag maximum {lengte.ToString()} karakters bevatten!");
        }

        public static void IsVerplicht(string naamVeld, string tekst)
        {
            if(string.IsNullOrEmpty(tekst))
                FoutMelding.Maak($"{naamVeld} is verplicht in te vullen!");
        }
    }
}

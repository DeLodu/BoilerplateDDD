using System;

namespace Domain.Helper
{
    public static class FoutMelding
    {
        public static void Maak(string boodschap)
        {
            throw new Exception(boodschap);
        }
    }
}

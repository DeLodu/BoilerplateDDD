using System;
using Domain.Events;

namespace Domain.ApplicationModule.Accounts
{
    public class GebruikerVerwijderdEvent: IDomainEvent
    {
        public Gebruiker Gebruiker { get; private set; }

        public GebruikerVerwijderdEvent(Gebruiker gebr)
        {
            Gebruiker = gebr;
        }
    }
}

using System;
using Domain.Generic;

namespace Domain.KanbanModule.Taak
{
    public class Status : Entiteit
    {
        protected Status() { }

        public Status(string naam)
        {
            NieuwUID();
            Naam = naam;
        }

        public Status(Guid uID, string naam)
        {
            UID = uID;
            Naam = naam;
        }

        public string Naam { get; private set; }

    }
}

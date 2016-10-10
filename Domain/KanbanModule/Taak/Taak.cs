using System;
using Domain.Events;
using Domain.Generic;

namespace Domain.KanbanModule.Taak
{
    public class Taak : Entiteit
    {
        protected Taak() { }

        public Taak(string omschKort)
        {
            NieuwUID();
            OmschrijvingKort = omschKort;
            DomainEvent<TaakAangemaaktEvent>.Raise(new TaakAangemaaktEvent(this));
        }

        public Guid StatusUID { get; private set; }

        public Status Status { get; private set; }

        public void SetStatus(Status stat)
        {
            Status = stat;
            StatusUID = stat.UID;
        }

        public string OmschrijvingKort { get; private set; }

        public string OmschrijvingLang { get; private set; }


    }
}

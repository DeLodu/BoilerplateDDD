using System;
using Domain.Events;
using Domain.Generic;
using Domain.Helper;

namespace Domain.KanbanModule.Taak
{
    public class Taak : Entiteit
    {
        protected Taak() { }

        public Taak(string omschKort)
        {
            NieuwUID();

            if(string.IsNullOrEmpty(omschKort))
                FoutMelding.Maak("Omschrijving is verplicht!");

            OmschrijvingKort = omschKort;
            DomainEvent<TaakAangemaaktEvent>.Raise(new TaakAangemaaktEvent(this));
        }

        public Guid StatusUID { get; private set; }

        public Status Status { get; private set; }

        public void SetStatus(Status stat)
        {
            if(stat == null)
                throw new Exception("Status kan niet NULL zijn!");

            Status = stat;
            StatusUID = stat.UID;
        }

        public string OmschrijvingKort { get; private set; }

        public string OmschrijvingLang { get; private set; }

        public void SetOmschrijvingLang(string omschrijving)
        {
            OmschrijvingLang = omschrijving;
        }
    }
}

using System;
using Domain.Events;

namespace Domain.KanbanModule.Taak
{
    public class TaakAangemaaktEvent: IDomainEvent
    {
        public Taak Taak { get; private set; }

        public TaakAangemaaktEvent(Taak taak)
        {
            Taak = taak;
        }
    }
}

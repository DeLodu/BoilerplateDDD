using System;
using Domain.DependencyContracts;
using Domain.Events;
using Domain.KanbanModule.Taak;
using Persistence.Repository;

namespace Events
{
    public static class EventAPI
    {

        public static void RegisterAll(IUnitOfWork uow)
        {
            RegisterAccountModule(uow);
            RegisterKanbanModule(uow);
        }

        public static void RegisterAccountModule(IUnitOfWork uow)
        {
            
        }

        public static void RegisterKanbanModule(IUnitOfWork uow)
        {
            DomainEvent<TaakAangemaaktEvent>.Register(e => new SetStatusInitTaakAction(new TaakRepository(uow)).HandleEvent(e));
        }

    }
}

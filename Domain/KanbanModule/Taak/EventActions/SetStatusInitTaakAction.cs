using System;
using Domain.DependencyContracts;
using Domain.Events;

namespace Domain.KanbanModule.Taak
{
    public class SetStatusInitTaakAction : IEventHandler<TaakAangemaaktEvent>
    {
        private readonly ITaakRepository _repos;

        public SetStatusInitTaakAction(ITaakRepository repos)
        {
            _repos = repos;
        }

        public void HandleEvent(TaakAangemaaktEvent eventInstance)
        {
            if (eventInstance.Taak.Status == null)
                eventInstance.Taak.SetStatus(_repos.GetStatusInit());
        }
    }
}

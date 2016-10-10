using System;
using System.Collections.Generic;
using Domain.DependencyContracts;

namespace Domain.KanbanModule.Taak
{
    public interface ITaakRepository: IRepository<Taak>
    {
        Status GetStatusInit();

        IEnumerable<Status> GetStatussen();
    }
}

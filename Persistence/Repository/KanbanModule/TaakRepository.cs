using System;
using System.Collections.Generic;
using Domain.DependencyContracts;
using Domain.KanbanModule.Taak;
using Persistence.Generic;

namespace Persistence.Repository
{
    public class TaakRepository : GenericRepository<Taak>, ITaakRepository
    {
        public TaakRepository() : base() { }

        public TaakRepository(IUnitOfWork uow) : base (uow) { }

        public Status GetStatusInit()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Status> GetStatussen()
        {
            throw new NotImplementedException();
        }
    }
}

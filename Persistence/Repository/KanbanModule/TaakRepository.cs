using System;
using System.Collections.Generic;
using System.Linq;
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
            return GetSelect<Status>().FirstOrDefault(e => e.Naam == "Nieuw");
        }

        public IEnumerable<Status> GetStatussen()
        {
            return GetSelect<Status>().ToList();
        }
    }
}

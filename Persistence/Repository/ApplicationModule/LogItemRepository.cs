using System;
using Domain.ApplicationModule.Logger;
using Domain.DependencyContracts;
using Persistence.Generic;

namespace Persistence.Repository
{
    public class LogItemRepository : GenericRepository<LogItem>, ILogItemRepository
    {
        public LogItemRepository() : base() { }

        public LogItemRepository(IUnitOfWork uow) : base (uow) { }

    }
}

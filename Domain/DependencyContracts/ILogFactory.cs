using System;
using Domain.ApplicationModule.Logger;

namespace Domain.DependencyContracts
{
    public interface ILogFactory
    {
        LogItem Create(string melding, string username);

        void CreateAndPersist(string melding, string username, IUnitOfWork uow);
    }
}

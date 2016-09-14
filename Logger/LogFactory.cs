using System;
using Domain.DependencyContracts;
using Domain.ApplicationModule.Logger;

namespace Logger
{
    public class LogFactory : ILogFactory
    {
        public LogItem Create(string melding, string username)
        {
            return new LogItem(melding, username);
        }

        public void CreateAndPersist(string melding, string username, IUnitOfWork uow)
        {
            // var repos = new repsoitory;
            var item = Create(melding, username);

            //repos.addnew(item);

        }
    }
}

using System;
using System.Linq;
using Domain.ApplicationModule.Accounts;
using Domain.DependencyContracts;
using Persistence.Generic;

namespace Persistence.Repository
{
    public class GebruikerRepository : GenericRepository<Gebruiker>, IGebruikerRepository
    {
        public GebruikerRepository() : base() { }

        public GebruikerRepository(IUnitOfWork uow) : base (uow) { }

        public Gebruiker GetByLogin(string login)
        {
            return GetSelect<Gebruiker>().FirstOrDefault(e => e.Login == login);
        }
    }
}

using System;
using Domain.ApplicationModule.Accounts;
using Domain.DependencyContracts;
using Persistence.Generic;

namespace Persistence.Repository
{
    public class GebruikerRepository : GenericRepository<Gebruiker>, IGebruikerRepository
    {
        public GebruikerRepository() : base() { }

        public GebruikerRepository(IUnitOfWork uow) : base (uow) { }

        public Gebruiker GetByLoginNaam(string Naam)
        {
            throw new NotImplementedException();
        }
    }
}

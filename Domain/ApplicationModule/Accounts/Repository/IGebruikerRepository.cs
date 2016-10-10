using System;
using Domain.DependencyContracts;

namespace Domain.ApplicationModule.Accounts
{
    public interface IGebruikerRepository: IRepository<Gebruiker>
    {
        Gebruiker GetByLoginNaam(string Naam);
    }
}
